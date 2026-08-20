# tomodachi
<img width="103" height="67" alt="image" src="https://github.com/user-attachments/assets/efcda81b-6701-4554-b400-6be1b7b7c75f" />

## Intro
App made in `C#`, with the sole purpose of having literally any Pokémon you want roaming in your taskbar

## How To Use
--

# SUPPORT FOR CUSTOM CONTENT
## Adding Entities
To add any other Pokémon, form or literally anything you want. There should be a folder named as the entity, this folder shall contain its spritesheet, portrait image and a `.json` file including the general info of the entity.

### Spritesheet
The spritesheet template ~can be found in the \assets folder~. Where the required sprites, frames and directions can be found as a generic character. For the rest of the Pokémon, all spritesheets are based on PMD's artstyle. The great majority of the sprites used for this project can be found in the [PMD Sprite Repository](https://sprites.pmdcollab.org/)

<img width="256" height="256" alt="torchic-ss" src="https://github.com/user-attachments/assets/b258cec9-affb-43bf-be7e-9d15e515dfd0" />

### Portrait
Portraits are treated as the images containing the selection of your poke at the very start of the app, portrait image can be whichever image you like. However, as stated before, the aestethics of the whole project are based on the PMD's artstyle.

<img width="240" height="240" alt="Normal" src="https://github.com/user-attachments/assets/062018f1-9934-4b6d-8487-3f40905d8451" />

### Species file
This `.json` file should be named as `species.json` regardless of the entity added, when creating the entity you should take into account the following data:
```
{
    "pokedexNum": 255,
    "name": "Torchic",
    "gen": 3,
    "starter": true,
    "activityPattern": "Diurnal",
    "frameHeight": 32,
    "frameWidth": 32,
    "walkSpeed": 30
}
```
<sub>The example above shows how a Pokémon is built</sub>

After adding the complete folder with its 3 files, the app will detect it automatically and you won't need to hardcode a new entity for it to work. 
