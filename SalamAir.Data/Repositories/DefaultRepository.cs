using SalamAir.Domain.Contracts;
using SalamAir.Domain.Entities;

namespace SalamAir.Data.Repositories
{
    public abstract class DefaultRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected SalamAirContext Context { get; }

        public DefaultRepository(SalamAirContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IList<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
