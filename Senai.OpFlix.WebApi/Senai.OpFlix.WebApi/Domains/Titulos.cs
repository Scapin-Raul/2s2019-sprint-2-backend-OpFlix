using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Titulos
    {
        public int IdTitulo { get; set; }
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public int? Duracao { get; set; }
        [Required(ErrorMessage = "É necessario uma data de lançamento.")]
        public DateTime? DataLancamento { get; set; }
        public int? IdPlataforma { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdTipoTitulo { get; set; }
        public string Classificacao { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public Plataformas IdPlataformaNavigation { get; set; }
        public TiposTitulos IdTipoTituloNavigation { get; set; }

        public ICollection<Favoritos> Favoritos { get; set; }
    }
}
