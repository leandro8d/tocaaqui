using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    class FotoPerfil
    {
        public virtual System.Int64 IdFoto { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual byte[] Foto { get; set; }
    }
}
