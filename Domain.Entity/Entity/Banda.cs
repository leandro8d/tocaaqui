using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Banda:BaseBusiness<Banda>
    {
        public virtual System.Int64 IdBanda { get; set; }
        public virtual System.String Nome { get; set; }
        public virtual System.String Estado { get; set; }
        public virtual System.String Cidade { get; set; }
        public virtual System.Boolean Excluida {get;set;}
        public virtual IList<EstiloMusical> EstilosMusicais { get; set; }
        public virtual IList<Agenda> Agenda { get; set; }
        public virtual Usuario Responsavel { get; set; }
        public virtual FotoBanda Foto { get; set; }
        public virtual Portifolio Portifolio { get; set; }

        public Banda(string nome, string estado, string cidade, bool excluida, IList<EstiloMusical> estilos, IList<Agenda> agenda, Usuario responsavel, FotoBanda foto) {
            this.Nome = nome;
            this.Estado = estado;
            this.Cidade = cidade;
            this.Excluida = excluida;
            this.EstilosMusicais = estilos;
            this.Agenda = agenda;
            this.Responsavel = responsavel;
            this.Foto = foto;
        }

        public Banda() { }

    }
}
