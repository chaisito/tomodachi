using tomodachi.Engine;
using tomodachi.Entities;
using tomodachi.States;
using static tomodachi.Entities.Pokemon;

namespace tomodachi.Entities
{
    public class Pokemon
    {
        public PokemonSpecies Species { get; }

        public Animator Animator { get; } = new Animator();

        public double X { get; set; }
        public double Y { get; set; }

        public double Width => Species.frameWidth *2;
        public double Height => Species.frameHeight *2;

        public Animation Idle => AnimationLibrary.Idle;
        public Animation Walk => AnimationLibrary.Walk;
        public Animation Sleep => AnimationLibrary.Sleep;
        public Animation Wake => AnimationLibrary.Wake;

        public ipokemonState? CurrentState { get; private set; }

        private readonly int sleepOffsetMinutes =
    Random.Shared.Next(-45, 46);

        public Pokemon(PokemonSpecies species)
        {
            Species = species;
            ChangeState(new IdleState());
        }

        public bool ShouldBeSleeping()
        {
            DateTime shifted = WorldClock.Now.AddMinutes(-sleepOffsetMinutes);

            bool day = shifted.Hour >= 6 && shifted.Hour < 20;

            return Species.activityPattern switch
            {
                ActivityPattern.Diurnal => !day,
                ActivityPattern.Nocturnal => day,
                _ => false
            };
        }

        public void ChangeState(ipokemonState newState)
        {
            CurrentState?.Exit(this);
            CurrentState = newState;
            CurrentState.Enter(this);
        }

        public void Update(double deltaTime)
        {
            CurrentState?.Update(this, deltaTime);
            Animator.Update(deltaTime);
        }

        public enum FacingDirection
        {
            Left,
            Right
        }
        public FacingDirection Facing { get; set; } = FacingDirection.Left;

        public enum ActivityPattern
        {
            Diurnal,      
            Nocturnal,   
            Crepuscular
        }
        public ActivityPattern activityPattern { get; set; } = ActivityPattern.Diurnal;

    }
}   
