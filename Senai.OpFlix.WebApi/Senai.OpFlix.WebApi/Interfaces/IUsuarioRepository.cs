using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Busca um registro de Usuario por Email e Senha
        /// </summary>
        /// <param name="login">Recebe um Login com Email e Senha</param>
        /// <returns>Caso haja algum usuario com email e senha iguais aos recebidos, retorna o Usuarios, caso não seja retorna nulo</returns>
        Usuarios BuscarPorEmailESenha(LoginViewModel login);

        /// <summary>
        ///  Cadastra um um usuario no banco de dados.
        /// </summary>
        /// <param name="usuario">Usuario recebido para ser cadastrado</param>
        void Cadastrar(Usuarios usuario);
    }
}
