using tomodachi.Engine;
using tomodachi.Entities;

namespace tomodachi.States
{
    public class SleepState : ipokemonState
    {
        private double sleepTime;

        public void Enter(Pokemon pokemon)
        {
            pokemon.Animator.Play(pokemon.Sleep);

            sleepTime = Random.Shared.Next(3000, 8000);
        }

        public void Update(Pokemon pokemon, double deltaTime)
        {
            if (!pokemon.ShouldBeSleeping())
            {
                pokemon.ChangeState(new WakeState());
            }
        }

        public void Exit(Pokemon pokemon)
        {
        }
    }
}