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
            helpLabel.Text = "For The Saint, the controls are the arrow keys, " +
            "For the Witch, it is AWSD. The objective of this game is for the Saint to outlast the Witch, by any means necessary.";
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MainScreen Sc = new MainScreen();
            f.Controls.Add(Sc);
        }
    }
}
