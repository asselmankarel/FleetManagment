using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        int Update(T entity);
        Task<int> UpdateAsync(T entity);

 
    }
}
