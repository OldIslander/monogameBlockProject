using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Block_Game
{
    public class BlockGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private Texture2D ground;
        private Texture2D groundCorner;
        private Texture2D groundEdge;

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
            spriteBatch = new SpriteBatch(GraphicsDevice);;
            ground = Content.Load<Texture2D>("ground");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            int x = 0;
            int y = 0;
            spriteBatch.Begin();
            for(int i = 0; i< 12; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    spriteBatch.Draw(ground, new Vector2(x, y), Color.White);
                    x += ground.Width;
                }
                y+= ground.Height;
                x = 0;
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}