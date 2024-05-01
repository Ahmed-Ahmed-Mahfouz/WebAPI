namespace Lab2.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public List<TEntity> GetAll();

        public void Add(TEntity entity);

        public TEntity GetById(int id);

        public void update(TEntity entity);

        public void Delete(int id);

        public void Save();
    }
}
