using DataLayer;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpleadosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private IConfiguration _config;
        public UsuarioController(IConfiguration config)
        {
            _config = config;
        }
        // POST api/<UsuarioController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] Usuario value)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(value);
            if (user!=null)
            {
                var tokenString = GenerateJSONWebToken(value);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
        private object GenerateJSONWebToken(Usuario user)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
                );
            var credentials = new SigningCredentials(
                securityKey,SecurityAlgorithms.HmacSha256
                );
            IdentityModelEventSource.ShowPII = true;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.PrimarySid,user.IdUsuario.ToString()),
                new Claim(ClaimTypes.Email,user.Usuario1),
                new Claim(ClaimTypes.Role,"1")
            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires:DateTime.Now.AddMinutes(120),
                signingCredentials:credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private Usuario AuthenticateUser(Usuario login)
        {
            var result =  new UsuarioDAL().SelectCommand(login.Usuario1, login.Password);
            return result;
        }
    }
}
