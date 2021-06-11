using System;
using System.Collections.Generic;
using FleetManagement.DAL.DataAccess;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository()
        {
            _context = new ApplicationDbContext();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
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
