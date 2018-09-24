
using Domain.Entity;

using Repository.Base;
using Repository.Especification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class LoginRepository : RepositoryBase<Login>
    {
        public Login GetByLogin(string login)
        {
            var result = _session.Query<Login>().Where(x => x._Login == login).FirstOrDefault();
            return result;
        }

    }
}
