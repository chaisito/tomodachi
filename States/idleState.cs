using System;
using tomodachi.Engine;
using tomodachi.Entities;

namespace tomodachi.States
{
    public class IdleState : ipokemonState
    {
        private double timeLeft;

        public void Enter(Pokemon pokemon)
        {
            pokemon.Animator.Play(pokemon.Idle);
            timeLeft = 2000;
        }
        
        public void Update(Pokemon pokemon, double deltaTime)
        {
            if (pokemon.ShouldBeSleeping())
            {
                pokemon.ChangeState(new SleepState());
                return;
            }

            timeLeft -= deltaTime;

            if (timeLeft <= 0)
            {
                pokemon.ChangeState(randomStateSelector.GetNextState());
            }
        }

        public void Exit(Pokemon pokemon)
        {
        }
    }
}