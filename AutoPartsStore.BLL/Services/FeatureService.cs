using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class FeatureService : BaseService<FeatureDTO, Feature>
    {
        public FeatureService(IUnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<DetailDTO> GetDetails(Guid id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Detail, DetailDTO>()).CreateMapper();

            var feature = Database.GetRepository<Feature>().Get(id);

#pragma warning disable CS8604 // Possible null reference argument.
            return mapper.Map<IEnumerable<Detail>, List<DetailDTO>>(feature.Details);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
