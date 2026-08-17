namespace tomodachi.Entities
{
    public class InitialConfig
    {
        public bool RandomStarter { get; set; }

        public int? Generation { get; set; }

        public PokemonSpecies? SelectedStarter { get; set; }
    }
}