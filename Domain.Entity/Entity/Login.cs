using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Login
    {
        public virtual System.Int64 IdLogin { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual System.String _Login { get; set; }
        public virtual System.String Senha { get; set; }

    }
}
