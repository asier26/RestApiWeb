using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiWeb.Models;
using apiweb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AccessController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Authentication(User user)
        {
            //validacion del usuario //Falta añadir la conexion a la base de datos y comprobar
            if (true)//(user.UserValid)
            {
                var token = GenerateToken();
                return Ok(new { token });
            }
            //return NotFound();
        }

        private string GenerateToken()
        {
            //Header
            //var _symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretKey")));
            //var signingCredencials = new SigningCredentials(_symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            //var header = new JwtHeader(signingCredencials);
            var header = new JwtHeader(
            new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("oia3f€2dng8oa@asd65%dsf6m1zxep?")
                ),
                SecurityAlgorithms.HmacSha256)
        );


            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "aaa"),
                new Claim(ClaimTypes.Email, "aaa")
            };

            //Payload
            var payload = new JwtPayload(
                issuer: "https://localhost:44395/",
                audience: "https://127.0.0.1/",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1)
            );
            //var payload = new JwtPayload
            //(
            // "https://localhost:44395/",
            // "https://localhost:44395/",
            //claims
            // DateTime.UtcNow.AddMilliseconds(1), 
            //   DateTime.UtcNow.AddMinutes(2)
            //DateTime.Now,
            //DateTime.UtcNow.AddMinutes(2)
            //);
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
