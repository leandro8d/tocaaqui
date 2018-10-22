
using Domain.Entity;

using Repository.Base;
using Repository.Especification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class EstabelecimentoRepository :RepositoryBase<Estabelecimento>
    {

        public List<Estabelecimento> GetByUser(int idUser){

            var result = _session.Query<Estabelecimento>().Where(x => x.Responsavel.IdUsuario == idUser).ToList();
            return result;
        

        }

    }
}
