using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Portifolio:BaseBusiness<Portifolio>
    {
        public virtual System.Int64 IdPortifolio { get; set; }
        public virtual System.Int64 IdBanda { get; set; }
        public virtual IList<FotoPortifolio> Fotos { get; set; }
        public virtual System.String Descricao { get; set; }
        public virtual Banda Banda { get; set; }

        public Portifolio() { }
        public Portifolio(long idBanda, IList<FotoPortifolio> fotos,string descricao) {
            this.IdBanda = idBanda;
            this.Fotos = fotos;
            this.Descricao = descricao;
        }
    }
}
