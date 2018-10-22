using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Epecification
{
    public interface IRepository<TEntity>
    {
            void Save(TEntity obj);
            void Delete(TEntity obj);
            object GetById(int objId);
            IQueryable<TEntity> ToList();
        
    }
}
