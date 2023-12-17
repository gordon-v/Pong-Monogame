using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private bool gameStarted = false;
        //textures

        Ball ball;
        Bar Left, Right;

        BoundsChecker boundsChecker;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            
            //_graphics.ToggleFullScreen();
            // TODO: Add your initialization logic here
            ball = new Ball(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), 500f);

            Left = new Bar(200f);
            Right = new Bar(200f);

            Left.setPosition(new Vector2(60, _graphics.PreferredBackBufferHeight / 2));
            Right.setPosition(new Vector2(_graphics.PreferredBackBufferWidth - 40, _graphics.PreferredBackBufferHeight / 2));

            boundsChecker = new BoundsChecker();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Left.setTexture(Content.Load<Texture2D>("bar"));
            Right.setTexture(Content.Load<Texture2D>("bar"));
            ball.setTexture(Content.Load<Texture2D>("ball"));

        }

        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                gameStarted = true;
            }

            if (gameStarted)
            {
                ball.move((float)gameTime.ElapsedGameTime.TotalSeconds);
                ball.checkBounds(_graphics);
                ball.collisionCheck(Left.getPosition(), Left.getTexture());
                ball.collisionCheck(Right.getPosition(), Right.getTexture());
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    Left.moveUp((float)gameTime.ElapsedGameTime.TotalSeconds, _graphics);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    Left.moveDown((float)gameTime.ElapsedGameTime.TotalSeconds, _graphics);
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    Right.moveUp((float)gameTime.ElapsedGameTime.TotalSeconds, _graphics);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    Right.moveDown((float)gameTime.ElapsedGameTime.TotalSeconds, _graphics);
                }
                //check if out of bounds

                //boundsChecker.checkBounds(_graphics, barLPos, barL);


                // TODO: Add your update logic here
            }
                base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            ball.draw(_spriteBatch);
            // _spriteBatch.Draw(kiwiTexture, _kiwiPosition, Color.White);
            Left.draw(_spriteBatch);
            Right.draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}