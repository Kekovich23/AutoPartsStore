using AutoMapper;
using AutoPartsStore.AN.DTO.Complex;
using AutoPartsStore.AN.Entities.Complex;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class OrderDetailProfile : Profile {
        public OrderDetailProfile() {
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        }
    }
}
