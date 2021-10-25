using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanGame
{
    public partial class PacmanUI : Panel
    {
        const int PacmanSize = 25;   //set the pacman size
        public Point location = new Point();  //piont for acman location

        //constructor
        public PacmanUI()
        {
            InitializeComponent();  

            //set double bufeer to true
            this.SetStyle(
           ControlStyles.UserPaint |
           ControlStyles.AllPaintingInWmPaint |
           ControlStyles.DoubleBuffer, true);
             
            //set the pacman first settings 
            this.BackgroundImage = Properties.Resources.pacman1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.Transparent;
            SetLoaction(new Point(23, 521));
            this.Width = PacmanSize;
            this.Height = PacmanSize;

        }

        //set pacman location and location on screen
        public void SetLoaction(Point loc)
        {
            location.X = loc.X;
            location.Y = loc.Y;
            this.Top = location.Y - 10;
            this.Left = location.X - 10;
        }

        private void character_Load(object sender, EventArgs e)
        {

        }
    }
}
