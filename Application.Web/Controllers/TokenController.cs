﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;

namespace Application.Web.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody]Login login)
        {
            try
            {
                if (login != null)
                {
                    LoginRepository repo = new LoginRepository();
                    var eLogin = repo.GetByLogin(login._Login);
                    if (eLogin != null && eLogin.Senha == login.Senha)
                    {

                        var claims = new[]
                        {
                    new Claim(ClaimTypes.Name,eLogin.Usuario.Nome)
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            issuer: "tocaaqui.webservice",
                            audience: "tocaaqui.webservice",
                            claims: claims,
                            expires: DateTime.Now.AddMinutes(30),
                            signingCredentials: creds);
                        


                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        });

                    }
                    return BadRequest("Credenciais Inválidas..");
                }
                return BadRequest("Falha o usuário inserido..");
            } 
            catch (Exception ex) { throw ex; }
        }
    }
}