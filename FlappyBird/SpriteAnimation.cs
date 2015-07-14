using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlappyBird
{
    abstract class SpriteAnimation : Sprite
    {
        protected Vector2 _velocity;
        private float INTERVAL = 50;
        private float timer;
        private int currentFrame = 0;
        private int scroller = 0;
        protected int direction = 1;
        protected int _frameWidth { set; get; }
        protected int _frameHeight { set; get; }

        protected SpriteAnimation(int frameWidth, int frameHeight)
            : base()
        {
            this._frameWidth = frameWidth;
            this._frameHeight = frameHeight;
        }

        protected void animateSprite(RenderContext renderContext)
        {
            _rentangle = new Rectangle(0, currentFrame * _frameHeight, _frameWidth, _frameHeight);
            timer += (int)renderContext.gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > INTERVAL)
            {
                currentFrame++;
                timer = 0;
                if (currentFrame > 2)
                {
                    currentFrame = 0;
                }
            }
        }

        protected void scrollSprite(RenderContext renderContext)
        {
            _rentangle = new Rectangle(0, scroller, _frameWidth, _frameHeight);
            scroller += (int)_velocity.Y;
            if (scroller > _height / 2)
            {
                scroller = 0;
            }
        }

        public virtual void Update(RenderContext renderContext)
        {
            _position += _velocity * direction;
            bound.X = (int)(_position.X - _center.X);
            bound.Y = (int)(_position.Y - _center.Y);
        }

        public virtual void Update(RenderContext renderContext, Land land, PipeList pipes)
        {
            _position += _velocity * direction;
            bound.X = (int)(_position.X - _center.X);
            bound.Y = (int)(_position.Y - _center.Y);
        }
    }
}
