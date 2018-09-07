using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Epecification
{
    public interface IRepository<TEntity>
    {
            void Save(object obj);
            void Delete(object obj);
            object GetById(Type objType, object objId);
            IQueryable<TEntity> ToList();
        
    }
}
