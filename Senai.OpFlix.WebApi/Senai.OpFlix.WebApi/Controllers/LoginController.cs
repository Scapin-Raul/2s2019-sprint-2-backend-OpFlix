using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;
using Senai.OpFlix.WebApi.ViewModels;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public IUsuarioRepository UsuarioRepository { get; set; }
        
        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Efetua login, gerando um token para identificação dentro do sistema
        /// </summary>
        /// <param name="login">Recebe no Login: email e senha</param>
        /// <returns>Caso haja o usuario retorna um token com as informações necessarias para outras funcionalidades</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios Usuario = UsuarioRepository.BuscarPorEmailESenha(login);
                if (Usuario == null)
                    return NotFound(new { mensagem = "Email ou senha inválidos." });
                
                var claims = new[]
                {
                    // email
                    new Claim(JwtRegisteredClaimNames.Email, Usuario.Email),
                    // id
                    new Claim(JwtRegisteredClaimNames.Jti, Usuario.IdUsuario.ToString()),
                    // admin ou não Role >:D
                    new Claim(ClaimTypes.Role, Usuario.Admin.ToString()),
                    // admin ou não Authentication
                    new Claim(JwtRegisteredClaimNames.Sub, Usuario.Admin.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("opflix@###-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "OpFlix.WebApi",
                    audience: "OpFlix.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro." + ex.Message });
            }
        }


    }
}