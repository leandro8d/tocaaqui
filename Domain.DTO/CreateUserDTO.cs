using Domain.Entity;
using System;

namespace Domain.DTO
{
    public class CreateUserDTO
    {
        public  System.Int64 IdLogin { get; set; }
        public  Usuario Usuario { get; set; }
        public  System.String _Login { get; set; }
        public System.String Token { get; set; }
    }
}
