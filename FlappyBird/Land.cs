using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class Land : SpriteAnimation
    {
        public Land(string linkFile, int frameWidth, int frameHeight)
            : base(frameWidth, frameHeight)
        {
            this._linkFile = linkFile;
            this._rotation = 0f;
            this._center = Vector2.Zero;
            this._velocity = new Vector2(0, 3);
        }

        public override void loadContent(RenderContext renderContext)
        {
            base.loadContent(renderContext);
            this._position = new Vector2(renderContext.graphicsDevice.Viewport.Width - this._width, 0);

            // Draw Sprites's bounds
            bound = new Rectangle((int)_position.X, (int)_position.Y, _frameWidth, _frameHeight);
            //pixel = new Texture2D(renderContext.graphicsDevice, 1, 1);
            //pixel.SetData<Color>(new[] { Color.Black });
        }

        //public override void Draw(RenderContext renderContext)
        //{
        //    base.Draw(renderContext);
        //    // Draw Sprites's bounds
        //    renderContext.spriteBatch.Draw(pixel, bound, Color.White);
        //}

        public override void Update(RenderContext renderContext)
        {
            scrollSprite(renderContext);
        }
    }
}
