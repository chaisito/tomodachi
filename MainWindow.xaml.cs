using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.IO;
using tomodachi.Engine;
using tomodachi.Entities;
using tomodachi.UI;
using static tomodachi.Entities.Pokemon;
using System.Windows.Media;
using tomodachi.States;

namespace tomodachi
{
    public partial class MainWindow : Window
    {

        private DispatcherTimer timer;
        private Stopwatch stopwatch;
        private Pokemon pokemon;
        private BitmapImage spriteSheet;
        private TrayManager trayManager;

        private readonly PokemonSpecies species;

        private const int FrameWidth = 32;
        private const int FrameHeight = 32;

        private EncounterManager encounterManager;

        public MainWindow(PokemonSpecies selectedSpecies)
        {
            InitializeComponent();

            species = selectedSpecies;

            string fullPath = Path.Combine(
                Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
                species.SpritePath);

            pokemon = new Pokemon(species);

            timer = new DispatcherTimer();
            stopwatch = new Stopwatch();

            spriteSheet = new BitmapImage(new Uri(fullPath, UriKind.Absolute));

            timer.Interval = TimeSpan.FromMilliseconds(16);
            timer.Tick += GameLoop;

            stopwatch.Start();
            timer.Start();

            spawnPokemon();

            trayManager = new TrayManager(species);

            encounterManager = new EncounterManager();
            encounterManager.EncounterStarted += OnEncounterStarted;
        }

        private void GameLoop(object? sender, EventArgs e)
        {
            double deltaTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            pokemon.Update(deltaTime);

            pokemon.Y = ScreenManager.GroundY(Height);

            Left = pokemon.X;
            Top = pokemon.Y;

            DrawFrame(pokemon.Animator.CurrentFrame);

            encounterManager.Update(deltaTime);
        }

        private void DrawFrame(SpriteFrame frame)
        {
            pokesprite.LayoutTransform = new ScaleTransform(
                pokemon.Facing == FacingDirection.Left ? 2 : -2,
                2);

            int x = frame.Column * FrameWidth;
            int y = frame.Row * FrameHeight;

            if (x + FrameWidth > spriteSheet.PixelWidth ||
                y + FrameHeight > spriteSheet.PixelHeight)
            {
                MessageBox.Show(
                    $"Invalid frame ({frame.Row}, {frame.Column})\n" +
                    $"Sheet: {spriteSheet.PixelWidth}x{spriteSheet.PixelHeight}\n" +
                    $"Frame: {FrameWidth}x{FrameHeight}",
                    "Sprite bounds");

                return;
            }

            pokesprite.Source = new CroppedBitmap(
                spriteSheet,
                new Int32Rect(x, y, FrameWidth, FrameHeight));
        }

        private void spawnPokemon()
        {
            pokemon.X = Random.Shared.NextDouble() *
    (ScreenManager.WorkArea.Width - pokemon.Width);

            pokemon.Y = ScreenManager.GroundY(Height);

            Left = pokemon.X;
            Top = pokemon.Y;
        }
        protected override void OnClosed(EventArgs e)
        {
            trayManager?.Dispose();
            base.OnClosed(e);
        }

        private bool encounterActive;

        private void OnEncounterStarted(PokemonSpecies wildSpecies)
        {
            if (encounterActive)
                return;

            encounterActive = true;

            pokemon.ChangeState(new IdleState());

            MessageBox.Show($"A wild {wildSpecies.name} appeared!");

            encounterActive = false;
        }
    }
}