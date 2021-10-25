using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PacmanGame
{
    public partial class GameForm : Form
    {
      
       
         
        DotClass dots = new DotClass();                  //for painting dots 
        BlockClass blocks = new BlockClass();            //for painting blocks
        CrownClass crowns = new CrownClass();            //for painting crowns
        PacmanUI pacman = new PacmanUI();                //for add pacman
        List<GhostUI> ghostList = new List<GhostUI>();   //for ghosts
        GamePanel gamePanel = new GamePanel();           //the board of the game
        Label Message = new Label();                     //for win or lose or pause message
        Panel Bonos = new Panel();                       //for presents
        bool gameOver;                                   //if the game is over 
        bool Started;                                    //if the game is started
        int score = 0;                                   //the score
        int superPower;                                  //for eating the ghosts
        int generateBonos;                               //for generate new present
        int num_of_ghosts;   

        //constructor
        public GameForm()
        {
            InitializeComponent();
            
            //add the board 
            this.gamePanel.Dock = DockStyle.Left;
            this.gamePanel.Width = 450;
            gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(gamePanel_Paint);
            gamePanel.BackColor = Color.Transparent;
            this.Controls.Add(gamePanel);

            //add start message
            Message.AllowDrop = true;
            Message.TextAlign = ContentAlignment.MiddleCenter; 
            Message.Height = 200;
            Message.Width = 350;
            Message.BackColor = Color.Transparent;
            Message.Left = gamePanel.Width / 2 - Message.Width/2;
            Message.Top = gamePanel.Height / 2;
            Message.ForeColor = Color.White;
            Message.Font = new Font("Palatino Linotype", 27.75f, FontStyle.Bold); 
           
            //start the game
            StartGame();

        }

        //set new game 
        private void StartGame()
        {
            timer.Stop();
            dots.GenerateDot();
            blocks.GeneratePathPoints();
            crowns.GenerateCrown();
            num_of_ghosts = 0;
            addCharater();
            gameOver = false;
            Started = false;
            superPower = 501;
            score = 0;
            generateBonos = 0;
            Message.Text = "Start! \n (Press on Arrows)";
            gamePanel.Controls.Add(Message);
            scoreLabel.Text = "Score: " + score.ToString();
            Bonos.Height = 25;
            Bonos.Width = 25;
            Bonos.BackgroundImage = Properties.Resources.Bonost;
            Bonos.BackgroundImageLayout = ImageLayout.Stretch;
        }
        //draw characters on board
        private void addCharater()
        {
            // Add pacman 
            pacman = new PacmanUI();
            gamePanel.Controls.Add(pacman);
            
            // Add ghost
            for (int i = 0; i < ( 4 + num_of_ghosts); i++)
            {
                
                GhostUI  p = new GhostUI(i % 4, new Point(195 + ( (i % 4) *10), 250));   
                ghostList.Add(p);
                gamePanel.Controls.Add(p);
                
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

       
            

        }
       
        //paint for game board event (paint dots and crown(big dots)
        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
          
            Graphics graphics = e.Graphics;   
            crowns.PaintCrown(graphics);   //paint crowns
            dots.PaintDots(graphics);      //paint dots

        }

        //key down event
        private void KeyDown_From(object sender, KeyEventArgs e)
        {
            //the key is not arrow key
            if (e.KeyCode != Keys.Right && e.KeyCode != Keys.Left && e.KeyCode != Keys.Down
                && e.KeyCode != Keys.Up)
            {
                timer.Stop();
                if (!gameOver && Started)
                {
                    Message.Text = "Pause!\n(Press on Arrows\nfor Continue)";
                    Message.Visible = true;
                }
            }
            else   //the key is arrow key

                if (!timer.Enabled && !gameOver)  //and the game is not over or allready in action
                {
                    Message.Visible = false;
                    Started = true;
                    timer.Start();
                }
            InputClass.ChangeState(e.KeyCode, true); //change the key state

        }
        //key up event
        private void KeyUp_From(object sender, KeyEventArgs e)
        {
            InputClass.ChangeState(e.KeyCode, false); //change the key state
        }

        //timer tick event (game loop)
        private void UpdateBoard(object sender, EventArgs e)
        {
            Bitmap bitmap;

            //checking for superpower state
            if (superPower > 300)
                bitmap = Properties.Resources.pacman1;
            else 
                bitmap = Properties.Resources.super_pacman;

            int speed = 2;  //set the speed of the pacman
            
            //if the right key is pressed
            if (InputClass.Pressed(Keys.Right))
            {
                //if the pacman can move to the next point or point beside
                if (blocks.PathList.Contains(new Point(pacman.location.X + speed, (pacman.location.Y)) )
                    || (blocks.PathList.Contains(new Point(pacman.location.X + speed , (pacman.location.Y -1)) ) )
                    || (blocks.PathList.Contains(new Point(pacman.location.X + speed , (pacman.location.Y+1)) ) ))
                   
                {
                    pacman.SetLoaction(new Point(pacman.location.X + speed, pacman.location.Y));
                    pacman.BackgroundImage = bitmap;
                }
                //if the pacman move to the left side of the board
                else if (pacman.Left +pacman.Width > gamePanel.Width)
                {
                    pacman.SetLoaction(new Point(0, pacman.location.Y));
                    pacman.BackgroundImage = bitmap;
                }
    
            }
            //if the left key is pressed
            if (InputClass.Pressed(Keys.Left))
            {
                //if the pacman can move to the next point or point beside
                if (blocks.PathList.Contains(new Point(pacman.location.X - speed, (pacman.location.Y)))
                    || (blocks.PathList.Contains(new Point(pacman.location.X - speed , (pacman.location.Y -1)) ) )
                    || (blocks.PathList.Contains(new Point(pacman.location.X - speed , (pacman.location.Y+1)) ) ))
                   
                {
                    pacman.SetLoaction(new Point(pacman.location.X - speed, pacman.location.Y));
                    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pacman.BackgroundImage = bitmap;
                }
                //if the pacman move to the right side of the board
                else if (pacman.Left < 0)
                {
                    pacman.SetLoaction(new Point(gamePanel.Width, pacman.location.Y));
                    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
               
            }
            //if the right up is pressed
            if (InputClass.Pressed(Keys.Up))
            {
                //if the pacman can move to the next point or point beside
                if (blocks.PathList.Contains(new Point(pacman.location.X, (pacman.location.Y - speed)))
                    || (blocks.PathList.Contains(new Point(pacman.location.X +1 , (pacman.location.Y - speed)) ) )
                    || (blocks.PathList.Contains(new Point(pacman.location.X -1, (pacman.location.Y- speed)) ) ))
                   
                {
                    pacman.SetLoaction(new Point(pacman.location.X, pacman.location.Y -speed));
                    bitmap.RotateFlip(RotateFlipType.Rotate90FlipY);
                    pacman.BackgroundImage = bitmap;

                }
            }
            //if the right down is pressed
            if (InputClass.Pressed(Keys.Down))
            {
                //if the pacman can move to the next point or point beside
                if (blocks.PathList.Contains(new Point(pacman.location.X, (pacman.location.Y + speed)))
                     || (blocks.PathList.Contains(new Point(pacman.location.X +1 , (pacman.location.Y + speed)) ) 
                     || (blocks.PathList.Contains(new Point(pacman.location.X -1, (pacman.location.Y + speed)) ) )))
                    
                {
                    pacman.SetLoaction(new Point(pacman.location.X, pacman.location.Y + speed));
                    bitmap.RotateFlip(RotateFlipType.Rotate270FlipY);
                    pacman.BackgroundImage = bitmap;

                }
            }
            //check collosion with dots
            for (int i = 0; i < dots.dotsList.Count; i++ )
            {
                if (pacman.Bounds.Contains( dots.dotsList[i]))
                {
                    dots.dotsList.Remove( dots.dotsList[i]);
                    score += 1;
                    scoreLabel.Text = "Score: " + score.ToString();
                    break ;
                }
            }
            //check collosion with ghosts
            for (int i = 0; i < ghostList.Count; i++)
            {
                if (pacman.Bounds.IntersectsWith(ghostList[i].Bounds))
                {
                    if (superPower < 300)
                    {
                        score += 20;
                        scoreLabel.Text = "Score: " + score.ToString();
                        ghostList[i].Visible = false;
                        ghostList.Remove(ghostList[i]);
                    }
                    else
                    {
                        GameOver();
                        return;
                    }
                }
            }
            //check collosion with crowns
            for (int i = 0; i < crowns.CrownList.Count; i++)
            {
                if (pacman.Bounds.Contains(crowns.CrownList[i]))
                {
                    crowns.CrownList.Remove(crowns.CrownList[i]);
                    superPower = 0 ;
                    score += 10;
                    scoreLabel.Text = "Score: " + score.ToString();
                    break;
                }
            }
            //move the ghost
            for (int i = 0; i < ghostList.Count; i++)
            {
                if (ghostList[i].ghostImage == enumGhostImage.Pink)
                    MovePink(i);
                if (ghostList[i].ghostImage == enumGhostImage.Red)
                    MoveRed(i);
                if (ghostList[i].ghostImage == enumGhostImage.Blue)
                    MoveBlue(i);
                if (ghostList[i].ghostImage == enumGhostImage.Yellow)
                    MoveYellow(i);
            }
            //check for wining
            if (ghostList.Count == 0 )//&& dots.dotsList.Count == 0 && crowns.CrownList.Count == 0)
            {
                num_of_ghosts++;
                score += 100;
                Nextlevel();
            }
            //check for generate new present location
            if (generateBonos > 200)
            {
                generateBonos = 0;
                GenerateBonos();
            }
            //check for collosion with present
            if (pacman.Bounds.IntersectsWith(Bonos.Bounds))
            {
                gamePanel.Controls.Remove(Bonos);
                score += 10;
                scoreLabel.Text = "Score: " + score.ToString();
                superPower = 0;
            }
            superPower++;      
            generateBonos++;
            
        }

        // restart next level
        private void Nextlevel()
        {
            timer.Stop();
            ghostList.Clear();             //clear the ghosts list
            gamePanel.Controls.Clear();    //clear the game board       
            dots.GenerateDot();
            blocks.GeneratePathPoints();
            crowns.GenerateCrown();
            addCharater();
            Started = false;
            superPower = 301;
            generateBonos = 0;
            Message.Text = "Start! \n (Press on Arrows)";
            Message.Visible = true;
            gamePanel.Controls.Add(Message);
            gamePanel.Invalidate();        //repaint game board  
        }
        
        //show gameover message
        private void GameOver()
        {
            timer.Stop();
            Message.Text = "Game Over!";
            Message.Visible = true;
            gameOver = true;

            //open file for read
            if (!File.Exists("TopTen.txt"))
                File.Create("TopTen.txt");
            StreamReader sr = new StreamReader("TopTen.txt");
            string lines = sr.ReadToEnd(); //read all lines in one time
            string[] line = lines.Split('\n');             //split the string to lines
            sr.Close();                    //close the file
           
            int i = 0;

            while ( i < line.Length  && line[i] != "" )
            {
                string[] l = line[i].Split(':');
                if (int.Parse(l[1]) < score && i < 10)
                {
                    break;
                }
                i++;
            }
            if (i < 10)
            {
                SaveScoreForm savescore = new SaveScoreForm(i, score);
                savescore.Show();
            }
           
          
        }

        //form paint event (painting the blocks)
        private void Paint_On_Form(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            blocks.PaintGameBoard(graphics); //paint the block on form

        }

        //moving stupid pink ghost
        private void MovePink(int index)
        {
            List<enumDirection> directionList = new List<enumDirection>();
            
            if (ghostList[index].Direction == enumDirection.Up )
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X - 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Left);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X + 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Right);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y - 1)))
                    directionList.Add(enumDirection.Up);
                if (directionList.Count > 0)
                {
                    Random rnd = new Random();
                    int direction = rnd.Next(0, directionList.Count);
                    ghostList[index].Direction = directionList[direction];
                }
                else
                {
                    ghostList[index].Direction = enumDirection.Down;
                }
            }
            else if (ghostList[index].Direction == enumDirection.Down)
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X - 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Left);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X + 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Right);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y + 1)))
                    directionList.Add(enumDirection.Down);
                if (directionList.Count > 0)
                {
                    Random rnd = new Random();
                    int direction = rnd.Next(0, directionList.Count);
                    ghostList[index].Direction = directionList[direction];
                }
                else
                {
                    ghostList[index].Direction = enumDirection.Up;
                }
            }
            else if (ghostList[index].Direction == enumDirection.Right)
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y + 1)))
                    directionList.Add(enumDirection.Down);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X + 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Right);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y - 1)))
                    directionList.Add(enumDirection.Up);
                if (directionList.Count > 0)
                {
                    Random rnd = new Random();
                    int direction = rnd.Next(0, directionList.Count);
                    ghostList[index].Direction = directionList[direction];
                }
                else
                {
                    ghostList[index].Direction = enumDirection.Left;
                }
            }
            else if (ghostList[index].Direction == enumDirection.Left)
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y + 1)))
                    directionList.Add(enumDirection.Down);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X - 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Left);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y - 1)))
                    directionList.Add(enumDirection.Up);
                if (directionList.Count > 0)
                {
                    Random rnd = new Random();
                    int direction = rnd.Next(0, directionList.Count);
                    ghostList[index].Direction = directionList[direction];
                }
                else
                {
                    ghostList[index].Direction = enumDirection.Right;
                }
            }

            ghostList[index].MoveGhostToDirection();
        }

        //moving blue ghost
        private void MoveBlue(int index)
        {
            List<enumDirection> directionList = new List<enumDirection>();
            if (ghostList[index].Direction == enumDirection.Up)
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y - 1)))
                    directionList.Add(enumDirection.Up);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X - 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Left);
                if (directionList.Count == 0)
                {
                    if (blocks.PathList.Contains(new Point(ghostList[index].location.X - 1, ghostList[index].location.Y)))
                        directionList.Add(enumDirection.Right);
                }
            }
            else if (ghostList[index].Direction == enumDirection.Down)
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y + 1)))
                    directionList.Add(enumDirection.Down);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X - 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Right);
                if (directionList.Count == 0)
                {
                    if (blocks.PathList.Contains(new Point(ghostList[index].location.X - 1, ghostList[index].location.Y)))
                        directionList.Add(enumDirection.Left);
                }
            }
            else if (ghostList[index].Direction == enumDirection.Left)
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X - 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Left);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y + 1)))
                    directionList.Add(enumDirection.Down);
                if (directionList.Count == 0)
                {
                    if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y - 1)))
                        directionList.Add(enumDirection.Up);
                }
            }
            else if (ghostList[index].Direction == enumDirection.Right)
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X + 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Right);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y - 1)))
                    directionList.Add(enumDirection.Up);
                if (directionList.Count == 0)
                {
                    if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y + 1)))
                        directionList.Add(enumDirection.Down);
                }

            }
            if (directionList.Count > 0)
            {
                Random rnd = new Random();
                int direction = rnd.Next(0, directionList.Count);
                ghostList[index].Direction = directionList[direction];
                ghostList[index].MoveGhostToDirection();
            }
            else
            {
                MovePink(index);
            }
        }

        //moving yellow ghost
        private void MoveYellow(int index)
        {
            List<enumDirection> directionList = new List<enumDirection>();
            if (ghostList[index].Direction == enumDirection.Up )
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y - 1)))
                    directionList.Add(enumDirection.Up);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X -1, ghostList[index].location.Y )))
                    directionList.Add(enumDirection.Right);
                if (directionList.Count == 0)
                {
                    if (blocks.PathList.Contains(new Point(ghostList[index].location.X - 1, ghostList[index].location.Y)))
                        directionList.Add(enumDirection.Left);
                }
            }
            else if (ghostList[index].Direction == enumDirection.Down )
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y + 1)))
                    directionList.Add(enumDirection.Down);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X -1, ghostList[index].location.Y )))
                    directionList.Add(enumDirection.Left);
                if (directionList.Count == 0)
                {
                    if (blocks.PathList.Contains(new Point(ghostList[index].location.X - 1, ghostList[index].location.Y)))
                        directionList.Add(enumDirection.Right);
                }
            }
            else if (ghostList[index].Direction == enumDirection.Left )
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X -1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Left);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X , ghostList[index].location.Y +1 )))
                    directionList.Add(enumDirection.Up);
                if (directionList.Count== 0)
                {
                    if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y - 1)))
                        directionList.Add(enumDirection.Down);
                }
            }
            else if (ghostList[index].Direction == enumDirection.Right )
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X +1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Right);
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X , ghostList[index].location.Y -1 )))
                    directionList.Add(enumDirection.Down);
                if (directionList.Count == 0)
                {
                    if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y + 1)))
                        directionList.Add(enumDirection.Up);
                }

            }
            if (directionList.Count > 0)
            {
                Random rnd = new Random();
                int direction = rnd.Next(0, directionList.Count);
                ghostList[index].Direction = directionList[direction];
                ghostList[index].MoveGhostToDirection();
            }
            else
            {
                MovePink(index);
            }

    
            
        }

        //moving red ghost
        private void MoveRed(int index)
        {
            List<enumDirection> directionList = new List<enumDirection>();


            if ((ghostList[index].location.X > pacman.location.X 
                && ghostList[index].Direction != enumDirection.Right)
                || (ghostList[index].location.X > pacman.location.X
                && ghostList[index].location.Y == pacman.location.Y))
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X - 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Left);
            }
            else if ((ghostList[index].location.X < pacman.location.X
                && ghostList[index].Direction != enumDirection.Left)
                || (ghostList[index].location.X < pacman.location.X
                && ghostList[index].location.Y == pacman.location.Y))
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X + 1, ghostList[index].location.Y)))
                    directionList.Add(enumDirection.Right);
            }
            if ((ghostList[index].location.Y < pacman.location.Y
                 && ghostList[index].Direction != enumDirection.Up)
                 || (ghostList[index].location.Y > pacman.location.Y
                 && ghostList[index].location.X == pacman.location.X))
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X, ghostList[index].location.Y+1)))
                    directionList.Add(enumDirection.Down);
            }
            else if ((ghostList[index].location.Y > pacman.location.Y
                 && ghostList[index].Direction != enumDirection.Down)
                 || (ghostList[index].location.Y > pacman.location.Y
                 && ghostList[index].location.X == pacman.location.X))
            {
                if (blocks.PathList.Contains(new Point(ghostList[index].location.X , ghostList[index].location.Y -1)))
                     directionList.Add(enumDirection.Up);
            }

            if (directionList.Count > 0)
            {
                Random rnd = new Random();
                int direction = rnd.Next(0, directionList.Count);
                ghostList[index].Direction = directionList[direction];
                ghostList[index].MoveGhostToDirection();
            }
            else
                MovePink(index);
            
        

        }

        //about button click event
        private void button1_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
            timer.Stop();
            if (!gameOver && Started)  //if the game is started show pause message
            {
                Message.Text = "Pause!\n(Press on Arrows\nfor Continue)";
                Message.Visible = true;
            }
            about.TopMost = true;
            gamePanel.Focus(); //return focus to game board
        }

        //restart new game
        private void ReStart()
        {
            ghostList.Clear();             //clear the ghosts list
            gamePanel.Controls.Clear();    //clear the game board
            StartGame();                   //start new game
            gamePanel.Focus();             //return focus to game board
            gamePanel.Invalidate();        //repaint game board
            Message.Visible = true;        //show start message
        }

        //restart button click event
        private void button2_Click(object sender, EventArgs e)
        {
            ReStart();
        }

        //help button click event
        private void button3_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.Show();
            timer.Stop();
            if (!gameOver && Started)   //if the game is started show pause message
            {
                Message.Text = "Pause!\n(Press on Arrows\nfor Continue)";
                Message.Visible = true;
            }
            help.TopMost = true;
            gamePanel.Focus();          //return focus to game board
        }

        //generate new present location 
        private void GenerateBonos()
        { 
            Random rnd = new Random();
            int bonos =  rnd.Next(0,blocks.PathList.Count);   //generate randomize place from pathlist
            Bonos.Top =  blocks.PathList[bonos].Y - 10;
            Bonos.Left = blocks.PathList[bonos].X - 10;
            gamePanel.Controls.Add(Bonos);
            
        }

        //top ten button click event
        private void button4_Click(object sender, EventArgs e)
        {
            TopTenForm top = new TopTenForm();
            top.Show();
            timer.Stop();
            if (!gameOver && Started)   //if the game is started show pause message
            {
                Message.Text = "Pause!\n(Press on Arrows\nfor Continue)";
                Message.Visible = true;
            }
            top.TopMost = true;
            gamePanel.Focus();          //return focus to game board
        
        }
    }
}
 