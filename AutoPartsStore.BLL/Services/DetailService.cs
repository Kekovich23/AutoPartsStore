using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.AN.Infrastructure;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class DetailService : BaseService<DetailDTO, Detail>
    {
        public DetailService(IUnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<FeatureDTO> GetFeatures(Guid id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Feature, FeatureDTO>()).CreateMapper();
            
            var detail = Database.GetRepository<Detail>().Get(id);

#pragma warning disable CS8604 // Possible null reference argument.
            return mapper.Map<IEnumerable<Feature>, List<FeatureDTO>>(detail.Features);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public void SetFeatures(Guid idDetail, Guid[] idFeatures)
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
        public IEnumerable<ModificationDTO> GetModifications(Guid id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Modification, ModificationDTO>()).CreateMapper();

            var detail = Database.GetRepository<Detail>().Get(id);

#pragma warning disable CS8604 // Possible null reference argument.
            return mapper.Map<IEnumerable<Modification>, List<ModificationDTO>>(detail.Modifications);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public void SetModifications(Guid idDetail, Guid[] idModifications)
        {
            Detail detail = Database.GetRepository<Detail>().Get(idDetail);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            detail.Modifications.Clear();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (idModifications != null)
            {
                foreach (Modification modification in Database.GetRepository<Modification>().GetAll().Where(f => idModifications.Contains(f.Id)))
                {
                    if (modification == null)
                        throw new ValidationException("Характеристики отсутсвуют", "");
                    detail.Modifications.Add(modification);
                }
            }
        }
    }
}
