using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Running_Balls
{
    public partial class gameScreen : UserControl
    {   //Timer For Ablitys        
        int ablityTimerWitch = 0;
        int ablityUsedWitch = 0;
        int ablityUsedSaint = 0;
        int ablityTimerSaint = 0;
        //Invciblity Variables to send off
        public static int invicblityInt = 0;       
        //Evil Person List
        List<Witch> witchList = new List<Witch>();
        List<Saint> saintList = new List<Saint>();
        List<Ball> ballList = new List<Ball>();
        //Movement Keys/Any Kind of Bool Variable Used
        public bool leftArrowDown, rightArrowDown, upArrowDown, downArrowDown, aLetterDown, sLetterDown, dLetterDown, wLetterDown,
        cLetterDown, bLetterDown;
        bool shoot = false, invicblity = false;
        // public static bool invicblity = invicblity2;    
        //Drawing Variables
        SolidBrush witchBrush = new SolidBrush(Color.Crimson);
        SolidBrush saintBrush = new SolidBrush(Color.Aqua);
        SolidBrush ballBrush = new SolidBrush(Color.Black);
        //Witch Variables
        static int witchX = 408, witchY = 144, witchSize = 30, witchSpeed = 4;
        //Saint Variables
        static int saintX = 408, saintY = 244, saintSize = 30, saintSpeed = 4;
        //Ball Variables
        static int ballSize = 10, ballSpeed = 8;
        //Creating the objects to add to the list
        Witch MC = new Witch(witchX, witchY, witchSize, witchSpeed, witchSpeed);
        Saint MC2 = new Saint(saintX, saintY, saintSize, saintSpeed, saintSpeed);
        Ball ball1 = new Ball(witchX, witchY, ballSize, ballSpeed, ballSpeed);
        public gameScreen()
        {
            InitializeComponent();
            //Adding to the the List
            witchList.Add(MC);
            saintList.Add(MC2);
            ballList.Add(ball1);
            Form1.stopWatch.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        { 

            label1.Text = Convert.ToString(Form1.stopWatch.Elapsed.Seconds);
            label2.Text = Convert.ToString(MC.X);

            if (Form1.stopWatch.Elapsed.Seconds == Form1.stopTimeTimer || (MC2.Collsion(MC, MC2, this) == true))
            {
                gameTimer.Stop();
                Form1.stopWatch.Stop();
                Form f = this.FindForm();
                f.Controls.Remove(this);
                EndGame Sc = new EndGame();
                f.Controls.Add(Sc);
            }          
            if((ball1.Collsion(MC, MC2, this, ball1) == true))
            {
                gameTimer.Stop();
                Form1.stopWatch.Stop();
                Form f = this.FindForm();
                f.Controls.Remove(this);
                EndGame Sc = new EndGame();
                f.Controls.Add(Sc);
            }
            //Moving Witch
            foreach (Witch MC in witchList)
            {
                if(leftArrowDown == true)
                {
                    MC.Move("left");   
                }
                 if(rightArrowDown == true)
                {
                    MC.Move("right");
                }
                if (upArrowDown == true)
                {
                    MC.Move("up");
                }
                if (downArrowDown == true)
                {
                    MC.Move("down");
                }
                bif (bLetterDown == true && ablityTimerWitch ==0 && ablityUsedWitch < 4)
                {
                    if(ablityUsedWitch != 4)
                    {
                        ablityUsedWitch++;
                    }
                    ablityTimerWitch++;                    
                    shoot = true;
                    ball1.Move();
                }
                if(ablityTimerWitch < 200 && !(ablityTimerWitch == 0))
                {
                    ablityTimerWitch++;
                    ball1.Move();
                }
                if(ablityTimerWitch >= 200)
                    {
                        ablityTimerWitch = 0;
                        shoot = false;
                    bLetterDown = false;
                    }
                if (shoot == false)
                {
                    ball1.WitchPostion(MC.X, MC.Y);
                }
            }
            //Moving Saint
            foreach (Saint MC2 in saintList)
            {
                if (aLetterDown == true)
                {
                    MC2.Move("left");
                }
                if (dLetterDown == true)
                {
                    MC2.Move("right");
                }
                if (wLetterDown == true)
                {
                    MC2.Move("up");
                }
                if (sLetterDown == true)
                {
                    MC2.Move("down");
                }
                if(cLetterDown == true && !(ablityUsedSaint == 4))
                {
                    ablityUsedSaint++;
                    invicblity = true;                  
                    MC2.Invincible(invicblity);
                }
                if (invicblity == true)
                {
                    ablityTimerSaint++;
                    ball1.Invicblity(invicblity);
                    invicblityInt = 1;
                }
                if (cLetterDown == false && ablityTimerSaint >=150 )
                {
                    invicblity = false;
                    ablityTimerSaint = 0;
                    MC2.Invincible(invicblity);
                    invicblityInt = 0;
                }
            }         
            Refresh();
        }
        private void gameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.D:
                    dLetterDown = true;
                    break;
                case Keys.S:
                    sLetterDown = true;
                    break;
                case Keys.A:
                    aLetterDown = true;
                    break;
                case Keys.W:
                    wLetterDown = true;
                    break;
                case Keys.C:
                    cLetterDown = true;
                    break;
                case Keys.B:
                    bLetterDown = true;
                    break;
            }
        }

        private void gameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.D:
                    dLetterDown = false;
                    break;
                case Keys.S:
                    sLetterDown = false;
                    break;
                case Keys.A:
                    aLetterDown = false;
                    break;
                case Keys.W:
                    wLetterDown = false;
                    break;
                case Keys.C:
                    cLetterDown = false;
                    break;                  
            }
        }

        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Witch MC in witchList)
            {               
                e.Graphics.FillRectangle(witchBrush, MC.X, MC.Y, MC.size, MC.size);
            }
            foreach (Saint MC2 in saintList)
            {
                e.Graphics.FillRectangle(saintBrush, MC2.X, MC2.Y, MC2.size, MC2.size);
            }
            if(bLetterDown == true || ablityTimerWitch >= 200 && !(ablityTimerWitch == 0) && ablityUsedWitch <4)
            {                       
                foreach (Ball ball1 in ballList)
                {                 
                    e.Graphics.FillEllipse(ballBrush, ball1.X, ball1.Y, ball1.size, ball1.size);
                }
            }          
        }
        
    }
}
