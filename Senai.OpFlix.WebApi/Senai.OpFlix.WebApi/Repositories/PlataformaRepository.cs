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
    public class PlataformaRepository : IPlataformaRepository
    {
        
        public void Cadastrar(Plataformas plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Plataformas.Add(plataforma);
                ctx.SaveChanges();
            }
        }

        public List<PlataformaViewModel> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var lista = ctx.Plataformas.ToList();
                List<PlataformaViewModel> plataformaViewModel = new List<PlataformaViewModel>();
                foreach (var item in lista)
                {
                    PlataformaViewModel plataforma = new PlataformaViewModel
                    {
                        IdPlataforma = item.IdPlataforma,
                        Nome = item.Nome
                    };
                    plataformaViewModel.Add(plataforma);
                }
                return plataformaViewModel;
            }
        }

        public void Atualizar(Plataformas plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataformas plataformaAtualizar = ctx.Plataformas.Find(plataforma.IdPlataforma);
                plataformaAtualizar.IdPlataforma = plataforma.IdPlataforma;
                plataformaAtualizar.Nome = plataforma.Nome;

                ctx.Plataformas.Update(plataformaAtualizar);
                ctx.SaveChanges();
            }
        }

        public List<TituloViewModel> TitulosDePlataforma(string nome)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var Plataforma = ctx.Plataformas.FirstOrDefault(x => x.Nome.ToLower().Contains(nome.ToLower()));
                List<Titulos> ListaDeTitulos;


                try
                {
                    ListaDeTitulos = ctx.Titulos.Where(x => x.IdPlataforma == Plataforma.IdPlataforma).ToList();
                }
                catch (Exception)
                {
                    return null;
                }

                List<TituloViewModel> listaTitulosViewModel = new List<TituloViewModel>();
                foreach (var item in ListaDeTitulos)
                {
                    TituloViewModel tituloViewModel = new TituloViewModel
                    {
                        IdTitulo = item.IdTitulo,
                        Nome = item.Nome,
                        Sinopse = item.Sinopse,
                        Duracao = Convert.ToInt32(item.Duracao),
                        DataLancamento = Convert.ToDateTime(item.DataLancamento),
                        Classificacao = item.Classificacao,
                        Plataforma = ctx.Plataformas.Find(item.IdPlataforma).Nome,
                        Categoria = ctx.Categorias.Find(item.IdPlataforma).Nome,
                        TipoTitulo = ctx.TiposTitulos.Find(item.IdTipoTitulo).Tipo
                    };
                    listaTitulosViewModel.Add(tituloViewModel);
                }
                return listaTitulosViewModel;
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Plataformas.Remove(ctx.Plataformas.Find(id));
                ctx.SaveChanges();
            }
        }

    }
}
