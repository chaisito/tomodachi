using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using tomodachi.Engine;
using tomodachi.Entities;

namespace tomodachi.UI
{
    public class TrayManager : IDisposable
    {
        public TaskbarIcon TrayIcon { get; }

        public TrayManager(PokemonSpecies species)
        {
           
            TrayIcon = new TaskbarIcon
            {
                IconSource = new BitmapImage(
                    new Uri("pack://application:,,,/Assets/pokeball.ico")),

                ToolTipText = "tomodachi"
            };
            var menu = new ContextMenu();

            string pokemonName = species.name;

            var toggleItem = new MenuItem
            {
                Header = $"Hide {pokemonName}"
            };

            toggleItem.Click += (_, _) =>
            {
                var window = Application.Current.MainWindow;
                if (window == null) return;

                if (window.IsVisible)
                {
                    window.Hide();
                    toggleItem.Header = $"Show {pokemonName}";
                }
                else
                {
                    window.Show();
                    window.Activate();
                    toggleItem.Header = $"Hide {pokemonName}";
                }
            };

            menu.Items.Add(toggleItem);

            menu.Items.Add(new Separator());         

            var about = new MenuItem
            {
                Header = "About"
            };

            about.Click += (_, _) =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var window = Application.Current.MainWindow;
                    if (window != null)
                    {
                        MessageBox.Show(window, "Tomodachi, 2026 \nMade with ❤️, by chaii\n \nDedicated to:" +
                        
                            "\nCounzs" +
                            "\nJohnny" +
                            "\nKiwi" +
                            "\nSinnet" +
                            "\nTelcoMaster" +
                            "\nTomatito" +
                            "\nTowa" +
                            "\n", "About");
                    }
                }));
            };
            menu.Items.Add(about);

            var credits = new MenuItem
            {
                Header = "Credits"
            };
            credits.Click += (_, _) =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var window = Application.Current.MainWindow;
                    if (window != null)
                    {
                        MessageBox.Show(window, "Tomodachi, 2026 " +
                            "\nSpecial thanks to artists of the PMD Sprite Repository " +
                            "\nCHUNSOFT", 
                            "Credits");
                    }
                }));
            };
            menu.Items.Add(credits);

            menu.Items.Add(new Separator());

            var exit = new MenuItem
            {
                Header = "Exit"
            };

            exit.Click += (_, _) =>
            {
                Application.Current.Shutdown();
            };

            menu.Items.Add(exit);

            TrayIcon.ContextMenu = menu;
        }

        public void Dispose()
        {
            TrayIcon.Dispose();
        }
    }
}