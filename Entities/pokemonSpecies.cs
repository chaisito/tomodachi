using System.IO;
using static tomodachi.Entities.Pokemon;

namespace tomodachi.Entities
{

    public class PokemonSpecies
    {
        
        public int pokedexNum { get; set; }
        public string? name { get; set; }

        //public Array? type { get; set; }
        public int gen { get; set; }
        public bool starter { get; set; } = false;
        public ActivityPattern activityPattern { get; set; } = ActivityPattern.Diurnal;
        public int frameHeight { get; set; } = 32;
        public int frameWidth { get; set; } = 32;
        public double walkSpeed { get; set; } = 36;

        public string FolderPath { get; set; } = "";

        public string Id => $"{pokedexNum:D4}-{name}";
        public string SpritePath => $"{FolderPath}/spritesheet.png";
        public string ShinySpritePath => $"{FolderPath}/shiny-spritesheet.png";
        public string PortraitPath => $"{FolderPath}/portrait.png";

    }
}