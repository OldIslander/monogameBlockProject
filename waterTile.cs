using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


//This just animates the water :)
namespace Block_Game
{
    public class waterTile
    {
        public Texture2D waterTexture;
        private int delay;
        private int step = 0;
        public int frame = 0;
        const int maxFrames = 7;
        
        public  waterTile(Texture2D texture, int x)
        {
            waterTexture = texture;
            delay = x;
        }

        public void Update()
        {
            step++;
            if(step == delay)
            {
                step = 0;
                frame++;
                if (frame > maxFrames)
                {
                    frame = 0;
                }
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            
            
        }
    }

 }

