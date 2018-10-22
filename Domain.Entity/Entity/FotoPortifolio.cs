using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class FotoPortifolio:BaseBusiness<FotoPortifolio>
    {
        public virtual System.Int64 IdFoto { get; set; }
        public virtual byte[] Foto { get; set; }
        public virtual System.Int64 IdPortifolio { get; set; }

        public FotoPortifolio() { }
        public FotoPortifolio(byte[] foto,long idPortifolio) {
            this.Foto = foto;
            this.IdPortifolio = idPortifolio;
        }
    }
}
