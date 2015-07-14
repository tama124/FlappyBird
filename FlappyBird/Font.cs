using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class Font
    {
        private String _linkFile { set; get; }
        private String _text { set; get; }
        private SpriteFont _font { set; get; }
        private Vector2 _position { set; get; }
        private Color _color { set; get; }
        protected float _rotation { set; get; }
        protected Vector2 _center { set; get; }
        protected float _scale { set; get; }
        protected SpriteEffects _effects { set; get; }
        protected float _depth { set; get; }

        public Font(String linkFile, String text, Vector2 position)
        {
            this._linkFile = linkFile;
            this._text = text;
            this._position = position;
            this._color = Color.Red;
            this._rotation = (float)-MathHelper.Pi / 2;
            this._center = Vector2.Zero;
            this._scale = 2.0f;
            this._effects = SpriteEffects.None;
            this._depth = 0f;
        }

        public virtual void LoadContent(RenderContext renderContext)
        {
            this._font = renderContext.contentManager.Load<SpriteFont>(_linkFile);
        }

        public virtual void Update(String text)
        {
            _text = text;
        }

        public virtual void Draw(RenderContext renderContext)
        {
            renderContext.spriteBatch.DrawString(_font, _text, _position, _color, _rotation,
                _center, _scale, _effects, _depth);
        }
    }
}
