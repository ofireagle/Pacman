using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PacmanGame
{
    public partial class SaveScoreForm : Form
    {
        private int Place; //for place in top list table
        private int Score; //for the score in 

        public SaveScoreForm(int place, int score)
        {
            InitializeComponent();
            Place = place;
            Score = score;

        }

        //no save score button event click
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //save score button event click
        private void button1_Click(object sender, EventArgs e)
        {
       
                //open file for read
                StreamReader sr = new StreamReader("TopTen.txt");
                string lines = sr.ReadToEnd(); //read all lines in one time
                string[] line = lines.Split('\n');             //split the string to lines
                sr.Close();                    //close the file

                //open file for write
                StreamWriter sw = new StreamWriter("TopTen.txt");

                //write the file again 
                for (int i = 0; i < 10; i++)
                {
                    if (i == Place) //if the line is the number of the new height score
                    {
                        //write the new height score
                        sw.WriteLine(textBox1.Text.ToString() + ":" + Score.ToString());
                    }
                    if ( i < line.Length && line[i] != "" )  //write the old line
                    {
                        sw.WriteLine(line[i]);
                    }

                }
                sw.Close();
                this.Close();

                //re-open the tops list form
                TopTenForm tops = new TopTenForm();
                tops.Show();
            
        }
    }
}
