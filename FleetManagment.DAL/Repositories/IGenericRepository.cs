using System.Collections.Generic;

namespace FleetManagement.DAL.Repositories
{
    interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Change(T entity);
    }
}
