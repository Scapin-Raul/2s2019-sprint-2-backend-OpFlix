﻿using System;
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
    public class PlataformasController : ControllerBase
    {

        public IPlataformaRepository PlataformaRepository { get; set; }

        public PlataformasController()
        {
            PlataformaRepository = new PlataformaRepository();
        }

        /// <summary>
        /// Registra uma plataforma no BD, há de estar logado como admin para realizar tal função
        /// </summary>
        /// <param name="plataforma">Recebe uma plataforma para registra-la</param>
        /// <returns>Caso haja sucesso no registro retorna Ok, caso não, retorna BadRequest</returns>
        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataforma)
        {
            try
            {
                PlataformaRepository.Cadastrar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro " + ex });
            }

        }

        /// <summary>
        /// Lista as Plataformas registradas no BD, há de estar logado como admin para realizar tal função
        /// </summary>
        /// <returns>Retorna um lista com todas as Plataformas</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformaRepository.Listar());
        }

        /// <summary>
        /// Atualiza os dados de uma Plataforma, há de estar logado como admin para realizar tal função
        /// </summary>
        /// <param name="plataforma">Recebe a plataforma com os dados à serem atualizadas</param>
        /// <param name="id">Recebe o Id da plataforma à ser alterada</param>
        /// <returns>Caso haja sucesso no registro retorna Ok, caso não, retorna BadRequest</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(Plataformas plataforma, int id)
        {
            plataforma.IdPlataforma = id;
            try
            {
                PlataformaRepository.Atualizar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro " + ex });
            }
        }

    }
}