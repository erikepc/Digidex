using Joke.Models;

namespace Joke.ViewModels;

public class HomeVM
{
    public required List<Tipo> Tipos { get; set; }
    public required List<Planeta> Planetas { get; set; }
}
