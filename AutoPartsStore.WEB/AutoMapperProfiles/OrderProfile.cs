using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class OrderProfile : Profile {
        public OrderProfile() {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDTO, OrderViewModel>().ReverseMap();
        }
    }
}
