using System.Collections.Generic;

namespace Ums.Service.Interfaces
{
    public interface IService<T> where T:class
    {
        bool Insert(T entity);
        bool Update(T entity);
        IEnumerable<T> GetAll();
        T GetById<Key>(Key id);
    }
}