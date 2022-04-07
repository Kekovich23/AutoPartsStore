using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutoPartsStore.BLL.Services {
    public class BrandService : BaseService<Brand, BrandDTO, Guid, BrandFilter> {
        public BrandService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService<Brand, BrandDTO, Guid, BrandFilter>> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<Brand> FilterOut(IQueryable<Brand> query, BrandFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(b => b.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            return query;
        }
    }
}
