using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class BrandService : BaseService<BrandDTO, Brand>
    {
        public BrandService(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
