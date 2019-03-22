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
    class Saint
    {
        public int X, Y, size, speedY, speedX;
        public bool invicblity;
        //Move Method is Needed
        public Saint(int _X, int _Y, int _size, int _speedX, int _speedY)
        {
            X = _X;
            Y = _Y;
            size = _size;
            speedY = _speedY;
            speedX = _speedX;

        }
        public void Invincible(bool _invicblity)
        {
            invicblity = _invicblity;
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
        public bool Collsion(Witch MC, Saint MC2,int height, int width)
        {
            Rectangle rec1 = new Rectangle(MC.X, MC.Y, MC.size, MC.size);
            Rectangle rec2 = new Rectangle(MC2.X, MC2.Y, MC2.size, MC2.size);
           //Witch Collsion
            if (MC.Y <= 0)
            { 
                MC.Y += 4;
            }         
            if (MC.Y >= height - MC.size)
            {
                MC.Y -= 4;
            }
            if (MC.X >= width - MC.size)
            {
                MC.X -= 4;
            }
            if (MC.X < 0)
            {
                MC.X += 4;
            }
            //Saint Collsion
            if (MC2.Y <= 0)
            {
                MC2.Y += 4;
            }
            if (MC2.Y >= height - MC2.size)
            {
                MC2.Y -= 4;
            }
            if (MC2.X >= width - MC2.size)
            {
                MC2.X -= 4;
            }
            if (MC2.X < 0)
            {
                MC2.X += 4;
            }
            if (rec2.IntersectsWith(rec1) && invicblity == false)
            {
                return true;
            }
            else
            {
                return false;
            }     
        }
    }
}

