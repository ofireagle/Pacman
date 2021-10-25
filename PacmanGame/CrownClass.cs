using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PacmanGame
{
    class CrownClass
    {
        public List<Point> CrownList;  //crown dots list

        //constructor
        public CrownClass()
        {
            // create new list
            CrownList  = new List<Point>();
            
        }

        //create the crowns and add them to CrownList
        public void GenerateCrown()
        {
            CrownList.Add(new Point(21, 60));
            CrownList.Add(new Point(420, 60));
            CrownList.Add(new Point(21, 414));
            CrownList.Add(new Point(420, 414));
        }

        //paint crown list to board
        public void PaintCrown(Graphics _graphics)
        {
            SolidBrush b = new SolidBrush(Color.Yellow);

            foreach (Point p in CrownList)
            {
                _graphics.FillEllipse(b, p.X  -5, p.Y -5 , 15, 15);
            }
        }
    }
}
