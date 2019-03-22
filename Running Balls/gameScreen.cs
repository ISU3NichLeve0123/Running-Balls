// March 22, 2019 Nicholas Levesque. A simple game Program demonstarting the uses of Class based objects(Try to comment it out, still did not work)
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
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
        //Movement Keys
        bool leftArrowDown, rightArrowDown, upArrowDown, downArrowDown, aLetterDown, sLetterDown, dLetterDown, wLetterDown,
        cLetterDown, bLetterDown;
        //Bool Variables used in ablitys
        bool shoot = false, invicblity = false, notDraw = false;  
        //Drawing Variables
        SolidBrush ballBrush = new SolidBrush(Color.Black);
        SolidBrush fontBrush = new SolidBrush(Color.Purple);
        Font drawFont = new Font("Times New Roman", 30, FontStyle.Regular);
        //SoundPlayers
        //Normal Collsion
        SoundPlayer diedSoundPlayer = new SoundPlayer(Properties.Resources.diedSound);
        SoundPlayer survivedSoundPlayer = new SoundPlayer(Properties.Resources.survivedSound);
        SoundPlayer shootSoundPlayer = new SoundPlayer(Properties.Resources.ballShotSound);
        SoundPlayer invincblitySoundPlayer = new SoundPlayer(Properties.Resources.invcblitySound);
        //Hit via Ball
        SoundPlayer saintHitSoundPlayer = new SoundPlayer(Properties.Resources.saintHitSound);
        //Witch Variables
        static int witchX = 100, witchY = 0, witchSize = 60, witchSpeed = 4;
        //Saint Variables
        static int saintX = 500, saintY = 400, saintSize = 60, saintSpeed = 4;
        //Ball Variables
        static int ballSize = 30, ballSpeed = 8;
        //Creating the objects to add to the list
        Witch MC = new Witch(witchX, witchY, witchSize, witchSpeed, witchSpeed);
        Saint MC2 = new Saint(saintX, saintY, saintSize, saintSpeed, saintSpeed);
        Ball ball1 = new Ball(witchX, witchY, ballSize, ballSpeed, ballSpeed);
        //Centering the Screen
        private void gameScreen_Load(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
        }
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
        { //Win Condtion for Saint
            if (Form1.stopWatch.Elapsed.Seconds >= Form1.stopTimeTimer)
            {
                gameTimer.Stop();
                survivedSoundPlayer.Play();
                Form1.stopWatch.Stop();
                Form f = this.FindForm();
                f.Controls.Remove(this);
                EndGame Sc = new EndGame();
                f.Controls.Add(Sc);
            }
            //Win Condtion for Witch
            if ((MC2.Collsion(MC, MC2, this.Height, this.Width) == true))
            {              
                gameTimer.Stop();
                Form1.stopWatch.Stop();
                diedSoundPlayer.Play(); 
                Form f = this.FindForm();
                f.Controls.Remove(this);
                EndGame Sc = new EndGame();
                f.Controls.Add(Sc);
            }
            if((ball1.Collsion(MC, MC2, this, ball1) == true))
            {
                saintHitSoundPlayer.Play();
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
                //Abilities and anything to do with them
                if (bLetterDown == true && ablityTimerWitch ==0 && ablityUsedWitch < 4)
                {
                    shootSoundPlayer.Play();
                    if (ablityUsedWitch != 4)
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
                if(ablityUsedWitch == 4)
                {
                    notDraw = true;
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
                //Abilities and anything to do with them
                if (cLetterDown == true && !(ablityUsedSaint == 4))
                {
                    invincblitySoundPlayer.Play();
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
        //Key Press Down
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
        //Key Press Up
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
        //Paint  Method
        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Drawing time
            e.Graphics.DrawString(Convert.ToString(Form1.stopWatch.Elapsed.Seconds), drawFont, fontBrush, this.Width - 50, 0);
            //Drawing Witch
            foreach (Witch MC in witchList)
            {               
                e.Graphics.DrawImage(Properties.Resources.Witch, MC.X, MC.Y, MC.size, MC.size);
            }
            //Drawing Saint
            foreach (Saint MC2 in saintList)
            {
                e.Graphics.DrawImage(Properties.Resources.Saint, MC2.X, MC2.Y, MC2.size, MC2.size);
            }
            //Ensuring ball is draw at proper time
            if(bLetterDown == true || ablityTimerWitch >= 200 && !(ablityTimerWitch == 0))
            {                       
                //Does not draw when Limit reached
                if(notDraw == false)
                {
                    foreach (Ball ball1 in ballList)
                    {
                        e.Graphics.DrawImage(Properties.Resources.Witch_Ball, ball1.X + MC.size / 2, ball1.Y, ball1.size, ball1.size);
                    }
                }              
            }          
        }
        
    }
}
