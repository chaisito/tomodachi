using System.Windows;
using tomodachi.Entities;

namespace tomodachi
{
    public partial class InitialConfigWindow : Window
    {
        public InitialConfig Config { get; private set; } = new();

        public InitialConfigWindow()
        {
            InitializeComponent();

            GenerationBox.SelectedIndex = 0;
            GenerationBox.IsEnabled = true;

            GenerationRadio.Checked += (_, _) => GenerationBox.IsEnabled = true;
            RandomRadio.Checked += (_, _) => GenerationBox.IsEnabled = false;
        }


        private void GenerationRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (GenerationBox != null)
                GenerationBox.IsEnabled = true;
        }

        private void RandomRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (GenerationBox != null)
                GenerationBox.IsEnabled = false;
        }


        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            if (RandomRadio.IsChecked == true)
            {
                Config.RandomStarter = true;
                Config.Generation = null;
            }
            else
            {
                Config.RandomStarter = false;
                Config.Generation = GenerationBox.SelectedIndex + 1;
            }

            DialogResult = true;
        }
    }
}