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
    public partial class helpScreen : UserControl
    {
        public helpScreen()
        {
            InitializeComponent();
            helpLabel.Text = "For The Saint, it is the right joystick and press the blue button next to it for invincblity. " +
            "For the Witch, it is the left joystick, press the blue button next to it to shoot a black ball. " +
            "The objective of this game is for the Witch to catch the Saint, you have 30 seconds until the Saint will escape. " +
            "You ONLY HAVE 3 CHARGES ON YOUR ABLITYS, use them well.";
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MainScreen Sc = new MainScreen();
            f.Controls.Add(Sc);
            Sc.Focus();
            this.Dispose();
        }

        private void helpScreen_Load(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
        }
    }
}
