using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public class TypeTransportService : BaseService<TypeTransportDTO, TypeTransport, TypeTransportFilter>
    {
        public TypeTransportService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
        protected override IQueryable<TypeTransport> FilterOut(IQueryable<TypeTransport> query, TypeTransportFilter filter)
        {
            if (filter.Name != null)
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                query = query.Where(t => t.Name.Contains(filter.Name));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return query;
        }

        //        public TypeTransportDTO GetTypeTransport(Guid Id)
        //        {
        //            var entity = Database.GetRepository<TypeTransport>().GetAll().FirstOrDefault(b => b.Id == Id);

        //            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeTransport, TypeTransportDTO>()).CreateMapper();
        //#pragma warning disable CS8604 // Possible null reference argument.
        //            TypeTransportDTO typeTransportDTO = mapper.Map<TypeTransport, TypeTransportDTO>(entity);
        //#pragma warning restore CS8604 // Possible null reference argument.
        //            return typeTransportDTO;
        //        }
    }
}
