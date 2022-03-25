using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class ModelService : BaseService<ModelDTO, Model>
    {
        public ModelService(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
