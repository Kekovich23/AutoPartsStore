using AutoPartsStore.DAL.EF;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsStore.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public TEntity GetById(Func<TEntity, bool> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _db.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}