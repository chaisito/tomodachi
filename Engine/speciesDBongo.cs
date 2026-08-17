using System.Collections.Generic;
using tomodachi.Entities;

namespace tomodachi.Engine
{
    public static class SpeciesDatabase
    {
        public static List<PokemonSpecies> All { get; private set; } = new();

        public static void Load()
        {
            All = SpeciesLoader.LoadAll();
        }
    }
}