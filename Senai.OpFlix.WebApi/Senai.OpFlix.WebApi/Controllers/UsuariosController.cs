using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        /// <summary>
        /// Dá a lista de favoritos do usuário
        /// </summary>
        /// <returns>Retorna a lista de titulos favoritados pelo usuário ou uma mensagem de erro caso não haja nenhum favorito.</returns>
        [Authorize]
        [HttpGet("favoritos")]
        public IActionResult Favoritos()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int IdUsuario = Convert.ToInt32(identity.FindFirst(JwtRegisteredClaimNames.Jti).Value);

            var ListaDeFavoritos = UsuarioRepository.ListarFavoritos(IdUsuario);

            if (ListaDeFavoritos.Count == 0)
            {
                return BadRequest(new { mensagem = "Você não favoritou nenhum título" });
            }
            return Ok(ListaDeFavoritos);
        }

        /// <summary>
        /// Metodo que Favorita ou Desfavorita um titulo para um usuario
        /// </summary>
        /// <param name="id">Recebe pela url o Id do titulo à ser favoritado</param>
        /// <returns>Retorna Ok caso haja sucesso e BadRequest caso haja algum erro</returns>
        [Authorize]
        [HttpPost("favoritos/{id}")]
        public IActionResult FavoritarOuDesfavoritar(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int IdUsuario = Convert.ToInt32(identity.FindFirst(JwtRegisteredClaimNames.Jti).Value);

            try
            {
                UsuarioRepository.FavoritarOuDesfavoritar(id, IdUsuario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }




    }
}