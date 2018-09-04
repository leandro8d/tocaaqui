using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Web.Base;
using Domain.Common;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Repository;
using Services.Infrastructure;



namespace Application.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public UserController() {



        }
        // GET api/values
        [HttpPost]
        public JsonResult login([FromBody]Login usr)
        {
            //var obj =  usuarioRepo.Get(1);
           var dados =  Usuario.Repository.ToList();
           
            return new JsonResult(dados);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
