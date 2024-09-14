using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joke.Models;

[Table("tipo")]
public class Tipo
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string? Nome { get; set; }

    [StringLength(30)]
    public String? Cor { get; set; }
}
