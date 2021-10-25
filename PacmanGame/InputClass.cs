using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace PacmanGame
{
    class InputClass
    {
        //hashtable for keeping keys state
        private static Hashtable keys = new Hashtable();

        //change key state
        public static void ChangeState(Keys key ,bool state)
        {
            keys[key] = state;

        }
        //return key state
        public static bool Pressed(Keys key)
        {
            if (keys[key] == null)
                return false;
            return (bool)keys[key];
        }


    }
}
