
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UsuarioRepository<TEntity>:BaseBusiness<TEntity> where TEntity : class, new()
    {
    }
}
