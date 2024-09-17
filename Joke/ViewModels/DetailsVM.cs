namespace Joke.ViewModels
{
    public class DetailsVM
    {
        // Planeta Atual
        public PlanetaVM Atual { get; set; }

        // Próximo e Anterior (Navegação entre os planetas)
        public PlanetaVM Anterior { get; set; }
        public PlanetaVM Proximo { get; set; }
    }

    public class PlanetaVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Idade { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public string Composicao { get; set; }

        // Tipo do planeta
        public TipoVM AdicionarTipo { get; set; }
    }

    public class TipoVM
    {
        public string Nome { get; set; }
        public string Cor { get; set; }
    }
}
