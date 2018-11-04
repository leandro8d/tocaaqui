using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Application.Web.Base;
using Domain.Common;
using Domain.DTO;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Repository;
using Services.Infrastructure;
using Domain;

namespace Application.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    public class BandaController : Controller
    {
        public BandaController()
        {



        }
        // GET api/values
        [HttpGet("{idBanda}")]
        public JsonResult GetBanda(int idBanda)
        {
            //var obj =  usuarioRepo.Get(1);
            var dados = new BandaRepository().GetById(idBanda);

            return new JsonResult(dados);

        }


        // GET api/values
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            //var obj =  usuarioRepo.Get(1);
            var dados = Banda.ToList();

            return Ok(dados);
        }


        // GET api/values
        [HttpGet("{idUsuario}/Bandas")]
        public ActionResult GetBandas(int idUsuario)
        {
            var dados = new BandaRepository().GetByUser(idUsuario);
         
            return Ok(dados);
        }


        // GET api/values
        [HttpPut("")]
        public IActionResult Insert([FromBody]Banda banda)
        {
            try
            {
                Banda.Save(banda);

                return new JsonResult("Banda Incluída!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("")]
        public IActionResult Edit([FromBody]Banda banda)
        {
            try
            {
                var bandaBd = Banda.Load(banda.IdBanda);
               
                Banda.Save(banda);


                return new JsonResult("Banda Editada!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }





        [HttpPut("portifolio")]
        public IActionResult InsertPortifolio([FromBody] Portifolio portifolio)
        {
            try
            {
                portifolio.Fotos = portifolio.Fotos.Select(x => new FotoPortifolio(x.Foto, portifolio.IdPortifolio)).ToList();
                Portifolio.Save(portifolio);

                return new JsonResult("Portifólio Incluído!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("portifolio")]
        public IActionResult UpdatePortifolio([FromBody] Portifolio portifolio)
        {
            try
            {
                portifolio.Fotos.Where(x => x.IdPortifolio == 0).Select(x => x.IdPortifolio = portifolio.IdPortifolio);
                Portifolio.Save(portifolio);

                return new JsonResult("Portifólio Editado!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // GET api/values
        [HttpGet("{idbanda}/portifolio")]
        public ActionResult GetPortifolio(int idbanda)
        {
            var dados = new PortifolioRepository().GetByBanda(idbanda);

            return Ok(dados);
        }


        [AllowAnonymous]
        [HttpGet("estilosmusicais")]
        public JsonResult GetEstilosMusicais()
        {
            var objs = EstiloMusical.ToList();

            return new JsonResult(objs);
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
