using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;
using System.IO;

namespace FinalProject
{
    
    class Program
    {
        static Form form = new Form();
        static Button platform = new Button();
        static Label ball = new Label();
        static Label[] cell = new Label[30];
        
        static System.Timers.Timer buttonTimer = new System.Timers.Timer();
        static System.Timers.Timer ballTimer = new System.Timers.Timer();
        
        static int platformX = 400;
        static int direction = 0;
        static int unitLeft, unitTop;
        static bool moveLeft, moveTop;
        static int cellNumber = 30;

        static void Main(string[] args)
        {
            Initialisation();

            moveLeft = true;
            moveTop = true;

            unitLeftChanger();

            unitTop = 10;

            form.Focus();
            Application.Run(form);
        }

        private static void Initialisation()
        {
            formInitialisation();
            platformInitialisation();
            ballInitialisation();
            buttonTimerInitialisation();
            ballTimerInitialisation();
            cellArrayInitialization();
        }

        private static void cellArrayInitialization()
        {
            
            for (int i = 0; i < 30; i++)
            {
                cell[i] = new Label();
                cell[i].Parent = form;
                cell[i].BorderStyle = BorderStyle.FixedSingle;
                cell[i].Visible = true;
                cell[i].Size = new Size(100, 25);
                switch (i)
                {
                    case 0:
                        cell[i].Location = new Point(50, 100);
                        cell[i].BackColor = Color.AliceBlue;
                        break;
                    case 1:
                        cell[i].Location = new Point(150, 100);
                        cell[i].BackColor = Color.AliceBlue;
                        break;
                    case 2:
                        cell[i].Location = new Point(250, 100);
                        cell[i].BackColor = Color.AliceBlue;
                        break;
                    case 3:
                        cell[i].Location = new Point(350, 100);
                        cell[i].BackColor = Color.AliceBlue;
                        break;
                    case 4:
                        cell[i].Location = new Point(450, 100);
                        cell[i].BackColor = Color.AliceBlue;
                        break;
                    case 5:
                        cell[i].Location = new Point(550, 100);
                        cell[i].BackColor = Color.AliceBlue;
                        break;
                    case 6:
                        cell[i].Location = new Point(650, 100);
                        cell[i].BackColor = Color.AliceBlue;
                        break;
                    case 7:
                        cell[i].Location = new Point(750, 100);
                        cell[i].BackColor = Color.AliceBlue;
                        break;
                    case 8:
                        cell[i].Location = new Point(850, 100);
                        cell[i].BackColor = Color.AliceBlue;
                        break;
                    case 9:
                        cell[i].Location = new Point(100, 125);
                        cell[i].BackColor = Color.Coral;
                        break;
                    case 10:
                        cell[i].Location = new Point(200, 125);
                        cell[i].BackColor = Color.Coral;
                        break;
                    case 11:
                        cell[i].Location = new Point(300, 125);
                        cell[i].BackColor = Color.Coral;
                        break;
                    case 12:
                        cell[i].Location = new Point(400, 125);
                        cell[i].BackColor = Color.Coral;
                        break;
                    case 13:
                        cell[i].Location = new Point(500, 125);
                        cell[i].BackColor = Color.Coral;
                        break;
                    case 14:
                        cell[i].Location = new Point(600, 125);
                        cell[i].BackColor = Color.Coral;
                        break;
                    case 15:
                        cell[i].Location = new Point(700, 125);
                        cell[i].BackColor = Color.Coral;
                        break;
                    case 16:
                        cell[i].Location = new Point(800, 125);
                        cell[i].BackColor = Color.Coral;
                        break;
                    case 17:
                        cell[i].Location = new Point(150, 150);
                        cell[i].BackColor = Color.Navy;
                        break;
                    case 18:
                        cell[i].Location = new Point(250, 150);
                        cell[i].BackColor = Color.Navy;
                        break;
                    case 19:
                        cell[i].Location = new Point(350, 150);
                        cell[i].BackColor = Color.Navy;
                        break;
                    case 20:
                        cell[i].Location = new Point(450, 150);
                        cell[i].BackColor = Color.Navy;
                        break;
                    case 21:
                        cell[i].Location = new Point(550, 150);
                        cell[i].BackColor = Color.Navy;
                        break;
                    case 22:
                        cell[i].Location = new Point(650, 150);
                        cell[i].BackColor = Color.Navy;
                        break;
                    case 23:
                        cell[i].Location = new Point(750, 150);
                        cell[i].BackColor = Color.Navy;
                        break;
                    case 24:
                        cell[i].Location = new Point(200, 175);
                        cell[i].BackColor = Color.Tan;
                        break;
                    case 25:
                        cell[i].Location = new Point(300, 175);
                        cell[i].BackColor = Color.Tan;
                        break;
                    case 26:
                        cell[i].Location = new Point(400, 175);
                        cell[i].BackColor = Color.Tan;
                        break;
                    case 27:
                        cell[i].Location = new Point(500, 175);
                        cell[i].BackColor = Color.Tan;
                        break;
                    case 28:
                        cell[i].Location = new Point(600, 175);
                        cell[i].BackColor = Color.Tan;
                        break;
                    case 29:
                        cell[i].Location = new Point(700, 175);
                        cell[i].BackColor = Color.Tan;
                        break;
                    
                }
            }
        }

        private static void unitLeftChanger()
        {
            Random r = new Random();
            int k = r.Next(0, 15);
            switch (k)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    unitLeft = 1;
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    unitLeft = 5;
                    break;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    unitLeft = 10;
                    break;
            }
        }

        private static void ballTimerInitialisation()
        {
            ballTimer.Interval = 40;
            ballTimer.SynchronizingObject = form;
            ballTimer.Enabled = true;
            ballTimer.Elapsed += BallTimer_Elapsed;
        }

        private static void BallTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            

            crashControl();
            unitControl();

            if(moveLeft && moveTop)
            { 
                ball.Left -= unitLeft;
                ball.Top -= unitTop;
            }
            else if (moveLeft && !moveTop)
            {
                ball.Left -= unitLeft;
                ball.Top += unitTop;
            }
            else if (!moveLeft && moveTop)
            {
                ball.Left += unitLeft;
                ball.Top -= unitTop;
            }
            else if (!moveLeft && !moveTop)
            {
                ball.Left += unitLeft;
                ball.Top += unitTop;
            }

            if (cellNumber <= 0)
            {
                buttonTimer.Stop();
                ballTimer.Stop();
                DialogResult result = MessageBox.Show("You WON\nDo you want to play?", "WIN", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    RestartGame();
                    
                }
                if (result == DialogResult.No)
                {
                    form.Close();
                }
                
            }
        }

        private static void crashControl()
        {
            for (int i = 0; i < 30; i++)
            {
                if ((ball.Left >= cell[i].Left && ball.Left <= (cell[i].Left + 100) && ball.Top >= cell[i].Top && ball.Top <=
                    (cell[i].Top + 25)) || ((ball.Left + 50) >= cell[i].Left && (ball.Left + 50) <= (cell[i].Left + 100) &&
                    ball.Top >= cell[i].Top && ball.Top <= (cell[i].Top + 25)) || (ball.Left >= cell[i].Left && ball.Left <=
                    (cell[i].Left + 100) && (ball.Top + 50) >= cell[i].Top && (ball.Top + 50) <= (cell[i].Top + 25)) || 
                    ((ball.Left + 50) >= cell[i].Left && (ball.Left + 50) <= (cell[i].Left + 100) && (ball.Top + 50) >= 
                    cell[i].Top && (ball.Top + 50) <= (cell[i].Top + 25)))
                {
                    cell[i].Left += 1000;
                    cell[i].Top += 1000;
                    moveTop = !moveTop;
                    cellNumber--;
                    break;
                }
            }
        }

        private static void unitControl()
        {
            
            if (ball.Left <= 0 )
            { moveLeft = false; }
            if (ball.Left >= 930)
            { moveLeft = true; }
            if (ball.Top <= 10)
            { moveTop = false; }
            if (ball.Top >= 580 && ball.Left >= (platform.Left - 30) && ball.Left <= (platform.Left + 230))
            {
                if (ball.Left >= (platform.Left - 50) && ball.Left < (platform.Left + 50))
                {
                    moveLeft = true;
                    unitLeftChanger();
                }
                else if (ball.Left >= (platform.Left + 50) && ball.Left <= (platform.Left + 150))
                {
                    unitLeftChanger();
                }
                else if (ball.Left > (platform.Left + 150) && ball.Left <= (platform.Left + 250))
                {
                    moveLeft = false;
                    unitLeftChanger();
                }
                moveTop = true;
                if (ballTimer.Interval >= 20)
                {
                    ballTimer.Interval -= 2;
                }
            }
            if (ball.Top >= 590)
            {
                buttonTimer.Stop();
                ballTimer.Stop();
                DialogResult result = MessageBox.Show("You LOSE\nDo you want to play again?", "LOSE", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    RestartGame();

                }
                if (result == DialogResult.No)
                {
                    form.Close();
                }
                
            }
        }

        private static void RestartGame()
        {
            ballTimer.Interval = 40;
            moveTop = true;

            for (int i = 0; i < 30; i++)
            {
                switch (i)
                {
                    case 0:
                        cell[i].Location = new Point(50, 100);
                        break;
                    case 1:
                        cell[i].Location = new Point(150, 100);
                        break;
                    case 2:
                        cell[i].Location = new Point(250, 100);
                        break;
                    case 3:
                        cell[i].Location = new Point(350, 100);
                        break;
                    case 4:
                        cell[i].Location = new Point(450, 100);
                        break;
                    case 5:
                        cell[i].Location = new Point(550, 100);
                        break;
                    case 6:
                        cell[i].Location = new Point(650, 100);
                        break;
                    case 7:
                        cell[i].Location = new Point(750, 100);
                        break;
                    case 8:
                        cell[i].Location = new Point(850, 100);
                        break;
                    case 9:
                        cell[i].Location = new Point(100, 125);
                        break;
                    case 10:
                        cell[i].Location = new Point(200, 125);
                        break;
                    case 11:
                        cell[i].Location = new Point(300, 125);
                        break;
                    case 12:
                        cell[i].Location = new Point(400, 125);
                        break;
                    case 13:
                        cell[i].Location = new Point(500, 125);
                        break;
                    case 14:
                        cell[i].Location = new Point(600, 125);
                        break;
                    case 15:
                        cell[i].Location = new Point(700, 125);
                        break;
                    case 16:
                        cell[i].Location = new Point(800, 125);
                        break;
                    case 17:
                        cell[i].Location = new Point(150, 150);
                        break;
                    case 18:
                        cell[i].Location = new Point(250, 150);
                        break;
                    case 19:
                        cell[i].Location = new Point(350, 150);
                        break;
                    case 20:
                        cell[i].Location = new Point(450, 150);
                        break;
                    case 21:
                        cell[i].Location = new Point(550, 150);
                        break;
                    case 22:
                        cell[i].Location = new Point(650, 150);
                        break;
                    case 23:
                        cell[i].Location = new Point(750, 150);
                        break;
                    case 24:
                        cell[i].Location = new Point(200, 175);
                        break;
                    case 25:
                        cell[i].Location = new Point(300, 175);
                        break;
                    case 26:
                        cell[i].Location = new Point(400, 175);
                        break;
                    case 27:
                        cell[i].Location = new Point(500, 175);
                        break;
                    case 28:
                        cell[i].Location = new Point(600, 175);
                        break;
                    case 29:
                        cell[i].Location = new Point(700, 175);
                        break;

                }
            }

            Random rnnew = new Random();
            int y = rnnew.Next(50, 901);
            ball.Location = new Point(y, 450);
            platformX = 400;
            platform.Location = new Point(platformX, 630);

            ballTimer.Start();
            buttonTimer.Start();
        }

        private static void ballInitialisation()
        {
            ball.Parent = form;
            ball.Image = Image.FromFile(@"C:\Users\Oleksandr\source\repos\FinalProject\ball.png");
            ball.Size = new Size(50, 50);
            Random rn = new Random();
            int y = rn.Next(50, 901);
            ball.Location = new Point(y, 450);
        }

        private static void platformInitialisation()
        {
            platform.Parent = form;
            platform.Location = new Point(platformX, 630);
            platform.Size = new Size(200, 25);
            platform.Enabled = true;

        }

        private static void formInitialisation()
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Brick Breaker";
            form.Size = new Size(1000, 694);
            form.AutoSize = false;
            form.BackColor = Color.White;
            form.MaximizeBox = false;
            form.KeyPreview = true;
            form.Enabled = true;

            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;
        }

        private static void buttonTimerInitialisation()
        {
            buttonTimer.Interval = 30;
            buttonTimer.SynchronizingObject = form;
            buttonTimer.Enabled = true;
            buttonTimer.Elapsed += ButtonTimer_Elapsed;
            buttonTimer.Start();
        }

        private static void ButtonTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (platform.Left >= 801)
            {
                platform.Left = 800;
                direction = 0;
            }
            if (platform.Left <= -1)
            {
                platform.Left = 0;
                direction = 0;
            }
            platform.Left += direction;
        }

        private static void Form_KeyUp(object sender, KeyEventArgs e)
        {
            direction = 0;
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                direction = -10;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                direction = 10;
            }
            else if (e.KeyCode == Keys.P)
            {
                Bitmap printscreen = new Bitmap(form.Width + 200, form.Height + 155);
                Graphics graphics = Graphics.FromImage(printscreen as Image);

                graphics.CopyFromScreen(350, 90, 0, 0, printscreen.Size);
                
                int count = Directory.EnumerateFiles(@"C:\Users\Oleksandr\source\repos\FinalProject\").Where(x => x.StartsWith("printscreen")).Count();
                printscreen.Save(String.Format(@"C:\Users\Oleksandr\source\repos\FinalProject\printscreen{0}.jpg", count), System.Drawing.Imaging.ImageFormat.Jpeg);

                printscreen.Dispose();
            }

        }
    }
}
