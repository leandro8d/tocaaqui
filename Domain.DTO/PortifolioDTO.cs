using Domain.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace Domain.DTO
{
    public class PortifolioDTO
    {
        public virtual System.Int64 IdBanda { get; set; }
        public virtual System.Int64 IdPortifolio { get; set; }
        public virtual List<FotoDTO> Fotos { get; set; }
        public virtual System.String Descricao { get; set; }
        public virtual Banda Banda { get; set; }



    }
}
