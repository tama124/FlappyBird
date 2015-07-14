using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class Background : Sprite
    {
        public Background(string linkFile)
            : base()
        {
            this._linkFile = linkFile;
            this._position = new Vector2(0, 0);
            this._rotation = 0f;
            this._center = Vector2.Zero;
        }

        public override void loadContent(RenderContext renderContext)
        {
            base.loadContent(renderContext);

            // Draw Sprites's bounds
            bound = new Rectangle((int)_position.X, (int)_position.Y, this._width, this._height);
            //pixel = new Texture2D(renderContext.graphicsDevice, 1, 1);
            //pixel.SetData<Color>(new[] { Color.Blue });
        }

        //public override void Draw(RenderContext renderContext)
        //{
        //    base.Draw(renderContext);
        //    // Draw Sprites's bounds
        //    renderContext.spriteBatch.Draw(pixel, bound, Color.White);
        //}
    }
}
