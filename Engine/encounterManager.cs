using tomodachi.Entities;

namespace tomodachi.Engine
{
    public class EncounterManager
    {
        private double timer;
        private readonly Random rng = new();

        public event Action<PokemonSpecies>? EncounterStarted;

        public void Update(double deltaTime)
        {
            timer += deltaTime;

            if (timer < 5000)
                return;

            timer = 0;

            if (rng.NextDouble() < 0.05)
            {
                var wild = GetRandomWildPokemon();

                if (wild != null)
                    EncounterStarted?.Invoke(wild);
            }
        }

        private PokemonSpecies? GetRandomWildPokemon()
        {
            var candidates = SpeciesDatabase.All
                .Where(s => !s.starter)
                .ToList();

            if (candidates.Count == 0)
                return null;

            return candidates[rng.Next(candidates.Count)];
        }
    }
}