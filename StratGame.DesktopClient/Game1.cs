using ControllerInput;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HexStrategyGame
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        readonly InputAdapter p1Control;
        Input playerOne;
        readonly TextureCollection TC;
        readonly GameStateMachine gameStateMachine;
        bool debugInfo, triggered;

        public Game1()
        {
            TC = TextureCollection.Instance;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            p1Control = new InputAdapter();
            playerOne = new Input();
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
            TC.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ToggleDebugInfo();

            playerOne = p1Control.GetInput();

            gameStateMachine.Update(playerOne);

            if (gameStateMachine.Exit == true) Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            gameStateMachine.GetArtist().Draw(_spriteBatch);

            if (debugInfo)
            {
                _spriteBatch.DrawString(TC.DebugFont, $"Direction: {playerOne.direction}", new Vector2(5, 0), Color.White);
                _spriteBatch.DrawString(TC.DebugFont, $"{gameStateMachine.GameState}", new Vector2(5, 10), Color.White);
                _spriteBatch.DrawString(TC.DebugFont, $"Confirm: {playerOne.confirm}", new Vector2(5, 20), Color.White);
                _spriteBatch.DrawString(TC.DebugFont, $"Cancel: {playerOne.cancel}", new Vector2(5, 30), Color.White);
                _spriteBatch.DrawString(TC.DebugFont, $"Next: {playerOne.next}", new Vector2(5, 40), Color.White);
                _spriteBatch.DrawString(TC.DebugFont, $"Info: {playerOne.info}", new Vector2(5, 50), Color.White);
                _spriteBatch.DrawString(TC.DebugFont, $"Menu: {playerOne.menu}", new Vector2(5, 60), Color.White);
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
