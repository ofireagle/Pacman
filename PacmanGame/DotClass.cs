using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Drawing.Drawing2D;

namespace PacmanGame
{
    class DotClass
    {

        public  List<Point> dotsList; //list of the point in the game

        //create the dots and add them to dotList
        public void GenerateDot()
        {         
            // Row 1 Accross
            dotsList = new List<Point>();
            dotsList.Add(new Point(21, 24));
            dotsList.Add(new Point(37, 24));
            dotsList.Add(new Point(53, 24));
            dotsList.Add(new Point(69, 24));
            dotsList.Add(new Point(85, 24));
            dotsList.Add(new Point(101, 24));
            dotsList.Add(new Point(117, 24));
            dotsList.Add(new Point(133, 24));
            dotsList.Add(new Point(149, 24));
            dotsList.Add(new Point(165, 24));
            dotsList.Add(new Point(181, 24));
            dotsList.Add(new Point(197, 24));
            dotsList.Add(new Point(244, 24));
            dotsList.Add(new Point(260, 24));
            dotsList.Add(new Point(276, 24));
            dotsList.Add(new Point(292, 24));
            dotsList.Add(new Point(308, 24));
            dotsList.Add(new Point(324, 24));
            dotsList.Add(new Point(340, 24));
            dotsList.Add(new Point(356, 24));
            dotsList.Add(new Point(372, 24));
            dotsList.Add(new Point(388, 24));
            dotsList.Add(new Point(404, 24));
            dotsList.Add(new Point(420, 24));

            // Row 2 Accross
            dotsList.Add(new Point(21, 42));
            dotsList.Add(new Point(101, 42));
            dotsList.Add(new Point(197, 42));
            dotsList.Add(new Point(244, 42));
            dotsList.Add(new Point(340, 42));
            dotsList.Add(new Point(420, 42));

            // Row 3 Accorss
            dotsList.Add(new Point(101, 60));
            dotsList.Add(new Point(197, 60));
            dotsList.Add(new Point(244, 60));
            dotsList.Add(new Point(340, 60));

            // Row 4 Accorss
            dotsList.Add(new Point(21, 77));
            dotsList.Add(new Point(101, 77));
            dotsList.Add(new Point(197, 77));
            dotsList.Add(new Point(244, 77));
            dotsList.Add(new Point(340, 77));
            dotsList.Add(new Point(420, 77));

            // Row 5 Across
            dotsList.Add(new Point(21, 95));
            dotsList.Add(new Point(37, 95));
            dotsList.Add(new Point(53, 95));
            dotsList.Add(new Point(69, 95));
            dotsList.Add(new Point(85, 95));
            dotsList.Add(new Point(101, 95));
            dotsList.Add(new Point(117, 95));
            dotsList.Add(new Point(133, 95));
            dotsList.Add(new Point(149, 95));
            dotsList.Add(new Point(165, 95));
            dotsList.Add(new Point(181, 95));
            dotsList.Add(new Point(197, 95));
            dotsList.Add(new Point(213, 95));
            dotsList.Add(new Point(229, 95));
            dotsList.Add(new Point(244, 95));
            dotsList.Add(new Point(260, 95));
            dotsList.Add(new Point(276, 95));
            dotsList.Add(new Point(292, 95));
            dotsList.Add(new Point(308, 95));
            dotsList.Add(new Point(324, 95));
            dotsList.Add(new Point(340, 95));
            dotsList.Add(new Point(356, 95));
            dotsList.Add(new Point(372, 95));
            dotsList.Add(new Point(388, 95));
            dotsList.Add(new Point(404, 95));
            dotsList.Add(new Point(420, 95));

            // Row 6 Across
            dotsList.Add(new Point(21, 112));
            dotsList.Add(new Point(101, 112));
            dotsList.Add(new Point(149, 112));
            dotsList.Add(new Point(292, 112));
            dotsList.Add(new Point(340, 112));
            dotsList.Add(new Point(420, 112));

            // Row 7 Across
            dotsList.Add(new Point(21, 130));
            dotsList.Add(new Point(101, 130));
            dotsList.Add(new Point(149, 130));
            dotsList.Add(new Point(292, 130));
            dotsList.Add(new Point(340, 130));
            dotsList.Add(new Point(420, 130));

            // Row 8 Across
            dotsList.Add(new Point(21, 148));
            dotsList.Add(new Point(37, 148));
            dotsList.Add(new Point(53, 148));
            dotsList.Add(new Point(69, 148));
            dotsList.Add(new Point(85, 148));
            dotsList.Add(new Point(101, 148));
            dotsList.Add(new Point(149, 148));
            dotsList.Add(new Point(165, 148));
            dotsList.Add(new Point(181, 148));
            dotsList.Add(new Point(197, 148));
            dotsList.Add(new Point(244, 148));
            dotsList.Add(new Point(260, 148));
            dotsList.Add(new Point(276, 148));
            dotsList.Add(new Point(292, 148));
            dotsList.Add(new Point(340, 148));
            dotsList.Add(new Point(356, 148));
            dotsList.Add(new Point(372, 148));
            dotsList.Add(new Point(388, 148));
            dotsList.Add(new Point(404, 148));
            dotsList.Add(new Point(420, 148));

            // Row 9 Across
            dotsList.Add(new Point(101, 166));
            dotsList.Add(new Point(340, 166));

            // Row 10 Across
            dotsList.Add(new Point(101, 183));
            dotsList.Add(new Point(340, 183));

            // Row 11 Across
            dotsList.Add(new Point(101, 201));
            dotsList.Add(new Point(340, 201));

            // Row 12 Across
            dotsList.Add(new Point(101, 219));
            dotsList.Add(new Point(340, 219));

            // Row 13 Across
            dotsList.Add(new Point(101, 236));
            dotsList.Add(new Point(340, 236));

            // Row 14 Across
            dotsList.Add(new Point(101, 254));
            dotsList.Add(new Point(340, 254));

            // Row 15 Across
            dotsList.Add(new Point(101, 272));
            dotsList.Add(new Point(340, 272));

            // Row 16 Across
            dotsList.Add(new Point(101, 290));
            dotsList.Add(new Point(340, 290));

            // Row 17 Across
            dotsList.Add(new Point(101, 307));
            dotsList.Add(new Point(340, 307));

            // Row 18 Across
            dotsList.Add(new Point(101, 325));
            dotsList.Add(new Point(340, 325));

            // Row 19 Across
            dotsList.Add(new Point(101, 343));
            dotsList.Add(new Point(340, 343));

            // Row 20 Across
            dotsList.Add(new Point(21, 360));
            dotsList.Add(new Point(37, 360));
            dotsList.Add(new Point(53, 360));
            dotsList.Add(new Point(69, 360));
            dotsList.Add(new Point(85, 360));
            dotsList.Add(new Point(101, 360));
            dotsList.Add(new Point(117, 360));
            dotsList.Add(new Point(133, 360));
            dotsList.Add(new Point(149, 360));
            dotsList.Add(new Point(165, 360));
            dotsList.Add(new Point(181, 360));
            dotsList.Add(new Point(197, 360));
            dotsList.Add(new Point(244, 360));
            dotsList.Add(new Point(260, 360));
            dotsList.Add(new Point(276, 360));
            dotsList.Add(new Point(292, 360));
            dotsList.Add(new Point(308, 360));
            dotsList.Add(new Point(324, 360));
            dotsList.Add(new Point(340, 360));
            dotsList.Add(new Point(356, 360));
            dotsList.Add(new Point(372, 360));
            dotsList.Add(new Point(388, 360));
            dotsList.Add(new Point(404, 360));
            dotsList.Add(new Point(420, 360));

            // Row 21 Across
            dotsList.Add(new Point(21, 378));
            dotsList.Add(new Point(101, 378));
            dotsList.Add(new Point(197, 378));
            dotsList.Add(new Point(244, 378));
            dotsList.Add(new Point(340, 378));
            dotsList.Add(new Point(420, 378));

            // Row 22 Across
            dotsList.Add(new Point(21, 396));
            dotsList.Add(new Point(101, 396));
            dotsList.Add(new Point(197, 396));
            dotsList.Add(new Point(244, 396));
            dotsList.Add(new Point(340, 396));
            dotsList.Add(new Point(420, 396));

            // Row 23 Across
            dotsList.Add(new Point(37, 414));
            dotsList.Add(new Point(53, 414));
            dotsList.Add(new Point(101, 414));
            dotsList.Add(new Point(117, 414));
            dotsList.Add(new Point(133, 414));
            dotsList.Add(new Point(149, 414));
            dotsList.Add(new Point(165, 414));
            dotsList.Add(new Point(181, 414));
            dotsList.Add(new Point(197, 414));
            dotsList.Add(new Point(244, 414));
            dotsList.Add(new Point(260, 414));
            dotsList.Add(new Point(276, 414));
            dotsList.Add(new Point(292, 414));
            dotsList.Add(new Point(308, 414));
            dotsList.Add(new Point(324, 414));
            dotsList.Add(new Point(340, 414));
            dotsList.Add(new Point(388, 414));
            dotsList.Add(new Point(404, 414));

            // Row 24 Across
            dotsList.Add(new Point(53, 431));
            dotsList.Add(new Point(101, 431));
            dotsList.Add(new Point(149, 431));
            dotsList.Add(new Point(292, 431));
            dotsList.Add(new Point(340, 431));
            dotsList.Add(new Point(388, 431));

            // Row 25 Across
            dotsList.Add(new Point(53, 449));
            dotsList.Add(new Point(101, 449));
            dotsList.Add(new Point(149, 449));
            dotsList.Add(new Point(292, 449));
            dotsList.Add(new Point(340, 449));
            dotsList.Add(new Point(388, 449));

            // Row 26 Across
            dotsList.Add(new Point(21, 466));
            dotsList.Add(new Point(37, 466));
            dotsList.Add(new Point(53, 466));
            dotsList.Add(new Point(69, 466));
            dotsList.Add(new Point(85, 466));
            dotsList.Add(new Point(101, 466));
            dotsList.Add(new Point(149, 466));
            dotsList.Add(new Point(165, 466));
            dotsList.Add(new Point(181, 466));
            dotsList.Add(new Point(197, 466));
            dotsList.Add(new Point(244, 466));
            dotsList.Add(new Point(260, 466));
            dotsList.Add(new Point(276, 466));
            dotsList.Add(new Point(292, 466));
            dotsList.Add(new Point(340, 466));
            dotsList.Add(new Point(356, 466));
            dotsList.Add(new Point(372, 466));
            dotsList.Add(new Point(388, 466));
            dotsList.Add(new Point(404, 466));
            dotsList.Add(new Point(420, 466));

            // Row 27 Across
            dotsList.Add(new Point(21, 484));
            dotsList.Add(new Point(197, 484));
            dotsList.Add(new Point(244, 484));
            dotsList.Add(new Point(420, 484));

            // Row 28 Across
            dotsList.Add(new Point(21, 502));
            dotsList.Add(new Point(197, 502));
            dotsList.Add(new Point(244, 502));
            dotsList.Add(new Point(420, 502));

            // Row 29 Across
            dotsList.Add(new Point(21, 519));
            dotsList.Add(new Point(37, 519));
            dotsList.Add(new Point(53, 519));
            dotsList.Add(new Point(69, 519));
            dotsList.Add(new Point(85, 519));
            dotsList.Add(new Point(101, 519));
            dotsList.Add(new Point(117, 519));
            dotsList.Add(new Point(133, 519));
            dotsList.Add(new Point(149, 519));
            dotsList.Add(new Point(165, 519));
            dotsList.Add(new Point(181, 519));
            dotsList.Add(new Point(197, 519));
            dotsList.Add(new Point(213, 519));
            dotsList.Add(new Point(229, 519));
            dotsList.Add(new Point(244, 519));
            dotsList.Add(new Point(260, 519));
            dotsList.Add(new Point(276, 519));
            dotsList.Add(new Point(292, 519));
            dotsList.Add(new Point(308, 519));
            dotsList.Add(new Point(324, 519));
            dotsList.Add(new Point(340, 519));
            dotsList.Add(new Point(356, 519));
            dotsList.Add(new Point(372, 519));
            dotsList.Add(new Point(388, 519));
            dotsList.Add(new Point(404, 519));
            dotsList.Add(new Point(420, 519));
            dotsList.Add(new Point(420, 519));
        }
        //paint the dots on screen
        public void PaintDots(Graphics _graphics)
        {
            
            SolidBrush b = new SolidBrush(Color.Yellow);

            foreach (Point p in dotsList)
            {
                _graphics.FillEllipse(b, p.X, p.Y, 7, 7);
            }
          
        }
    }
}
