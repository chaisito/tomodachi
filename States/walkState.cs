using tomodachi.Engine;
using tomodachi.Entities;
using static tomodachi.Entities.Pokemon;

namespace tomodachi.States
{
    public class WalkState : ipokemonState
    {
        private double timeLeft;
        private double direction;

    public void Enter(Pokemon pokemon)
        {
            direction = Random.Shared.Next(2) == 0 ? -1 : 1;

            pokemon.Facing = direction < 0
                ? FacingDirection.Left
                : FacingDirection.Right;

            pokemon.Animator.Play(pokemon.Walk);

            timeLeft = Random.Shared.Next(1500, 4000);
        }

        public void Update(Pokemon pokemon, double deltaTime)
        {
            pokemon.X += direction * pokemon.Species.walkSpeed * deltaTime / 1000.0;

            double minX = ScreenManager.Left;
            double maxX = ScreenManager.Right - pokemon.Width;

            if (pokemon.X <= minX)
            {
                pokemon.X = minX;
                direction = 1;
                pokemon.Facing = FacingDirection.Right;
            }
            else if (pokemon.X >= maxX)
            {
                pokemon.X = maxX;
                direction = -1;
                pokemon.Facing = FacingDirection.Left;
            }

            timeLeft -= deltaTime;

            if (timeLeft <= 0)
                pokemon.ChangeState(randomStateSelector.GetNextState());
        }

        public void Exit(Pokemon pokemon)
        {
        }
    }
}
