using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class TituloRepository : ITituloRepository
    {
        public List<TituloViewModel> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var lista = ctx.Titulos.Include(x => x.IdCategoriaNavigation).Include(x => x.IdPlataformaNavigation).Include(x => x.IdTipoTituloNavigation).ToList();
                List<TituloViewModel> listaTitulosViewModel = new List<TituloViewModel>();
                foreach (var item in lista)
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

        public void Cadastrar(Titulos titulo)
        {
            using (OpFlixContext ctx=  new OpFlixContext())
            {
                ctx.Titulos.Add(titulo);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Titulos titulo)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Titulos tituloAtualizar = ctx.Titulos.Find(titulo.IdTitulo);
                tituloAtualizar.Nome = titulo.Nome;
                tituloAtualizar.Sinopse = titulo.Sinopse;
                tituloAtualizar.Duracao = titulo.Duracao;
                tituloAtualizar.DataLancamento = titulo.DataLancamento;
                tituloAtualizar.IdPlataforma = titulo.IdPlataforma;
                tituloAtualizar.IdCategoria = titulo.IdCategoria;
                tituloAtualizar.IdTipoTitulo = titulo.IdTipoTitulo;
                tituloAtualizar.Classificacao = titulo.Classificacao;

                ctx.Titulos.Update(tituloAtualizar);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using(OpFlixContext ctx= new OpFlixContext())
            {
                ctx.Titulos.Remove(ctx.Titulos.Find(id));
                ctx.SaveChanges();
            }
        }

        public List<TituloViewModel> FiltroData(DateTime data)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var lista = ctx.Titulos.Where(x => x.DataLancamento >= data).OrderBy(x=>x.DataLancamento).ToList();

                List<TituloViewModel> listaTitulosViewModel = new List<TituloViewModel>();
                foreach (var item in lista)
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

    }
}
