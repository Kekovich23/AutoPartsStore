using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsStore.BLL.Services {
    public class ModificationService : BaseService<Modification, ModificationDTO, Guid, ModificationFilter> {
        public ModificationService(
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<BaseService<Modification, ModificationDTO, Guid, ModificationFilter>> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<Modification> Include(IQueryable<Modification> query) {
            return query
                .Include(m => m.Model)
                .Include(m => m.Details);                
        }

        protected override IQueryable<Modification> FilterOut(IQueryable<Modification> query, ModificationFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(m => m.Name.ToLower().Contains(filter.Name.ToLower()));
            }
            if (filter.ModelId.HasValue) {
                query = query.Where(m => m.ModelId == filter.ModelId.Value);
            }
            return query;
        }

        protected override IQueryable<Modification> OrderBy(IQueryable<Modification> query, ModificationFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }
            return query;
        }

        public override ModificationFilter GetFilter(IFormCollection form) {
            ModificationFilter filter = new();
            filter = InitFilter(form, filter);
            filter.Name = form["Name"].FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(form["ModelId"]) && Guid.TryParse(form["ModelId"], out Guid result)) {
                filter.ModelId = result;
            }
            return filter;
        }

        public ServiceResult<IEnumerable<DetailDTO>> GetDetails(ModificationDTO modification) {
            try {
                var query = Database.GetRepository<Detail>()
                    .GetAll()
                    .Where(d => d.Modifications.Contains(_mapper.Map<Modification>(modification)))
                    .Include(d => d.Manufacturer)
                    .Include(d => d.TypeDetail);

                return ServiceResult<IEnumerable<DetailDTO>>.Success(_mapper.Map<IEnumerable<DetailDTO>>(query));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to get details");
                return ServiceResult<IEnumerable<DetailDTO>>.Failed("Failed to get details");
            }            
        }

        public ServiceResult<ModificationDTO> SetDetails(ModificationDTO modificationDTO, IEnumerable<DetailDTO> detailsDTO) {
            try {
                var details = _mapper.Map<IEnumerable<Detail>>(detailsDTO);

                var modification = _mapper.Map<Modification>(modificationDTO);

                modification.Details.Clear();

                foreach (var detail in details) {
                    modification.Details.Add(detail);
                }

                Database.GetRepository<Modification>().Update(modification);

                return ServiceResult<ModificationDTO>.Success(_mapper.Map<ModificationDTO>(modification));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to get details");
                return ServiceResult<ModificationDTO>.Failed("Failed to get details");
            }
        }
    }
}
