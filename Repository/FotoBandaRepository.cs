
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
        public void DeleteBanda(long banda){
            _session.Delete(string.Format("delete from FotoBanda where IdBanda = {0}",banda));
        }

    }
}
