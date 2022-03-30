using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class BrandService : BaseService<BrandDTO, Brand>
    {
        public BrandService(IUnitOfWork uow) : base(uow)
        {
        }

        public BrandDTO GetBrand(Guid Id)
        {
            var entity = Database.GetRepository<Brand>().GetAll().FirstOrDefault(b => b.Id == Id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Brand, BrandDTO>()).CreateMapper();
#pragma warning disable CS8604 // Possible null reference argument.
            BrandDTO brandDTO = mapper.Map<Brand, BrandDTO>(entity);
#pragma warning restore CS8604 // Possible null reference argument.
            return brandDTO;
        }
    }
}
