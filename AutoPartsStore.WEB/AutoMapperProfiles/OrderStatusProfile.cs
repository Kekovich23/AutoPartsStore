using AutoMapper;
using AutoPartsStore.AN.DTO.Complex;
using AutoPartsStore.AN.Entities.Complex;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class OrderStatusProfile : Profile {
        public OrderStatusProfile() {
            CreateMap<OrderStatus, OrderStatusDTO>().ReverseMap();
        }
    }
}
