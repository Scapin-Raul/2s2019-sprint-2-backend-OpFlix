using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Domains
{
    public class Favoritos
    {
        public int IdTitulo { get; set; }
        public Titulos Titulo { get; set; }
        public int IdUsuario { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
