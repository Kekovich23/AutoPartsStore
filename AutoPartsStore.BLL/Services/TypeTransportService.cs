using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutoPartsStore.BLL.Services {
    public class TypeTransportService : BaseService<TypeTransport, TypeTransportDTO, int, TypeTransportFilter> {
        public TypeTransportService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService<TypeTransport, TypeTransportDTO, int, TypeTransportFilter>> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<TypeTransport> FilterOut(IQueryable<TypeTransport> query, TypeTransportFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(b => b.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            return query;
        }
    }
}
