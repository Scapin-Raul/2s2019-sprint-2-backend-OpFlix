using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ICategoriaRepository
    {
        /// <summary>
        ///  Cadastra uma Categoria no banco de dados.
        /// </summary>
        /// <param name="categoria">Categoria recebida para ser cadastrada</param>
        void Cadastrar(Categorias categoria);

        /// <summary>
        /// Lista as Categorias registradas do BD
        /// </summary>
        /// <returns>Retorna um lista com todas as Categorias</returns>
        List<CategoriaViewModel> Listar();

        /// <summary>
        /// Atualiza uma Categoria
        /// </summary>
        /// <param name="categoria">Recebe a categoria com as informações à serem atualizadas</param>
        void Atualizar(Categorias categoria);

        /// <summary>
        /// Remove uma Plataforma do BD
        /// </summary>
        /// <param name="id">Id da plataforma à ser removida</param>
        void Deletar(int id);
    }
}
