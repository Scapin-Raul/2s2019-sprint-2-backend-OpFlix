using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string path = "Data Source=.\\SqlExpress; initial catalog=M_OpFlix; User Id=sa; Pwd=132";

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var user = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (user == null) return null;
                return user;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
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
            
        public void AdicionarFavorito(int IdTitulo, int IdUsuario)
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
        
    }
}
