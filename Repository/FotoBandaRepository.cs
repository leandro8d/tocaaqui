
using Domain.Entity;

using Repository.Base;
using Repository.Especification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class FotoBandaRepository :RepositoryBase<FotoBanda>
    {

        public FotoBanda GetByBanda(long banda){

            var result = _session.Query<FotoBanda>().Where(x => x.Banda.IdBanda == banda).FirstOrDefault();
            return result;
        }

    }
}
