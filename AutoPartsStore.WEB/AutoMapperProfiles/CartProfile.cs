using AutoMapper;
using AutoPartsStore.AN.DTO.Complex;
using AutoPartsStore.AN.Entities.Complex;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class CartProfile : Profile {
        public CartProfile() {
            CreateMap<Cart, CartDTO>().ReverseMap();            
        }
    }
}
