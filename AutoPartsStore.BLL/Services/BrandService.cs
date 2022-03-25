using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.AN.Infrastructure;
using AutoPartsStore.BLL.Interfaces;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class BrandService : IService<BrandDTO>
    {
        IUnitOfWork Database { get; set; }

        public BrandService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Create(BrandDTO entityDTO)
        {
            Brand brand = new() { Name = entityDTO.Name, Id = entityDTO.Id };
            Database.GetRepository<Brand>().Create(brand);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public BrandDTO Get(Guid? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id брэнда", "");
            var brand = Database.GetRepository<Brand>().Get(id.Value);
            if (brand == null)
                throw new ValidationException("Брэнд не найден", "");

            return new BrandDTO { Id = brand.Id, Name = brand.Name };
        }

        public IEnumerable<BrandDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Brand, BrandDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Brand>, List<BrandDTO>>(Database.GetRepository<Brand>().GetAll());
        }

        public void Remove(BrandDTO entityDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrandDTO, Brand>()).CreateMapper();
            Brand brand = mapper.Map<BrandDTO, Brand>(entityDTO);
            
            Database.GetRepository<Brand>().Remove(brand);
        }

        public void Update(BrandDTO entityDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrandDTO, Brand>()).CreateMapper();
            Brand brand = mapper.Map<BrandDTO, Brand>(entityDTO);

            Database.GetRepository<Brand>().Update(brand);
        }
    }
}
