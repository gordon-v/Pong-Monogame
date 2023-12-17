using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong
{
    internal class AI
    {
        public Bar bar { set; get; }
        public Ball ball { set; get; }

        public AI(Bar bar, Ball ball)
        {
            this.bar = bar;
            this.ball = ball;
        }

        public void play(float f, GraphicsDeviceManager graphics)
        {
            if (ball.getPosition().Y < bar.Position.Y)
            {
                bar.moveUp(f);
            }
            else if(ball.getPosition().Y > bar.Position.Y-bar.barTexture.Height/2)
            {
               bar.moveDown(f,graphics);
            }
        }
    }
}
