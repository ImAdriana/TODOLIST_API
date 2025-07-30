namespace TODOLIST_API.Repository
{
    public interface ITodoRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> IsTaskCompleted(bool isCompleted);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();

    }
}
