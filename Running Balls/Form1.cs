using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Running_Balls
{
    public partial class Form1 : Form
    {
        public static string endGame = "The Saint Killed the Witch!";
        public static Stopwatch  stopWatch = new Stopwatch();
        public static int timer = 0;
        public static int  stopTimeTimer = 60;
        public bool no;
        public Form1()
        {
            InitializeComponent();
            MainScreen FS = new MainScreen();
            this.Controls.Add(FS);

        }
    }
}
