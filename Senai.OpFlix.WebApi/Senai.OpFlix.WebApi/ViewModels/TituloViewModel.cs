using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.ViewModels
{
    public class TituloViewModel
    {
        public int IdTitulo { get; set; }
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public int Duracao { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Plataforma { get; set; }
        public string Categoria { get; set; }
        public string TipoTitulo { get; set; }
        public string Classificacao { get; set; }
    }
}
