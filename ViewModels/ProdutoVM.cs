using System.ComponentModel.DataAnnotations;
using EtecShop.Models;
namespace EtecShop.ViewModels;
public class ProdutoVM
{
    public Produto Produto { get; set; }

    public List<Avaliacao> Avaliacoes { get; set; }

    [Required(ErrorMessage = "Informe o Nome")]
    [StringLength(60, ErrorMessage = "O Nome deve possuir até 60 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o Título")]
    [StringLength(60, ErrorMessage = "O Título deve possuir até 60 caracteres")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "Escreva sua Avaliação")]
    [StringLength(300, ErrorMessage = "A Avaliação de possuir no máximo 300 caracteres")]
    public string Texto { get; set; }
}