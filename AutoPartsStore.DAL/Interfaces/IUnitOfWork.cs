namespace AutoPartsStore.DAL.Interfaces {
    public interface IUnitOfWork : IDisposable {
        public IRepository<T> GetRepository<T>() where T : class;
        void Save();
    }
}
