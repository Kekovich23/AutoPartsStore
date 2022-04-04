using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.DAL.Interfaces;
using System.Data.Entity;

namespace AutoPartsStore.BLL.Services
{
    public class ModelService : BaseService<ModelDTO, Model, ModelFilter>
    {
        public ModelService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        protected override IQueryable<Model> Include(IQueryable<Model> query)
        {
            return query
                .Include(m => m.Brand)
                .Include(m => m.TypeTransport);
        }
        protected override IQueryable<Model> FilterOut(IQueryable<Model> query, ModelFilter filter)
        {
            if (filter.Name != null)
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                query = query.Where(m => m.Name.Contains(filter.Name));
            if (filter.Brand != null)
#pragma warning disable CS8604 // Possible null reference argument.
                query = query.Where(m => m.Brand.Name.Contains(filter.Brand.Name));
            if (filter.TypeTransport != null)
                query = query.Where((m) => m.TypeTransport.Name.Contains(filter.TypeTransport.Name));
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return query;
        }
        //public ModelDTO GetModel(Guid Id)
        //{
        //    var entity = Database.GetRepository<Model>().GetAll().Include(m => m.Brand).Include(m => m.TypeTransport).FirstOrDefault(m => m.Id == Id);

        //    var entityDTO = _mapper.Map<ModelDTO>(entity);
        //    //#pragma warning disable CS8604 // Possible null reference argument.
        //    //            ModelDTO modelDTO = mapper.Map<Model, ModelDTO>(entity);
        //    //            modelDTO.BrandName = Database.GetRepository<Brand>().Get(b => b.Id == modelDTO.BrandId).Name;
        //    //            modelDTO.TypeTransportName = Database.GetRepository<TypeTransport>().Get(b => b.Id == modelDTO.TypeTransportId).Name;
        //    //#pragma warning restore CS8604 // Possible null reference argument.
        //    return entityDTO;
        //}

        //public IEnumerable<ModelDTO> GetModels()
        //{
        //    return _mapper.Map<IEnumerable<ModelDTO>>(Database.GetRepository<Model>().GetAll().Include(m => m.Brand).Include(m => m.TypeTransport));
        //}
    }
}
