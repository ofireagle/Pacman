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
    public partial class TopTenForm : Form
    {
        //constructor
        public TopTenForm()
        {
            InitializeComponent();
        }

        //load form event
        private void TopTenForm_Load(object sender, EventArgs e)
        {
            try
            {
                //open file for read
                if (!File.Exists("TopTen.txt"))
                    File.Create("TopTen.txt");
                StreamReader sr = new StreamReader("TopTen.txt");
                string lines = sr.ReadToEnd(); //read all lines in one time
                string[] line = lines.Split('\n');             //split the string to lines
                sr.Close();                    //close the file


                int i = 1;   //set the number of the score in top list table

                //read line by line till the end of file and add it to top list
                while (line[i - 1] != "")
                {

                    string[] l = line[i - 1].Split(':');

                    //add the num label
                    Label Num_label = new Label();
                    Num_label.Top = 100 + i * label4.Height;
                    Num_label.Left = label4.Left;
                    Num_label.Text = i.ToString() + ". ";
                    Num_label.ForeColor = Color.White;
                    Num_label.BackColor = Color.Transparent;
                    Num_label.Font = new Font("Segoe Print", 18, FontStyle.Bold);
                    Num_label.Width = label4.Width;
                    Num_label.Height = label4.Height;
                    this.Controls.Add(Num_label);

                    //add the name label
                    Label Name_label = new Label();
                    Name_label.Top = 100 + i * label3.Height;
                    Name_label.Left = label3.Left;
                    Name_label.Text = l[0];
                    Name_label.ForeColor = Color.White;
                    Name_label.BackColor = Color.Transparent;
                    Name_label.Font = new Font("Segoe Print", 18, FontStyle.Bold);
                    Name_label.Width = label3.Width + 65;
                    Name_label.Height = label3.Height;
                    this.Controls.Add(Name_label);

                    //add the score label
                    Label Score_label = new Label();
                    Score_label.Top = 100 + i * label2.Height;
                    Score_label.Left = label2.Left;
                    Score_label.Text = l[1];
                    Score_label.ForeColor = Color.White;
                    Score_label.BackColor = Color.Transparent;
                    Score_label.Font = new Font("Segoe Print", 18, FontStyle.Bold);
                    Score_label.Width = label2.Width;
                    Score_label.Height = label2.Height;
                    this.Controls.Add(Score_label);
                    i++; //increase the num

                }
            }
            catch { }

        }
    }
}
