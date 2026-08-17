using tomodachi.Engine;

namespace tomodachi.Engine
{
    public static class AnimationLibrary
    {
        public static Animation Idle { get; } = new Animation(
            new()
            {
                new SpriteFrame(0, 1)
            },
            220);

        public static Animation Walk { get; } = new Animation(
            new()
            {
                new SpriteFrame(1, 0),
                new SpriteFrame(1, 1),
                new SpriteFrame(1, 2),
                new SpriteFrame(1, 3),
                new SpriteFrame(1, 4),
                new SpriteFrame(1, 5)
            },
            75);

        public static Animation Sleep { get; } = new Animation(
            new()
            {
                new SpriteFrame(5, 0),
                new SpriteFrame(5, 1)
            },
            1000);

        public static Animation Wake { get; } = new Animation(
            new()
            {
                new SpriteFrame(6, 0),
                new SpriteFrame(6, 1),
                new SpriteFrame(6, 2),
                new SpriteFrame(6, 3),
                new SpriteFrame(6, 4),
                new SpriteFrame(6, 5)
            },
            300);
        /*
        public static Animation Happy { get; } = new Animation(
            new()
            {
                new SpriteFrame(4, 0),
                new SpriteFrame(4, 1)
            },
            180);

        
        public static Animation Attack { get; } = new Animation(
            new()
            {
                new SpriteFrame(5, 0),
                new SpriteFrame(5, 1),
                new SpriteFrame(5, 2),
                new SpriteFrame(5, 3)
            },
            80);

        public static Animation Hurt { get; } = new Animation(
            new()
            {
                new SpriteFrame(6, 0),
                new SpriteFrame(6, 1)
            },
            120);
        */
    }
}