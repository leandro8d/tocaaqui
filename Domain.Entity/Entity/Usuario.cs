using Domain.Base;
using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Usuario: BaseBusiness<Usuario>
    {
        public virtual System.Int64 IdUsuario { get; set; }
        public virtual System.String Nome { get; set; }
        public virtual System.String CPF { get; set; }
        public virtual System.String Email { get; set; }
        public virtual System.String Estado { get; set; }
        public virtual System.String Cidade { get; set; }
        public virtual TipoUsuarioEnum TipoUsuario { get; set; }
        public virtual IList<Banda> Bandas { get; set; }
        public virtual IList<Estabelecimento> Estabelecimentos { get; set; }

        public  Usuario(){
         
        }

        public virtual void Consist(){

            if(String.IsNullOrEmpty(this.Nome)){
                throw new Exception("Nome invalido!");
            }
            
            if(String.IsNullOrEmpty(this.Email)){
                throw new Exception("Email invalido!");
            }
            
            if(String.IsNullOrEmpty(this.CPF)){
                throw new Exception("CPF invalido!");
            }
        }
    }
}
