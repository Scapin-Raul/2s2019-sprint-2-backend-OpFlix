using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IPlataformaRepository
    {
        /// <summary>
        ///  Cadastra uma Plataforma no banco de dados.
        /// </summary>
        /// <param name="plataforma">Plataforma recebida para ser cadastrada</param>
        void Cadastrar(Plataformas plataforma);

        /// <summary>
        /// Lista as Plataformas registradas do BD
        /// </summary>
        /// <returns>Retorna um lista com todas as Plataformas</returns>
        List<PlataformaViewModel> Listar();
        
        /// <summary>
        /// Atualiza uma Plataforma
        /// </summary>
        /// <param name="plataforma">Recebe a plataforma com as informações à serem atualizadas</param>
        void Atualizar(Plataformas plataforma);
    }
}
