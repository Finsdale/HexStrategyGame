using HexStrategyGame.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HexStrategyGame
{
    public class Game1 : Game
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly GraphicsDeviceManager _graphics;
#pragma warning restore IDE0052 // Remove unread private members
        private SpriteBatch _spriteBatch;
        InputAdapter inputAdapter;
        Input input;
        SpriteFont gameFont, debugFont;
        Texture2D terrainTiles;
        GameStateMachine gameStateMachine;
        bool debugInfo, triggered;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            inputAdapter = new InputAdapter();
            input = new Input();
            gameStateMachine = new GameStateMachine();
            debugInfo = triggered = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gameFont = Content.Load<SpriteFont>("GameFont");
            debugFont = Content.Load<SpriteFont>("DebugFont");
            terrainTiles = Content.Load<Texture2D>("test_tiles");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ToggleDebugInfo();

            input = inputAdapter.GetInput();

            gameStateMachine.Update(input);

            if (gameStateMachine.Exit == true) Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            gameStateMachine.GetArtist().Draw(_spriteBatch, gameFont, terrainTiles);

            if (debugInfo)
            {
                _spriteBatch.DrawString(debugFont, $"Direction: {input.direction}", new Vector2(5, 0), Color.White);
                _spriteBatch.DrawString(debugFont, $"{gameStateMachine.GameState}", new Vector2(5, 10), Color.White);
                _spriteBatch.DrawString(debugFont, $"Confirm: {input.confirm}", new Vector2(5, 20), Color.White);
                _spriteBatch.DrawString(debugFont, $"Cancel: {input.cancel}", new Vector2(5, 30), Color.White);
                _spriteBatch.DrawString(debugFont, $"Next: {input.next}", new Vector2(5, 40), Color.White);
                _spriteBatch.DrawString(debugFont, $"Info: {input.info}", new Vector2(5, 50), Color.White);
                _spriteBatch.DrawString(debugFont, $"Menu: {input.menu}", new Vector2(5, 60), Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        void ToggleDebugInfo()
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.F1) && !triggered)
            {
                debugInfo = !debugInfo;
                triggered = true;
            }
            else if (ks.IsKeyUp(Keys.F1) && triggered)
            {
                triggered = false;
            }
        }
    }
}
