using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joke.Models;

[Table("planets")]
public class Planets
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nome { get; set; }

    public int Idade { get; set; }

     [StringLength(200)]
    public string Descricao { get; set; }

    public int Distancia { get; set; }

    [StringLength(200)]
    public string Composicao { get; set; }

    [StringLength(200)]
    public string Imagem { get; set; }

    [Required]
    public int AdicionarTipoId { get; set; }
    [ForeignKey("adicionarTipoId")]
    public Tipo AdicionarTipo {get; set;}
}
