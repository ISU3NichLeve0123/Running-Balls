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
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            gameScreen Sc = new gameScreen();
            f.Controls.Add(Sc);
            Sc.Focus();
            this.Dispose();
        }
        private void helpButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            helpScreen Sc = new helpScreen();
            f.Controls.Add(Sc);
            Sc.Focus();
            this.Dispose();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
