using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Block_Game
{
    internal class AnimatedPlayer
    {
        private Texture2D Texture { get; set; }
        private int height = 23;
        private int width = 19;
        private int totalFrames = 4;
        private int currentFrame = 0;
        private int direction = 0; //stores the last direction walked in
        private int currentDelay = 0;
        private int delay = 8;
        const int block = 48; //for movement
        int cur = 0; //Keeps track of how many pixels have been traversed in a move
        private int dirMul; //makes calculating when to stop moving easier
        private bool moving;
        private bool blipBlop = false;

        private Vector2 position = new Vector2(108, 108);
        private Vector2 incrementor;

        private Vector2 up = new Vector2(0, -3);
        private Vector2 down = new Vector2(0, 3);
        private Vector2 left = new Vector2(-3, 0);
        private Vector2 right = new Vector2(3, 0);



        public AnimatedPlayer(Texture2D texture)
        {
            Texture = texture;
        }

        public void Update(bool Moving, int dir)
        {
            if(!moving && Moving)
            {
                direction = dir;
                moving = true;
                switch (dir)
                {
                    case 0:
                        incrementor = down;
                        break;
                    
                    case 1:
                        incrementor = up;
                        break;

                    case 2:
                        incrementor = right;
                        break;

                    case 3:
                        incrementor = left;
                        break;
                }

            }
            if (moving)
                
            { 

                currentDelay++;
                if (currentDelay > delay)
                {
                    currentDelay = 0;
                    currentFrame++;
                }

                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                blipBlop = !blipBlop;
                if (blipBlop)
                {
                    position += incrementor;
                    cur += 3;
                    
                    if(cur == block)
                    { 
                        cur = 0;
                        moving = false;
                        
                    }
                }


            }

            else
            {
                currentFrame = 0;
            }
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, height * direction, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 57, 69);

         
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
          
        }



    }
}
