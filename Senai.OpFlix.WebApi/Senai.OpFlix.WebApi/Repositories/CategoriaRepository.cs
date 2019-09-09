using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public void Cadastrar(Categorias categoria)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public List<CategoriaViewModel> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var lista = ctx.Categorias.ToList();
                List<CategoriaViewModel> categoriaViewModel = new List<CategoriaViewModel>();
                foreach (var item in lista)
                {
                    CategoriaViewModel categoria = new CategoriaViewModel
                    {
                        IdCategoria = item.IdCategoria,
                        Nome = item.Nome
                    };
                    categoriaViewModel.Add(categoria);
                }
                return categoriaViewModel;
            }
        }

        public void Atualizar(Categorias categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Categorias categoriaAtualizar = ctx.Categorias.Find(categoria.IdCategoria);
                categoriaAtualizar.IdCategoria = categoria.IdCategoria;
                categoriaAtualizar.Nome = categoria.Nome;

                ctx.Categorias.Update(categoriaAtualizar);
                ctx.SaveChanges();
            }
        }

    }
}
