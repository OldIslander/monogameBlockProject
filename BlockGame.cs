using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using SharpDX.Direct3D9;
using System;

namespace Block_Game
{
    public class BlockGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        private AnimatedPlayer worker;
        private waterTile water;

        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;

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
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 960;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _tiledMap = Content.Load<TiledMap>("testLevel");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);

            Texture2D waterTexture = Content.Load<Texture2D>("water_sprites");
            water = new waterTile(waterTexture, 24); 
            
            Texture2D workerTexture = Content.Load<Texture2D>("worker_sprites");
            worker = new AnimatedPlayer(workerTexture);



    
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

            water.Update();

            _tiledMapRenderer.Update(gameTime);

            base.Update(gameTime);
           
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            spriteBatch.Begin(SpriteSortMode.Deferred,null,Microsoft.Xna.Framework.Graphics.SamplerState.PointClamp, null,null,null,null);

            Rectangle sourceRectangle = new Rectangle(32 * water.frame, 0, 16, 16);


            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    spriteBatch.Draw(water.waterTexture, new Rectangle((48 * x), (48 * y), 48, 48), sourceRectangle, Color.White);
                }
            }


            
            


            spriteBatch.End();

            _tiledMapRenderer.Draw();
           
            worker.Draw(spriteBatch);



            base.Draw(gameTime);
        }
    }
}