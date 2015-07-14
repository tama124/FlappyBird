using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class RenderContext
    {
        public SpriteBatch spriteBatch { get; set; }
        public GraphicsDevice graphicsDevice { get; set; }
        public ContentManager contentManager { get; set; }
        public GameTime gameTime { get; set; }
    }
}
