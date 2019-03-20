using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Running_Balls
{
    class Witch
    {
        public int X, Y, size, speedY, speedX;
        
        //Move Method is Needed
        public Witch(int _X, int _Y, int _size,  int _speedX, int _speedY)
        {
            X = _X;
            Y = _Y;
            size = _size;
            speedY = _speedY;
            speedX = _speedX;

        }
        public void Move(string direction)
        {
            if (direction == "right")
            {
                X += speedX;
            }
            if (direction == "left")
            {
                X -= speedX;
            }
            if (direction == "up")
            {
                Y -= speedY;
            }
            if (direction == "down")
            {
                Y += speedY;            
            }
        }
        public void ShootingBalls()
        {

        }
    }
}

