using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            CreateMap<Model, ModelDTO>().ForMember(m => m.BrandName, opt => opt.MapFrom(m => m.Brand.Name));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            CreateMap<ModelDTO, Model>();
            CreateMap<ModelDTO, ModelViewModel>().ReverseMap();
        }
    }
}
