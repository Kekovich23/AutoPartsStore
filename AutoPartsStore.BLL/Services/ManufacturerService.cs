using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class ManufacturerService : BaseService<ManufacturerDTO, Manufacturer>
    {
        public ManufacturerService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
