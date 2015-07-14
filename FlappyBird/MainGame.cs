using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FlappyBird
{
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderContext renderContext;

        // My Sprites
        Background _background;
        Bird _bird;
        Land _land;
        PipeList _pipes;

        // Font
        Font _font;
        int scope;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.Portrait;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Create all Sprites objects
            renderContext = new RenderContext();
            scope = 0;
            _background = new Background("Background");
            _bird = new Bird("Bird", new Vector2(50, 350), 50, 79);
            _land = new Land("Land", 142, this.GraphicsDevice.Viewport.Height);
            _pipes = new PipeList("Pipe");
            _font = new Font("Font", scope.ToString(), new Vector2(50, 125));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Set anything to class RenderContext
            spriteBatch = new SpriteBatch(GraphicsDevice);
            renderContext.spriteBatch = this.spriteBatch;
            renderContext.graphicsDevice = this.GraphicsDevice;
            renderContext.contentManager = this.Content;

            // LoadContent for all Sprites
            _background.loadContent(renderContext);
            _bird.loadContent(renderContext);
            _land.loadContent(renderContext);
            _font.LoadContent(renderContext);
        }

        protected override void UnloadContent() { }

        private bool isMessageBoxShow = false;

        protected override void Update(GameTime gameTime)
        {
            // Exit when press back button
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Set game time to class RenderContext
            renderContext.gameTime = gameTime;

            // Update for all Sprites
            //_bird.Update(renderContext, _land, _pipes);
            _bird.Update(renderContext, _land, _pipes);
            if (!_bird.isDie)
            {
                _land.Update(renderContext);
                _pipes.Update(renderContext);
            }
            else
            {
                if (!this.isMessageBoxShow)
                {
                    this.isMessageBoxShow = true;
                    Guide.BeginShowMessageBox("Game over!", "You win " + scope.ToString() + " scope!\nDo you want to play my fucking game again?",
                        new string[] { "Yes", "No" }, 1, MessageBoxIcon.Warning, new AsyncCallback(this.userSelected), null);
                }
            }

            // Update player's scope
            if (_bird.isPassPipe(_pipes))
            {
                scope++;
                _font.Update(scope.ToString());
            }

            base.Update(gameTime);
        }

        private void userSelected(IAsyncResult result)
        {
            this.isMessageBoxShow = false;

            if (!result.IsCompleted)
                return;

            int? index = Guide.EndShowMessageBox(result);

            if (index.HasValue && index.Value == 0)
            {
                try
                {
                    this.Initialize();
                    this.LoadContent();
                }
                catch
                {
                    Guide.BeginShowMessageBox("Error", "I'm so sorry! Something was wrong! Please exit my fucking game!",
                        new string[] { "Exit" }, 1, MessageBoxIcon.Error, new AsyncCallback(this.userSelected), null);
                }
            }
            else
            {
                this.Exit();
            }
        }

        private void exitGame(IAsyncResult result)
        {
            if (!result.IsCompleted)
                return;

            int? index = Guide.EndShowMessageBox(result);

            if (index.HasValue && index.Value == 0)
            {
                this.Exit();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            // Default color XNA
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw all Sprites to screen
            renderContext.spriteBatch.Begin();
            _background.Draw(renderContext);
            _pipes.Draw(renderContext);
            _land.Draw(renderContext);
            _bird.Draw(renderContext);
            _font.Draw(renderContext);
            renderContext.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
