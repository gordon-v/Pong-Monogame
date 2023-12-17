using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    internal class Bar
    {
        private Game1 _game = null;

        public Texture2D barTexture;
        public Vector2 Position;
        private float Speed;

        public Bar(float speed)
        {
            Speed = 200f;
            
        
        }

        public Game1 Game
        {
            get { return this._game; }
            set { this._game = value; }
        }
        public void setPosition(Vector2 pos)
        {
            Position = pos;
        }
        public void setTexture (Texture2D texture)
        {
            barTexture = texture;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(barTexture, Position-new Vector2(barTexture.Width/2,barTexture.Height/2), Color.White);
        }
        public void moveDown(float t, GraphicsDeviceManager graphics)
        {           //TODO: FIX this.Game.getGraphics() from returning null
            Position.Y += Speed * t;
            if(Position.Y >graphics.PreferredBackBufferHeight - barTexture.Height / 2)
            {
                Position.Y = graphics.PreferredBackBufferHeight - barTexture.Height / 2;
            }
            
        }
        public void moveUp(float t)
        {
            Position.Y -= Speed * t;
            if(Position.Y < barTexture.Height/2)
            {
                Position.Y = barTexture.Height/2;
            }
        }

        
     
        public Texture2D getTexture()
        {
            return this.barTexture;
        }
        public Vector2 getPosition()
        {
            return this.Position;
        }
    }

}
