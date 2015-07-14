using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class Bird : SpriteAnimation
    {
        private int jumpTime = 500;
        private double jumpElapsed = 0;
        private bool canJump = true;
        private float CORNER = MathHelper.Pi / 6;
        public bool isDie = false;

        public Bird(string linkFile, Vector2 position, int frameWidth, int frameHeight)
            : base(frameWidth, frameHeight)
        {
            this._linkFile = linkFile;
            this._position = position;
            this._velocity = new Vector2(0, 0);
            this._rotation = CORNER;
        }

        public override void loadContent(RenderContext renderContext)
        {
            base.loadContent(renderContext);
            this._center = new Vector2(_frameWidth / 2, _frameHeight / 2);

            // Draw Sprites's bounds
            bound = new Rectangle((int)(_position.X - _center.X), (int)(_position.Y - _center.Y), _frameWidth, _frameHeight);
            //    pixel = new Texture2D(renderContext.graphicsDevice, 1, 1);
            //    pixel.SetData<Color>(new[] { Color.Red });
        }

        //public override void Draw(RenderContext renderContext)
        //{
        //    // Draw Sprites's bounds
        //    renderContext.spriteBatch.Draw(pixel, bound, Color.White);
        //    base.Draw(renderContext);
        //}

        private void fly(RenderContext renderContext)
        {
            if (!isDie)
            {
                // Increase bird's speed
                _velocity.X += 0.2f;

                // Increase jump time
                jumpElapsed += renderContext.gameTime.ElapsedGameTime.TotalMilliseconds;

                // Check the jump time
                if (jumpElapsed > jumpTime)
                {
                    canJump = true;
                    jumpElapsed = 0;
                }

                // Check to rotate bird
                if (_velocity.X > 0)
                {
                    this._rotation = CORNER;
                }
                else
                {
                    this._rotation = -CORNER;
                }

                // Move bird
                _position += _velocity;

                // Touch event
                TouchCollection touches = TouchPanel.GetState();
                if (touches.Count > 0 && canJump)
                {
                    foreach (TouchLocation touch in touches)
                    {
                        if (touch.State == TouchLocationState.Pressed)
                        {
                            canJump = false;
                            _velocity.X = -4;
                        }
                    }
                }
            }
        }

        public bool isPassPipe(PipeList pipes)
        {
            if (pipes.pipeList.Count > 0)
            {
                Pipe pipeFirst = pipes.pipeList[0];
                for (int i = 1; i < pipes.pipeList.Count; i++)
                {
                    if (pipes.pipeList[i].topPipe.Y > pipeFirst.topPipe.Y)
                        pipeFirst = pipes.pipeList[i];
                }
                if (pipeFirst != null && bound.Y == pipeFirst.topPipe.Y)
                {
                    return true;
                }
            }
            return false;
        }

        private void checkCollision(RenderContext renderContext, Sprite land, PipeList pipes)
        {
            // Check collision with background
            if (!isDie)
            {
                // Check collision with pipe
                foreach (Pipe pipe in pipes.pipeList)
                {
                    if (pipe.topPipe.Intersects(this.bound) || pipe.bottomPipe.Intersects(this.bound))
                    {
                        // Bird die
                        isDie = true;
                        direction = 1;
                        _velocity = new Vector2(12, 0);
                        _rotation = CORNER;
                    }
                }
            }
            // Check collision with land
            if (land.bound.Intersects(this.bound))
            {
                // Bird die
                isDie = true;
                _velocity = Vector2.Zero;
            }
        }

        public override void Update(RenderContext renderContext, Land land, PipeList pipes)
        {
            fly(renderContext);
            checkCollision(renderContext, land, pipes);
            animateSprite(renderContext);
            base.Update(renderContext);
        }
    }
}
