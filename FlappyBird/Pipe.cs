using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlappyBird
{
    class Pipe : SpriteAnimation
    {
        public Rectangle topPipe;
        public Rectangle bottomPipe;

        public Pipe(string linkFile, Vector2 position, int frameWidth, int frameHeight)
            : base(frameWidth, frameHeight)
        {
            this._linkFile = linkFile;
            this._position = position;
            this._rotation = 0f;
            this._center = Vector2.Zero;
            this._velocity = new Vector2(0, 3);
        }

        public override void loadContent(RenderContext renderContext)
        {
            base.loadContent(renderContext);

            // Draw Sprites's bounds
            topPipe = new Rectangle((int)_position.X, (int)_position.Y, 515, _height);
            bottomPipe = new Rectangle((int)(_position.X + 685), (int)_position.Y, 515, _height);
            //pixel = new Texture2D(renderContext.graphicsDevice, 1, 1);
            //pixel.SetData<Color>(new[] { Color.Chocolate });
        }

        //public override void Draw(RenderContext renderContext)
        //{
        //    // Draw Sprites's bounds
        //    renderContext.spriteBatch.Draw(pixel, topPipe, Color.White);
        //    renderContext.spriteBatch.Draw(pixel, bottomPipe, Color.White);
        //    base.Draw(renderContext);
        //}

        public override void Update(RenderContext renderContext)
        {
            base.Update(renderContext);
            topPipe.X = (int)_position.X;
            topPipe.Y = (int)_position.Y;
            bottomPipe.X = (int)(_position.X + 685);
            bottomPipe.Y = (int)_position.Y;
        }

        public bool isOutofScreen(RenderContext renderContext)
        {
            if (_position.Y > renderContext.graphicsDevice.Viewport.Height)
            {
                return true;
            }
            return false;
        }
    }
}
