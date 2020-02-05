namespace Cinema_Teste
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Filme
    {
        public int IdFilme { get; set; }

        public string Titulo { get; set; }

        [Display(Name = "Duração")]
        public string Duracao { get; set; }

        public string Ano { get; set; }

        [Display(Name = "Tipo de Mídia")]
        public string TipoDeMidia { get; set; }

        public string Elenco { get; set; }

        public string Diretor { get; set; }
    }
}
