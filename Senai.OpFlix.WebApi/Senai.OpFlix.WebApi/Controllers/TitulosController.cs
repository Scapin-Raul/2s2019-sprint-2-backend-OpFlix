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
    [ApiController]
    public class TitulosController : ControllerBase
    {
        public ITituloRepository TituloRepository { get; set; }

        public TitulosController()
        {
            TituloRepository = new TituloRepository();
        }

        /// <summary>
        /// Lista os Titulos registrados no BD, há de estar logado para realizar tal função
        /// </summary>
        /// <returns>Retorna um lista com todos os Titulos</returns>
        /*[Authorize]*/
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TituloRepository.Listar());
        }


        /// <summary>
        /// Registra um titulo no BD, há de estar logado como admin para realizar tal função
        /// </summary>
        /// <param name="titulo">Recebe um titulo para registra-lo</param>
        /// <returns>Caso haja sucesso no registro retorna Ok, caso não, retorna BadRequest</returns>
        [Authorize(Roles ="True")]
        [HttpPost]
        public IActionResult Cadastrar(Titulos titulo)
        {
            try
            {
                TituloRepository.Cadastrar(titulo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest( new { mensagem = "Ocorreu um erro "+ex});
            }
        }

        /// <summary>
        /// Atualiza os dados de um Titulo, há de estar logado como admin para realizar tal função
        /// </summary>
        /// <param name="titulo">Recebe o titulo com os dados à serem atualizadas</param>
        /// <param name="id">Recebe o Id do titulo à ser alterado</param>
        /// <returns>Caso haja sucesso no registro retorna Ok, caso não, retorna BadRequest</returns>
        [Authorize(Roles = "True")]
        [HttpPut("{id}")]
        public IActionResult Alterar(Titulos titulo, int id)
        {
            titulo.IdTitulo = id;
            try
            {
                TituloRepository.Atualizar(titulo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro " + ex });
            }
        }

        /// <summary>
        /// Deleta de um Titulo, há de estar logado como admin para realizar tal função
        /// </summary>
        /// <param name="id">Recebe o Id do titulo à ser alterado</param>
        /// <returns>Caso haja sucesso no registro retorna Ok, caso não, retorna BadRequest</returns>
        [Authorize(Roles = "True")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                TituloRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro " + ex });
            }
        }

        /// <summary>
        /// Método que lista todos os titulos a partir de uma data
        /// </summary>
        /// <param name="data">Recebe uma data inserida pela URL</param>
        /// <returns>Retorna a lista de titulos ou BadRequest caso a data esteja mal formatada</returns>
        //[Authorize]
        [HttpGet("data/{data}")]
        public IActionResult FiltroData(string data)
        {
            DateTime DataD;
            try
            {
                DataD = Convert.ToDateTime(data);
            }
            catch (Exception) { return BadRequest(); }

            return Ok(TituloRepository.FiltroData(DataD));

        }
    }
}