using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Block_Game
{
    internal class AnimatedPlayer
    {
        private Texture2D Texture { get; set; }
        private int height = 22;
        private int width = 18;
        private int totalFrames = 4;
        private int currentFrame = 0;
        private int direction = 0; //stores the last direction walked in
        private int currentDelay = 0;
        private int delay = 20;


        public AnimatedPlayer(Texture2D texture)
        {
            Texture = texture;
        }

        public void Update(bool moving, int dir)
        {
            if (!moving)
            {
                currentFrame = 0;
            }

            else
            {
                direction = dir;
                currentDelay++;
                if(currentDelay == delay)
                {
                    currentFrame++;
                    if(currentFrame == totalFrames)
                    {
                        currentFrame = 0;
                    }
                    currentDelay = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, height * direction, width, height);
            Rectangle destinationRectangle = new Rectangle(240, 240, 54, 66);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }



    }
}
