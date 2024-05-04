using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Block_Game
{
    public class BlockGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        private AnimatedPlayer worker;

        private int dir = 0;

        private bool moving = false;
        

        public BlockGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D texture = Content.Load<Texture2D>("worker_sprites");
            worker = new AnimatedPlayer(texture);

    
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

 

            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                dir = 0;
                worker.Update(true, dir);
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                dir = 3;
                worker.Update(true, dir);
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                dir = 1;
                worker.Update(true, dir);
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                dir = 2;
                worker.Update(true, dir);
            }

            else
            {
                worker.Update(false, dir);
            }

            base.Update(gameTime);
           
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            worker.Draw(spriteBatch);


            base.Draw(gameTime);
        }
    }
}