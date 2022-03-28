using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class TypeTransportService : BaseService<TypeTransportDTO, TypeTransport>
    {
        public TypeTransportService(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
