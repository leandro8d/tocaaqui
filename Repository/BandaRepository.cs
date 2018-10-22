
using Domain.Entity;

using Repository.Base;
using Repository.Especification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class BandaRepository :RepositoryBase<Banda>
    {
        public IList<Banda> GetByUser(int idUser){

            var result = _session.QueryOver<Banda>().Where(x => x.Responsavel.IdUsuario == idUser).List();
            return result;
        }

    }
}
