using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class ModelService : BaseService<ModelDTO, Model>
    {
        public ModelService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public ModelDTO GetModel(Guid Id)
        {
            var entity = Database.GetRepository<Model>().GetAll().FirstOrDefault(b => b.Id == Id);

            var entityDTO = _mapper.Map<ModelDTO>(entity);
            //#pragma warning disable CS8604 // Possible null reference argument.
            //            ModelDTO modelDTO = mapper.Map<Model, ModelDTO>(entity);
            //            modelDTO.BrandName = Database.GetRepository<Brand>().Get(b => b.Id == modelDTO.BrandId).Name;
            //            modelDTO.TypeTransportName = Database.GetRepository<TypeTransport>().Get(b => b.Id == modelDTO.TypeTransportId).Name;
            //#pragma warning restore CS8604 // Possible null reference argument.
            return entityDTO;
        }
    }
}
