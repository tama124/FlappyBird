using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    abstract class Sprite
    {
        protected string _linkFile { set; get; }
        protected Texture2D _texture { set; get; }
        protected int _width { get { return this._texture.Width; } }
        protected int _height { get { return this._texture.Height; } }
        protected Vector2 _position { set; get; }
        protected Rectangle _rentangle { set; get; }
        protected Color _color { set; get; }
        protected float _rotation { set; get; }
        protected Vector2 _center { set; get; }
        protected float _scale { set; get; }
        protected SpriteEffects _effects { set; get; }
        protected float _depth { set; get; }

        // Sprite bound to check collision
        public Rectangle bound;
        //public Texture2D pixel;

        protected Sprite()
        {
            this._color = Color.White;
            this._scale = 1.0f;
            this._effects = SpriteEffects.None;
            this._depth = 0f;
        }

        public virtual void loadContent(RenderContext renderContext)
        {
            _texture = renderContext.contentManager.Load<Texture2D>(this._linkFile);
            _rentangle = new Rectangle(0, 0, this._width, this._height);
        }

        public virtual void Draw(RenderContext renderContext)
        {
            renderContext.spriteBatch.Draw(_texture, _position, _rentangle, _color, _rotation, _center,
                _scale, _effects, _depth);
        }
    }
}
