using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class EstiloMusical:BaseBusiness<EstiloMusical>
    {
        public virtual System.Int64 IdEstiloMusical { get; set; }
        public virtual System.String Descricao { get; set; }
    }
}
