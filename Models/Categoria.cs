using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EtecShop.Models;
[Table("Categoria")]
public class Categoria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Informe o Nome da Categoria")]
    [StringLength(30, ErrorMessage = "O Nome deve possuir até 30 caracteres")]
    public string Nome { get; set; }
}