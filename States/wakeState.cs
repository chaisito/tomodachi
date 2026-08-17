using tomodachi.Engine;
using tomodachi.Entities;

namespace tomodachi.States
{
    public class WakeState : ipokemonState
    {
        private double wakeTime;

        public void Enter(Pokemon pokemon)
        {
            pokemon.Animator.Play(pokemon.Wake);

            wakeTime = 3 * 120;
        }

        public void Update(Pokemon pokemon, double deltaTime)
        {
            wakeTime -= deltaTime;

            if (wakeTime <= 0)
            {
                pokemon.ChangeState(new IdleState());
            }
        }

        public void Exit(Pokemon pokemon)
        {
        }
    }
}