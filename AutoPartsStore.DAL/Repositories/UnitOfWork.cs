using AutoPartsStore.DAL.Context;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsStore.DAL.Repositories {
    public class UnitOfWork : IUnitOfWork {
        private readonly ApplicationContext db;
        private Dictionary<string, object> Repositories { get; set; }

        public UnitOfWork(DbContextOptions<ApplicationContext> options) {
            db = new ApplicationContext(options);
        }

        public IRepository<T> GetRepository<T>() where T : class {
            if (Repositories == null) {
                Repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!Repositories.ContainsKey(type)) {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), db);
                Repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)Repositories[type];
        }

        public void Save() {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
