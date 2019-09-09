using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class TiposTitulos
    {
        public TiposTitulos()
        {
            Titulos = new HashSet<Titulos>();
        }

        public int IdTipoTitulo { get; set; }
        public string Tipo { get; set; }

        public ICollection<Titulos> Titulos { get; set; }
    }
}
