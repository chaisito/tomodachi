using System.Collections.Generic;

namespace tomodachi.Engine
{
    public class Animation
    {
        public List<SpriteFrame> Frames { get; }
        public int FrameDuration { get; }
        public bool Loop { get; }

        public Animation(List<SpriteFrame> frames, int frameDuration, bool loop = true)
        {
            Frames = frames;
            FrameDuration = frameDuration;
            Loop = loop;
        }
    }
}