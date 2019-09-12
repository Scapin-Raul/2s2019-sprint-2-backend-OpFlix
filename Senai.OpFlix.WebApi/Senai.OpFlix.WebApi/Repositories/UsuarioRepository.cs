﻿using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        Hash hash = new Hash(SHA512.Create());

        private string path = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix; User Id=sa; Pwd=132";

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            login.Senha = hash.CriptografarSenha(login.Senha);

            using (OpFlixContext ctx = new OpFlixContext())
            {
                var user = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (user == null) return null;
                return user;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            usuario.Senha = hash.CriptografarSenha(usuario.Senha);
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Titulos> ListarFavoritos(int id)
        {
            string query = "SELECT * FROM Favoritos WHERE IdUsuario = @Id";
            List<int> ListaIdTitulos = new List<int>();
            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("Id", id);

                    SqlDataReader sdr = cmd.ExecuteReader();
                    
                    while (sdr.Read())
                    {
                        int IdTitulo = Convert.ToInt32(sdr["IdTitulo"]);

                        ListaIdTitulos.Add(IdTitulo);
                    }
                }
            }

            using (OpFlixContext ctx = new OpFlixContext())
            {
                List<Titulos> ListaTitulos = new List<Titulos>();
                foreach (int item in ListaIdTitulos)
                {
                    ListaTitulos.Add(ctx.Titulos.Find(item));
                }
                return ListaTitulos;
            }
        }
            
        public void FavoritarOuDesfavoritar(int IdTitulo, int IdUsuario)
        {
                if(VerificarFavorito(IdTitulo, IdUsuario))
                {
                    Desfavoritar(IdTitulo, IdUsuario);
                }
                else
                {
                    Favoritar(IdTitulo, IdUsuario);
                }
        }
            
                        


        private bool VerificarFavorito (int IdTitulo, int IdUsuario)
        {
            string query = "SELECT * FROM Favoritos WHERE IdTitulo = @IdTitulo AND IdUsuario = @IdUsuario";

            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();

                List<Favoritos> favoritos = new List<Favoritos>();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("IdTitulo", IdTitulo);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        var fav = new Favoritos
                        {
                            IdTitulo = Convert.ToInt32(sdr["IdTitulo"]),
                            IdUsuario = Convert.ToInt32(sdr["IdUsuario"])
                        };
                        favoritos.Add(fav);
                    }
                    if (favoritos.Count == 0) return false;
                    return true;
                }
            }

        }

        public void Favoritar(int IdTitulo, int IdUsuario)
        {
            string query = "INSERT INTO FAVORITOS(IdTitulo,IdUsuario) VALUES(@IdTitulo,@IdUsuario)";

            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("IdTitulo", IdTitulo);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool Desfavoritar(int IdTitulo, int IdUsuario)
        {
            string query = "DELETE FAVORITOS WHERE IdTitulo = @IdTitulo AND IdUsuario = @IdUsuario";

            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("IdTitulo", IdTitulo);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }








        
    }
}
