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
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using SixLabors.ImageSharp.Formats;
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
        [HttpGet("{idUsuario}/Bandas")]
        public ActionResult GetBandas(int idUsuario)
        {
            var dados = new BandaRepository().GetByUser(idUsuario);
            List<BandaDTO> bandas = null;
            if (dados != null)
            {
                bandas = dados.Select(x => new BandaDTO { Agenda = x.Agenda, Cidade = x.Cidade, Estado = x.Estado, EstilosMusicais = x.EstilosMusicais, Excluida = x.Excluida, FotoBanda = x.Foto != null ? x.Foto : new FotoBanda(), IdBanda = x.IdBanda, Nome = x.Nome, Responsavel = x.Responsavel, Portifolio = x.Portifolio,Foto = x.Foto != null ? Convert.ToBase64String(x.Foto.Foto):null }).ToList();
            }

            return Ok(bandas);
        }


        // GET api/values
        [HttpPut("")]
        public IActionResult Insert([FromBody]BandaDTO banda)
        {
            //var obj =  usuarioRepo.Get(1);

            var bandaent = new Banda(banda.Nome, banda.Estado, banda.Cidade, banda.Excluida, banda.EstilosMusicais, banda.Agenda, Usuario.ToList().ElementAt(0), null);

            var bandaRepo = new BandaRepository();
            //  var fotobandaRepo = new FotoBandaRepository();
            //FotoBanda.Save(bandaent);
            Banda.Save(bandaent);

            var arrayByte = Convert.FromBase64String(banda.Foto.Replace("data:image/*;charset=utf-8;base64,", ""));

            var fotoBanda = new FotoBanda(arrayByte, bandaent);
            FotoBanda.Save(fotoBanda);

            return new JsonResult("Banda Incluída!");

        }

        [HttpPost("")]
        public IActionResult Edit([FromBody]BandaDTO banda)
        {
            var obj = Banda.Load(banda.IdBanda);

            obj.Nome = banda.Nome;
            obj.Estado = banda.Estado;
            obj.Cidade = banda.Cidade;
            obj.Excluida = banda.Excluida;
            obj.EstilosMusicais = banda.EstilosMusicais;
            obj.Agenda = banda.Agenda;

            Banda.Save(obj);

            if (!String.IsNullOrEmpty(banda.Foto))
            {
                var arrayByte = Convert.FromBase64String(banda.Foto.Replace("data:image/*;charset=utf-8;base64,", ""));
                var repositorioFotoBanda = new FotoBandaRepository();
                var fotoBanda = repositorioFotoBanda.GetByBanda(obj.IdBanda);

                if (fotoBanda != null)
                {
                    fotoBanda.Foto = arrayByte;
                }
                else
                    fotoBanda = new FotoBanda(arrayByte, obj);


                    FotoBanda.Save(fotoBanda);
            }
            return Ok(Json("Banda Alterada!"));

        }





        [HttpPut("portifolio")]
        public IActionResult InsertPortifolio([FromBody] PortifolioDTO portifolio)
        {
            var portifolioent = new Portifolio(portifolio.IdBanda,null, portifolio.Descricao);

            Portifolio.Save(portifolioent);

            foreach (FotoDTO foto in portifolio.Fotos) {
                if (!String.IsNullOrEmpty(foto.Foto))
                {
                    var arrayByte = Convert.FromBase64String(foto.Foto);
                    var fotoBanda = new FotoPortifolio(arrayByte,portifolioent.IdPortifolio);

                        FotoPortifolio.Save(fotoBanda);
                }
            }

            return new JsonResult("Portifólio Incluído!");

        }


        // GET api/values
        [HttpGet("{idbanda}/portifolio")]
        public ActionResult GetPortifolio(int idbanda)
        {
            var dados = new PortifolioRepository().GetByBanda(idbanda);
            PortifolioDTO portifolio = null;
            if (dados != null)
            {
                portifolio = new PortifolioDTO {Banda = dados.Banda,Descricao = dados.Descricao,IdPortifolio = dados.IdPortifolio,Fotos = dados.Fotos.Select(x =>new FotoDTO { Foto = Convert.ToBase64String(x.Foto), IdFoto = x.IdFoto }).ToList(),IdBanda = dados.IdBanda };
            }

           
            return Ok(portifolio);
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
