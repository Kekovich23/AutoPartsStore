using AutoMapper;
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
        public TypeTransportDTO GetTypeTransport(Guid Id)
        {
            var entity = Database.GetRepository<TypeTransport>().GetAll().FirstOrDefault(b => b.Id == Id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeTransport, TypeTransportDTO>()).CreateMapper();
#pragma warning disable CS8604 // Possible null reference argument.
            TypeTransportDTO typeTransportDTO = mapper.Map<TypeTransport, TypeTransportDTO>(entity);
#pragma warning restore CS8604 // Possible null reference argument.
            return typeTransportDTO;
        }
    }
}
