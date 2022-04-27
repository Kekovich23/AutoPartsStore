using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.DAL.Interfaces;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class DetailProfile : Profile {
        public DetailProfile(IUnitOfWork unitOfWork) {
            CreateMap<Detail, DetailDTO>().ReverseMap();
            CreateMap<DetailDTO, DetailViewModel>()
                .ForMember(trg => trg.Modifications, opt => opt.Ignore())
                .AfterMap((src, trg, context) => {
                    var modificatoins = unitOfWork.GetRepository<Modification>().GetAll().ToList();
                    var result = modificatoins.GroupJoin(
                        src.Modifications,
                        a => a.Id,
                        b => b.Id,
                        (a, b) => new SelectableModificationViewModel {
                            Id = a.Id,
                            Name = a.Name,
                            ModelId = a.ModelId,
                            Selected = b.FirstOrDefault(_ => _.Id == a.Id) != null
                        }).ToList();
                    trg.Modifications = result;
                })
                .ReverseMap()
                .ForMember(trg => trg.Modifications, opt => opt.MapFrom(src => src.Modifications.Where(x => x.Selected)));
        }
    }
}
