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
    public partial class EndGame : UserControl
    {
        public EndGame()
        {        
            InitializeComponent();
            int tempTimer = Form1.timer;
            if (Form1.stopWatch.Elapsed.Seconds < Form1.stopTimeTimer)
            {
                endScreenLabel.Text = "Oh No! The Witch Killed The Saint!";
                timerLabel.Text = "You lasted " + Convert.ToString(Form1.stopWatch.Elapsed.Seconds) + " Seconds";
            }
            if (Form1.stopWatch.Elapsed.Seconds == Form1.stopTimeTimer)
            {
                endScreenLabel.Text = "The Saint Escaped the witch!";
                timerLabel.Text = "You lasted " + Convert.ToString(Form1.stopWatch.Elapsed.Seconds) + " Seconds";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.stopWatch.Reset();
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MainScreen Sc = new MainScreen();
            f.Controls.Add(Sc);
        }
    }
}
