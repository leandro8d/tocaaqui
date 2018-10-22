
using Domain.Entity;

using Repository.Base;
using Repository.Especification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PortifolioRepository :RepositoryBase<Portifolio>
    {

        public Portifolio GetByBanda(long banda){

            var result = _session.Query<Portifolio>().Where(x => x.Banda.IdBanda == banda).FirstOrDefault();
            return result;
        }

    }
}
