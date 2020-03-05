using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models.Estoque
{
    public class EstoqueEdicaoViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int IdEstoque { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }
    }
}