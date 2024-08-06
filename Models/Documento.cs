using System.ComponentModel.DataAnnotations;

namespace WordProjetoView.Models
{

    //tabelas
    public class Documento
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Digite o Titulo")]
        public string? Titulo { get; set; } = string.Empty;


        [Required(ErrorMessage = "Digite o Conteudo")]
        public string? conteudo { get; set; } = string.Empty ;


        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
    }
}
