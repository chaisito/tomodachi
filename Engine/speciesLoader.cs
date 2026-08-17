using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using tomodachi.Entities;

namespace tomodachi.Engine
{
    public static class SpeciesLoader
    {
        public static List<PokemonSpecies> LoadAll()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };

            var result = new List<PokemonSpecies>();

            string assetsPath = Path.Combine(
    Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
    "Assets");

            Debug.WriteLine($"Scanning: {assetsPath}");
            Debug.WriteLine($"Exists: {Directory.Exists(assetsPath)}");
            
            if (!Directory.Exists(assetsPath))
                return result;

            foreach (string folder in Directory.GetDirectories(assetsPath))
            {
                string jsonPath = Path.Combine(folder, "species.json");

                Debug.WriteLine($"Checking: {jsonPath}");

                if (!File.Exists(jsonPath))
                {
                    MessageBox.Show("species.json missing");
                    continue;
                }

                try
                {
                    string json = File.ReadAllText(jsonPath);

                    Debug.WriteLine(json);

                    PokemonSpecies? species =
    JsonSerializer.Deserialize<PokemonSpecies>(json, options);

                    if (species == null)
                    {
                        MessageBox.Show("Deserialize returned null");
                        continue;
                    }

                    Debug.WriteLine($"Loaded {species.name} #{species.pokedexNum}");

                    species.FolderPath = $"Assets/{Path.GetFileName(folder)}";

                    result.Add(species);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "SpeciesLoader exception");
                }
            }

            Debug.WriteLine($"Total loaded: {result.Count}");

            return result
                .OrderBy(s => s.pokedexNum)
                .ToList();
        }
    }
}