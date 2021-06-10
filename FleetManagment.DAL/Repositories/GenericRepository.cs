using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        public GenericRepository()
        {

        }
        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Change(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
