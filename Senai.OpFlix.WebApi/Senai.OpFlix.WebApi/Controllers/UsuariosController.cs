using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }
        

        /// <summary>
        /// Cadastra um Usuario. Cliente e não logados podem cadastrar somente clientes, já Admin's podem cadastrar Admins e clientes
        /// </summary>
        /// <param name="Usuario">Recebe um usuarios com as informações para o cadastro</param>
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
           
            try
            {
                string permissao = identity.FindFirst(ClaimTypes.Role).Value;
                if (!permissao.Equals("True")) usuario.Admin = false;

            }
            catch (Exception)
            {
                usuario.Admin = false;    
            }

            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest( new { mensagem = "Ocorreu um erro "+ex});
            }
        }
    }
}