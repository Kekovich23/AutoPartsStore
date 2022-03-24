using AutoPartsStore.DAL.Entities;
namespace AutoPartsStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Brand> Brands { get; }
        IRepository<Detail> Details { get; }
        IRepository<Feature> Features { get; }
        IRepository<Manufacturer> Manufacturers { get; }
        IRepository<Model> Models { get; }
        IRepository<Modification> Modifications { get; }
        IRepository<Order> Orders { get; }
        IRepository<PriceList> PriceLists { get; }
        IRepository<Section> Sections { get; }
        IRepository<Status> Statuses { get; }
        IRepository<TypeDetail> TypeDetails { get; }
        IRepository<TypeTransport> TypeTransports { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
