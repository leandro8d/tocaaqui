using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Services.Infrastructure;


namespace Application.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //private AppSessionFactory sessao { get; set; }
        public ValuesController() {
            //sessao = session;
        }
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            //var a = new Usuario();
            //a.Nome = "Leandro";
            //a.Email = "asdsad";
            //a.CPF = "ASD";
            //a.TipoUsuario = TipoUsuarioEnum.MUSICO;
            //var section = sessao.OpenSession();
            //var transaction = section.BeginTransaction();
            //var list = section.Query<Usuario>().ToList(); ;
           
            
            return Json("");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
