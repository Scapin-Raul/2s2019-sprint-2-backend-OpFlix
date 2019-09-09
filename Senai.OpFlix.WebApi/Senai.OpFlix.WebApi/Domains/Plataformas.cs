using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Plataformas
    {
        public Plataformas()
        {
            Titulos = new HashSet<Titulos>();
        }

        public int IdPlataforma { get; set; }
        public string Nome { get; set; }

        public ICollection<Titulos> Titulos { get; set; }
    }
}
