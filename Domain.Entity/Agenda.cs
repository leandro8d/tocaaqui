using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Agenda
    {
        public virtual System.Int64 IdAgenda { get; set; }
        public virtual Banda Banda { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }
        public virtual DateTime DthAgenda { get; set; }
    }
}
