using Domain.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace Domain.DTO
{
    public class BandaDTO
    {
        public virtual System.Int64 IdBanda { get; set; }
        public virtual System.String Nome { get; set; }
        public virtual System.String Estado { get; set; }
        public virtual System.String Cidade { get; set; }
        public virtual System.Boolean Excluida { get; set; }
        public virtual IList<EstiloMusical> EstilosMusicais { get; set; }
        public virtual IList<Agenda> Agenda { get; set; }
        public virtual Usuario Responsavel { get; set; }
        public virtual System.String Foto { get; set; }
        public virtual FotoBanda FotoBanda { get; set; }
        public virtual Portifolio Portifolio { get; set; }



    }
}
