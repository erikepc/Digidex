using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joke.Models;

[Table("planeta")]
public class Planeta
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Nome { get; set; }

    public int Idade { get; set; }

     [StringLength(200)]
    public string? Descricao { get; set; }

    [StringLength(200)]
    public string? Composicao { get; set; }

    [StringLength(200)]
    public string? Foto { get; set; }

    [Required]
    public int AdicionarTIpoId { get; set; }
    [ForeignKey("AdicionarTipoId")]
    public Tipo AdicionarTipo { get; set; }
}
