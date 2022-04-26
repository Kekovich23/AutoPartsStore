using AutoMapper;
using AutoPartsStore.AN.DTO.Complex;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class CartToOrder : Profile {
        public CartToOrder() {
            CreateMap<CartDTO, OrderDetailDTO>().ReverseMap();
        }
    }
}
