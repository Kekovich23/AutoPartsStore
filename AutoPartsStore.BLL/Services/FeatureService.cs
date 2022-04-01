using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class FeatureService : BaseService<FeatureDTO, Feature>
    {
        public FeatureService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public IEnumerable<DetailDTO> GetDetails(Func<Feature, bool> predicate)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Detail, DetailDTO>()).CreateMapper();

            var feature = Database.GetRepository<Feature>().Get(predicate);

#pragma warning disable CS8604 // Possible null reference argument.
            return mapper.Map<IEnumerable<Detail>, List<DetailDTO>>(feature.Details);
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
