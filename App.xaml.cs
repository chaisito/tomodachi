using System;
using System.Linq;
using System.Windows;
using tomodachi.Engine;
using tomodachi.Entities;

namespace tomodachi
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                base.OnStartup(e);

    SpeciesDatabase.Load();

                var configWindow = new InitialConfigWindow();

                if (configWindow.ShowDialog() != true)
                {
                    Shutdown();
                    return;
                }

                var pool = configWindow.Config.RandomStarter
                    ? SpeciesDatabase.All.Where(s => s.starter).ToList()
                    : SpeciesDatabase.All
                        .Where(s => s.starter && s.gen == configWindow.Config.Generation)
                        .ToList();

                MessageBox.Show($"Pool size: {pool.Count}");

                PokemonSpecies starter;

                if (configWindow.Config.RandomStarter)
                {
                    starter = pool[Random.Shared.Next(pool.Count)];
                }
                else
                {
                    var selection = new PokemonSelection(pool);

                    if (selection.ShowDialog() != true || selection.SelectedSpecies == null)
                    {
                        Shutdown();
                        return;
                    }

                    starter = selection.SelectedSpecies;
                }

                var mainWindow = new MainWindow(starter);

                MainWindow = mainWindow;
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Startup exception");
            }
        }

    }
}
