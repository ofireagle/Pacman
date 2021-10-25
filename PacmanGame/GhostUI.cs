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
    //enum for ghost background image
    public enum enumGhostImage
    { 
        Pink,
        Red,
        Blue,
        Yellow
    }

    //enum for direction
    public enum enumDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public partial class GhostUI : Panel
    {
        public Point location = new Point(); //location of ghost
        public enumGhostImage ghostImage;    //the ghost type
        public enumDirection Direction;      //the direction
        
        //constructor
        public  GhostUI(int image, Point loc )
        {
            InitializeComponent();

            //sset ghost image and location
            SetImage(image);
            this.Height = 30;
            this.Width = 30;
            SetLoaction(loc);
            this.Direction = enumDirection.Up;
        }

        //set ghost location
        private void SetLoaction(Point loc)
        {
            location.X = loc.X;
            location.Y = loc.Y;
            this.Top = location.Y -15;
            this.Left = location.X -15;
        }

        //set image by int
        private void SetImage(int image)
        {
            switch (image)
            {
                case 0:
                    ghostImage = enumGhostImage.Blue;
                    this.BackgroundImage = Properties.Resources.blue;
                    break;
                case 1:
                    ghostImage = enumGhostImage.Pink;
                    this.BackgroundImage = Properties.Resources.pink;
                    break;
                case 2:
                    ghostImage = enumGhostImage.Red;
                    this.BackgroundImage = Properties.Resources.red;
                    break;
                case 3:
                    ghostImage = enumGhostImage.Yellow;
                    this.BackgroundImage = Properties.Resources.yellow;
                    break;
            }
            this.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
          
            
        }
        //move ghost to direction
        public void MoveGhostToDirection()
        { 
            if (this.Direction == enumDirection.Up)
                SetLoaction(new Point (this.location.X,  this.location.Y - 1));
            if (this.Direction == enumDirection.Down)
                SetLoaction(new Point (this.location.X,  this.location.Y + 1));
            if (this.Direction == enumDirection.Left)
                SetLoaction(new Point (this.location.X -1, this.location.Y));
            if (this.Direction == enumDirection.Right)
                SetLoaction(new Point(this.location.X +1,  this.location.Y));
        }
       
    }
}
