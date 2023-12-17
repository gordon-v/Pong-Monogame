using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    internal class BoundsChecker
    {
        public void checkBounds(GraphicsDeviceManager _graphics, Vector2 pos, Texture2D texture)
        {
            if (pos.X > _graphics.PreferredBackBufferWidth - texture.Width / 2)
            {
                pos.X = _graphics.PreferredBackBufferWidth - texture.Width / 2;
            }
            else if (pos.X < texture.Width / 2)
            {
                pos.X = texture.Width / 2;
            }

            if (pos.Y > _graphics.PreferredBackBufferHeight - texture.Height / 2)
            {
                pos.Y = _graphics.PreferredBackBufferHeight - texture.Height / 2;
            }
            else if (pos.Y < texture.Height / 2)
            {
                pos.Y = texture.Height / 2;
            }
        }
    }
}
