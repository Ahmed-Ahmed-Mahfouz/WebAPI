using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        ITIContext db;
        public GenericRepository(ITIContext db)
        {
            this.db = db;
        }

        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public TEntity GetById(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TEntity entity = GetById(id);
            db.Set<TEntity>().Remove(entity);
        }   

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
