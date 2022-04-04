using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class BrandService : BaseService<BrandDTO, Brand, BrandFilter>
    {
        public BrandService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        protected override IQueryable<Brand> FilterOut(IQueryable<Brand> query, BrandFilter filter)
        {
            if (filter.Name != null)
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                query = query.Where(b => b.Name.Contains(filter.Name));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return query;
        }

        //        public BrandDTO GetBrand(Guid Id)
        //        {
        //            var entity = Database.GetRepository<Brand>().GetAll().FirstOrDefault(b => b.Id == Id);

        //            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Brand, BrandDTO>()).CreateMapper();
        //#pragma warning disable CS8604 // Possible null reference argument.
        //            BrandDTO brandDTO = mapper.Map<Brand, BrandDTO>(entity);
        //#pragma warning restore CS8604 // Possible null reference argument.
        //            return brandDTO;
        //        }
    }
}
