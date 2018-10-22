using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Web.Base;
using Domain.Common;
using Domain.DTO;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Repository;
using Services.Infrastructure;



namespace Application.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    public class UserController : Controller
    {
        public UserController()
        {



        }
        // GET api/values
        [HttpGet("{idUsuario}")]
        public JsonResult GetUsuario(int idUsuario)
        {
            //var obj =  usuarioRepo.Get(1);
            var dados = new UsuarioRepository().GetById(idUsuario);

            return new JsonResult(dados);

        }

        // GET api/values

        [HttpPut("add")]
        [AllowAnonymous]
        public JsonResult Insert([FromBody] Login login)
        {
            //var obj =  usuarioRepo.Get(1);
            Usuario.Save(login.Usuario);
            Login.Save(login);


            return new JsonResult("Usuario Incluido!");

        }

        [HttpPost("")]
        public JsonResult Update([FromBody] Usuario usuario)
        {
            //var obj =  usuarioRepo.Get(1);
            new UsuarioRepository().Save(usuario);

            return new JsonResult("Usuario Alterado!");

        }



        // GET api/values/5
        [HttpGet("tiposusuario")]
        public JsonResult GetTipoUsuario()
        {
            var dict = new Dictionary<int, string>();
            foreach (var name in Enum.GetNames(typeof(TipoUsuarioEnum)))
            {
                dict.Add((int)Enum.Parse(typeof(TipoUsuarioEnum), name), name);
            }

            return new JsonResult(dict);
        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
