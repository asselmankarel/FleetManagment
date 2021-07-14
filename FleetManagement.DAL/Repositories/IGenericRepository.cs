﻿using System.Collections.Generic;
using System;

namespace FleetManagement.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);

 
    }
}