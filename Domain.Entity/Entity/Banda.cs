using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Banda
    {
        public virtual System.Int64 IdBanda { get; set; }
        public virtual System.String Nome { get; set; }
        public virtual System.String Origem { get; set; }
        public virtual IList<EstiloMusicalEnum> EstilosMusicais { get; set; }
        public virtual IList<Agenda> Agenda { get; set; }
        public virtual Usuario Responsavel { get; set; }

    }
}
