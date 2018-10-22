using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class FotoBanda : BaseBusiness<FotoBanda>
    {
        public virtual System.Int64 IdFotoBanda { get; set; }
        public virtual System.Byte[] Foto { get; set; }
        public virtual Banda Banda { get; set; }

        public FotoBanda(Byte[] foto, Banda banda) {
            this.Foto = foto;
            this.Banda = banda;
        }
        public FotoBanda() { }
    }
}
