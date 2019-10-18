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

        /// <summary>
        /// Busca no BD os registros de favoritos de um usuários
        /// </summary>
        /// <returns>Retorna uma lista de titulos, os quais o usuário favoritou</returns>
        List<TituloViewModel> ListarFavoritos(int id);

        /// <summary>
        /// Registra no BD um novo Favorito ou Deleta o Favorito caso já existente
        /// </summary>
        /// <param name="IdTitulo">Id do titulo à ser favoritado</param>
        /// <param name="IdUsuario">Id do usuário que quer favoritar</param>
        void FavoritarOuDesfavoritar(int IdTitulo, int IdUsuario);
    }
}
