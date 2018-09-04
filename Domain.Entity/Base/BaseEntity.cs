using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public abstract class BaseEntity<TRepository> where TRepository : class, new()
    {
        public static TRepository Repository { get { return new TRepository(); } }
        public BaseEntity()
        {
           
        }
     
    }
}
