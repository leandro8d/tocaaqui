using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Estabelecimento
    {
        public virtual System.Int64 IdEstabelecimento { get; set; }
        public virtual System.String Nome { get; set; }
        public virtual System.String Endereco { get; set; }
        public virtual System.String CEP { get; set; }
        public virtual System.String Estado { get; set; }
        public virtual System.String Cidade { get; set; }
        public virtual Usuario Responsavel { get; set; }
        public virtual System.Boolean Excluido {get;set;}
        public virtual List<EstiloMusicalEnum> EstilosMusicais { get; set; }
        public virtual List<Agenda> Agenda { get; set; }
        public virtual List<FotoEstabelecimento> Fotos { get; set; }
    }
}
