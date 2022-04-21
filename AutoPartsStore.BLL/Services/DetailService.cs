using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsStore.BLL.Services {
    public class DetailService : BaseService<Detail, DetailDTO, Guid, DetailFilter> {
        public DetailService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService<Detail, DetailDTO, Guid, DetailFilter>> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<Detail> Include(IQueryable<Detail> query) {
            return query
                .Include(d => d.Manufacturer)
                .Include(d => d.Modifications)
                .Include(d => d.TypeDetail);
        }

        protected override IQueryable<Detail> FilterOut(IQueryable<Detail> query, DetailFilter filter) {
            if (filter.ManufacturerId.HasValue) {
                query = query.Where(m => m.ManufacturerId == filter.ManufacturerId.Value);
            }
            if (filter.TypeDetailId != 0) {
                query = query.Where(m => m.TypeDetailId == filter.TypeDetailId);
            }
            return query;
        }

        protected override IQueryable<Detail> OrderBy(IQueryable<Detail> query, DetailFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }
            return query;
        }

        public override DetailFilter GetFilter(IFormCollection form) {
            DetailFilter filter = new();
            filter = InitFilter(form, filter);

            if (!string.IsNullOrWhiteSpace(form["TypeDetailId"]) && int.TryParse(form["TypeDetailId"], out int result)) {
                filter.TypeDetailId = result;
            }
            if (!string.IsNullOrWhiteSpace(form["ManufacturerId"]) && Guid.TryParse(form["ManufacturerId"], out Guid result2)) {
                filter.ManufacturerId = result2;
            }
            return filter;
        }

        public ServiceResult<IEnumerable<ModificationDTO>> GetModifications(DetailDTO detail) {
            try {
                var query = Database.GetRepository<Modification>()
                    .GetAll()
                    .Where(m => m.Details.Contains(_mapper.Map<Detail>(detail)))
                    .Include(m => m.Model.Brand)
                    .Include(m => m.Model.TypeTransport);

                return ServiceResult<IEnumerable<ModificationDTO>>.Success(_mapper.Map<IEnumerable<ModificationDTO>>(query));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to get modifications");
                return ServiceResult<IEnumerable<ModificationDTO>>.Failed("Failed to get modifications");
            }
        }

        public ServiceResult SetModifications(Guid id, IEnumerable<ModificationDTO> modificationDTOs) {
            try {
                var detail = Database.GetRepository<Detail>()
                    .GetAll()
                    .Where(e => e.Id == id)
                    .Include(e => e.Modifications)
                    .FirstOrDefault();

                detail.Modifications.Clear();
                foreach (var modificationDTO in modificationDTOs) {
                    var modification = Database.GetRepository<Modification>().Get(e => e.Id == modificationDTO.Id);
                    detail.Modifications.Add(modification);
                }

                Database.GetRepository<Detail>().Update(detail);

                return ServiceResult.Success();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to set modifications");
                return ServiceResult.Failed("Failed to set modifications");
            }
        }

        private IEnumerable<DetailFeature> GetFeaturesLocal(Guid id) {
            return Database.GetRepository<DetailFeature>()
                .GetAll()
                .Where(e => e.DetailId == id)
                .Include(e => e.Feature);
        }

        public ServiceResult<IEnumerable<DetailFeature>> GetFeatures(Guid id) {
            try {
                var query = GetFeaturesLocal(id);

                return ServiceResult<IEnumerable<DetailFeature>>.Success(_mapper.Map<IEnumerable<DetailFeature>>(query));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to get features");
                return ServiceResult<IEnumerable<DetailFeature>>.Failed("Failed to get features");
            }
        }

        public ServiceResult SetFeatures(Guid id, IEnumerable<int> featureIds, string value) {
            try {
                var query = GetFeaturesLocal(id).ToList();

                query.RemoveAll(e => e.DetailId == id);

                foreach (var featureId in featureIds) {
                    DetailFeature detailFeature = new() { DetailId = id, FeatureId = featureId, Value = value };
                    Database.GetRepository<DetailFeature>().Create(detailFeature);
                }

                return ServiceResult.Success();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to set features");
                return ServiceResult.Failed("Failed to set features");
            }
        }
    }
}
