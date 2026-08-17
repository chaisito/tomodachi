using System;
using System.Collections.Generic;
using tomodachi.Engine;

namespace tomodachi.Engine
{
    public class Animator
    {
        private Animation? currentAnimation;

        private int currentFrameIndex = 0;
        private double elapsedTime = 0;

        public SpriteFrame CurrentFrame =>
            currentAnimation!.Frames[currentFrameIndex];

        public void Play(Animation animation)
        {
            if (currentAnimation == animation)
                return;

            currentAnimation = animation;
            currentFrameIndex = 0;
            elapsedTime = 0;
        }

        public void Update(double deltaTime)
        {
            if (currentAnimation == null)
                return;

            elapsedTime += deltaTime;

            if (elapsedTime < currentAnimation.FrameDuration)
                return;

            elapsedTime = 0;

            currentFrameIndex++;

            if (currentFrameIndex >= currentAnimation.Frames.Count)
            {
                if (currentAnimation.Loop)
                    currentFrameIndex = 0;
                else
                    currentFrameIndex = currentAnimation.Frames.Count - 1;
            }
        }
    }
}