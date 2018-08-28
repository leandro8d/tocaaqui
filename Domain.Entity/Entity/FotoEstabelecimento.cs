using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class FotoEstabelecimento
    {
        public virtual System.Int64 IdFotoEstabelecimento { get; set; }
        public virtual System.Array Foto { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }
    }
}
