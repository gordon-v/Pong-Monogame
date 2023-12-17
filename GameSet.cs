using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong
{
    internal class GameSet
    {
        public int PointsL { set; get; }
        public int PointsR { set; get; }

        private Ball ball;

        public bool gameRunning { set; get; }

        public GameSet(Ball b) {
            PointsL = 0;
            PointsR = 0;
            this.ball = b;
            this.gameRunning= false;
        }

        public void reset(GraphicsDeviceManager _graphics)
        {
            ball.resetPosition();
            this.gameRunning = false;
        }

        public String toString()
        {
            String s = "";
            s += PointsL.ToString();
            s += " : ";
            s += PointsR.ToString();
            return s;
        }

    }
}
