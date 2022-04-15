using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Data.Entity;
using System.Linq.Dynamic.Core;

namespace AutoPartsStore.BLL.Services {
    public class ModelService : BaseService<Model, ModelDTO, Guid, ModelFilter> {
        public ModelService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService<Model, ModelDTO, Guid, ModelFilter>> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<Model> Include(IQueryable<Model> query) {
            return query
                .Include(m => m.Brand)
                .Include(m => m.TypeTransport);
        }

        protected override IQueryable<Model> FilterOut(IQueryable<Model> query, ModelFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(m => m.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            if (filter.BrandId.HasValue) {
                query = query.Where(m => m.BrandId == filter.BrandId.Value);
            }

            if (filter.TypeTransportId.HasValue) {
                query = query.Where((m) => m.TypeTransportId == filter.TypeTransportId.Value);
            }

            ////Search    
            //if (!string.IsNullOrEmpty(filter.SearchValue)) {
            //    query = query.Where(m => m.Name.ToLower() == filter.SearchValue.ToLower()
            //    || m.Brand.Name.ToLower() == filter.SearchValue.ToLower()
            //    || m.TypeTransport.Name.ToLower() == filter.SearchValue.ToLower());
            //}
            //Sorting
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }

            //Paging     
            query = query.Skip(filter.Skip).Take(filter.PageSize);

            return query;
        }

        public override ModelFilter GetFilter(IFormCollection form, ModelFilter filter) {
            filter.Name = form["Name"].FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(form["BrandId"])) {
                filter.BrandId = Guid.Parse(form["BrandId"].FirstOrDefault());
            }
            if (!string.IsNullOrWhiteSpace(form["TypeTransportId"])) {
                filter.TypeTransportId = Convert.ToInt32(form["TypeTransportId"].FirstOrDefault());
            }
            
            return filter;
        }
    }
}
