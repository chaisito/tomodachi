using tomodachi.Entities;

namespace tomodachi.Engine
{
    public interface ipokemonState
    {
        void Enter(Pokemon pokemon);
        void Update(Pokemon pokemon, double deltaTime);
        void Exit(Pokemon pokemon);
    }
}