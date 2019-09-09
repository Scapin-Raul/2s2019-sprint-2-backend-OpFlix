using System;
using System.Collections.Generic;
using System.Linq;
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
    [Authorize(Roles = "True")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        public ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriasController()
        {
            CategoriaRepository = new CategoriaRepository();
        }

        /// <summary>
        /// Registra uma categoria no BD, há de estar logado como admin para realizar tal função
        /// </summary>
        /// <param name="categoria">Recebe uma categoria para registra-la</param>
        /// <returns>Caso haja sucesso no registro retorna Ok, caso não, retorna BadRequest</returns>
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest( new { mensagem = "Ocorreu um erro "+ex});
            }

        }

        /// <summary>
        /// Lista as Categorias registradas no BD, há de estar logado como admin para realizar tal função
        /// </summary>
        /// <returns>Retorna um lista com todas as Categorias</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok( CategoriaRepository.Listar());
        }

        /// <summary>
        /// Atualiza os dados de uma Categoria, há de estar logado como admin para realizar tal função
        /// </summary>
        /// <param name="categoria">Recebe a categoria com os dados à serem atualizadas</param>
        /// <param name="id">Recebe o Id da categoria à ser alterada</param>
        /// <returns>Caso haja sucesso no registro retorna Ok, caso não, retorna BadRequest</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(Categorias categoria, int id)
        {
            categoria.IdCategoria = id;
            try
            {
                 CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro " + ex });
            }
        }

    }
}