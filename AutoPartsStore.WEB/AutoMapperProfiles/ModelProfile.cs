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
            CreateMap<Model, ModelDTO>().ReverseMap();
            CreateMap<ModelDTO, ModelViewModel>().ReverseMap();
        }
    }
}
