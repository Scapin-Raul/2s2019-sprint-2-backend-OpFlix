using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
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

    }
}
