using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    internal class Ball
    {
        private Texture2D Texture;
        private Vector2 Position;
        private float Speed, Xspeed, Yspeed;
        private double angle;
        public Ball(Vector2 position, float speed)
        {
            Position = position;
            Speed = speed;
            Xspeed = 1;
            Yspeed = 1;
            angle = 0.7;

        }
        public void setTexture(Texture2D texture)
        {
            Texture = texture;
        }
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position - new Vector2(Texture.Width / 2, Texture.Height / 2), Color.White);
        }
        public void move(float t)
        {
            Position.X += Speed * t * (float)Math.Sin(angle) * Xspeed;
            Position.Y += Speed * t * (float)Math.Cos(angle) * Yspeed;

        }
        public void reverseX()
        {
            Xspeed *= -1;
        }
        public void reverseY()
        {
            Yspeed *= -1;
        }
        public void checkBounds(GraphicsDeviceManager _graphics)
        {
            if (Position.X > _graphics.PreferredBackBufferWidth - Texture.Width / 2)
            {
                Position.X = _graphics.PreferredBackBufferWidth - Texture.Width / 2;
                reverseX();
            }
            else if (Position.X < Texture.Width / 2)
            {
                Position.X = Texture.Width / 2;
                reverseX();
            }

            if (Position.Y > _graphics.PreferredBackBufferHeight - Texture.Height / 2)
            {
                Position.Y = _graphics.PreferredBackBufferHeight - Texture.Height / 2;
                reverseY();
            }
            else if (Position.Y < Texture.Height / 2)
            {
                Position.Y = Texture.Height / 2;
                reverseY();
            }

            
        }

        public void collisionCheck(Vector2 posB, Texture2D texB)
        {
            Point A1 = (this.Position-new Vector2(Texture.Width/2,Texture.Height/2)).ToPoint();
            Point A2 = (this.Position+new Vector2(Texture.Width/2,Texture.Height/2)).ToPoint();

            Point B1 = (posB-new Vector2(texB.Width/2, texB.Height/2)).ToPoint();
            Point B2 = (posB + new Vector2(texB.Width / 2, texB.Height / 2)).ToPoint(); 

            //bound box collision
            if(B1.X < A2.X && B1.Y < A2.Y && B2.X > A1.X && B2.Y > A1.Y) {
                //is colliding
                this.reverseX();

            }




        }
    }
}
