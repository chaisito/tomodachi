using tomodachi.Engine;

namespace tomodachi.States
{
    public static class randomStateSelector
    {
        public static ipokemonState GetNextState()
        {
            int roll = Random.Shared.Next(100);

            if (roll < 90)
                return new WalkState();

            return new IdleState();
        }
    }
}