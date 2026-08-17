using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using tomodachi.Engine;
using tomodachi.Entities;

namespace tomodachi
{
    public partial class PokemonSelection : Window
    {
        public PokemonSpecies? SelectedSpecies { get; private set; }

        public PokemonSelection(IEnumerable<PokemonSpecies> species)
        {
            InitializeComponent();

            foreach (var s in species)
                SpeciesList.Items.Add(CreateCard(s));
        }

        private void LoadSpeciesCards()
        {
            try
            {
                Debug.WriteLine($"Species count: {SpeciesDatabase.All.Count}");

                foreach (var species in SpeciesDatabase.All)
                {
                    SpeciesList.Items.Add(CreateCard(species));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Selection error");
            }
        }

        private Button CreateCard(PokemonSpecies species)
        {
            string portraitPath = Path.Combine(
    Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
    species.PortraitPath);

            var image = new Image
            {
                Width = 96,
                Height = 96,
                Stretch = Stretch.UniformToFill,
                Source = File.Exists(portraitPath)
        ? new BitmapImage(new Uri(portraitPath, UriKind.Absolute))
        : null
            };

            var name = new TextBlock
            {
                Text = species.name,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 8, 0, 0)
            };

            var stack = new StackPanel();
            stack.Children.Add(image);
            stack.Children.Add(name);

            var button = new Button
            {
                Content = stack,
                Width = 140,
                Height = 160,
                Margin = new Thickness(8)
            };

            button.Click += (_, _) =>
            {
                SelectedSpecies = species;
                DialogResult = true;
            };

            return button;
        }
    }
}