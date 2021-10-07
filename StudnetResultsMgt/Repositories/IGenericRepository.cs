using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_API.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Delete(object id);
        void Update(T obj);
        void Save();
    }
}

