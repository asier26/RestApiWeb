using System;
using Microsoft.AspNetCore.Mvc;
using ApiWeb.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ApiWeb.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApiWebContext _context;
        private User persistUser;
        public AccessController(ApiWebContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        public IActionResult Authentication(User user)
        {
            if (IsValidUserAsync(user).Result.Value)
            {
                //introducir el token en el usuario
                var token = GenerateToken(user.UserName);
                var correct = AnadirTokenAsync(token);
                if (correct.Result) { 
                    return Ok(new { token });
                }
            }
            return NotFound();
        }
        
        private async Task<ActionResult<bool>> IsValidUserAsync(User user)
        {
            //validacion del usuario //añadir un switch arriba y devolver un numero en ver un boolean para cambiar la excepcion
            var userList = await _context.User.ToListAsync();
            foreach (var element in userList){
                if (element.UserName.Equals(user.UserName))
                {
                    if (element.State.Value && element.UserValid && element.Password.Equals(user.Password))
                    {
                        persistUser = element;
                        return true;
                    }
                    ///else forbiden();
                }
                //else NotFound();
            }
            return false;
        }
        //Añade el token al usuario en la bbdd
        private async Task<bool> AnadirTokenAsync(string token)
        {
            persistUser.Token = token;
            _context.Entry(persistUser).State = EntityState.Modified;
            try
            {
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        private string GenerateToken(string name)
        {
            //Header
            string keySecret = this._configuration.GetValue<string>("SecretKey");
            var header = new JwtHeader(
            new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(keySecret)//("oia3f€2dng8oa@asd65%dsf6m1zxep?")//(_configuration["SecretKey"])
                ),
                SecurityAlgorithms.HmacSha256)
        );

            //Claims
            var claims = new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.UniqueName, name),
            };

            //Payload
            var payload = new JwtPayload(
                issuer: "MyServer",
                audience: "MyWebApp",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1)
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
