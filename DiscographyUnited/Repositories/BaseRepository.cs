using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Data;
using DiscographyUnited.Interfaces;

namespace DiscographyUnited.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DiscographyUnitedContext RepositoryContext { get; set; }

        protected BaseRepository(DiscographyUnitedContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> FindAll()
        {
            return RepositoryContext.Set<T>().ToList();
        }
        public T FindById(long id)
        {
            return RepositoryContext.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            RepositoryContext.SaveChanges();
        }
    }
}