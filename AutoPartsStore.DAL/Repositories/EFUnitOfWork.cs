using AutoPartsStore.DAL.EF;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsStore.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext db;
        private Dictionary<string, object> repositories { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EFUnitOfWork(DbContextOptions<ApplicationContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            db = new ApplicationContext(options);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), db);
#pragma warning disable CS8604 // Possible null reference argument.
                repositories.Add(type, repositoryInstance);
#pragma warning restore CS8604 // Possible null reference argument.
            }
            return (Repository<T>)repositories[type];
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
