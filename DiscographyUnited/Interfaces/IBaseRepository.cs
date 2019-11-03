using System.Collections.Generic;

namespace DiscographyUnited.Interfaces
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> FindAll();
        T FindById(long id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
