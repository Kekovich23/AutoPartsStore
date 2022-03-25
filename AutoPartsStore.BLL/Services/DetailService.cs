using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.AN.Infrastructure;
using AutoPartsStore.BLL.Interfaces;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class DetailService : IService<DetailDTO>
    {
        IUnitOfWork Database { get; set; }

        public DetailService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(DetailDTO entityDTO)
        {
            Detail detail = new() { Id = entityDTO.Id, ManufacturerId = entityDTO.ManufacturerId };
            Database.GetRepository<Detail>().Create(detail);
        }

        public DetailDTO Get(Guid? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id детали", "");
            var detail = Database.GetRepository<Detail>().Get(id.Value);
            if (detail == null)
                throw new ValidationException("Деталь не найдена", "");

            return new DetailDTO { Id = detail.Id, ManufacturerId = detail.ManufacturerId };
        }

        public IEnumerable<DetailDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Detail, DetailDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Detail>, List<DetailDTO>>(Database.GetRepository<Detail>().GetAll());
        }

        public void Remove(DetailDTO entityDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DetailDTO, Detail>()).CreateMapper();
            Detail detail = mapper.Map<DetailDTO, Detail>(entityDTO);

            Database.GetRepository<Detail>().Remove(detail);
        }

        public void Update(DetailDTO entityDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DetailDTO, Detail>()).CreateMapper();
            Detail detail = mapper.Map<DetailDTO, Detail>(entityDTO);

            Database.GetRepository<Detail>().Update(detail);
        }

        public IEnumerable<FeatureDTO> GetFeatures(Guid id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Feature, Feature>()).CreateMapper();
            var detail = Database.GetRepository<Detail>().Get(id);

#pragma warning disable CS8604 // Possible null reference argument.
            return mapper.Map<IEnumerable<Feature>, List<FeatureDTO>>(detail.Features);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public void SetFeature(Guid idDetail, Guid[] idFeatures)
        {
            Detail detail = Database.GetRepository<Detail>().Get(idDetail);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            detail.Features.Clear();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (idFeatures != null)
            {
                foreach (Feature feature in Database.GetRepository<Feature>().GetAll().Where(f => idFeatures.Contains(f.Id)))
                {
                    if (feature == null)
                        throw new ValidationException("Характеристики отсутсвуют", "");
                    detail.Features.Add(feature);
                }
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
