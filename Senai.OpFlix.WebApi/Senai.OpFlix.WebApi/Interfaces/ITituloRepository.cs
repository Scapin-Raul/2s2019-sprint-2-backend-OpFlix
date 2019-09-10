using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ITituloRepository
    {
        /// <summary>
        /// Lista os Titulos registrados do BD
        /// </summary>
        /// <returns>Retorna um lista com todas os Titulos</returns>
        List<TituloViewModel> Listar();
        
        /// <summary>
        ///  Cadastra um Titulo no banco de dados.
        /// </summary>
        /// <param name="titulo">Titulo recebido para ser cadastrado</param>
        void Cadastrar(Titulos titulo);

        /// <summary>
        /// Atualiza um Titulo
        /// </summary>
        /// <param name="titulo">Recebe o titulo com as informações à serem atualizadas</param>
        void Atualizar(Titulos titulo);

        /// <summary>
        /// Deleta um Titulo
        /// </summary>
        /// <param name="id">Recebe o Id do titulo à ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os titulos a partir de um data.
        /// </summary>
        /// <param name="data">Recebe a da para comparar</param>
        /// <returns>Retorna uma lista de titulos</returns>
        List<TituloViewModel> FiltroData(DateTime data);
    }
}
