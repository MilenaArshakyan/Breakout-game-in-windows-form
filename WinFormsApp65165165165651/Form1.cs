using System.IO;

namespace WinFormsApp65165165165651
{
    public partial class Form1 : Form
    {
        bool goLeft;
        bool goRight;
        bool isGameOver;
        bool isPaused = false;
        int score;
        int ballx;
        int bally;
        int playerSpeed;

        string path = "info.txt";

        Random rnd = new Random();
        PictureBox[] blockArray;

        public Form1()
        {
            InitializeComponent();
            PlaceBlocks();
            doubleClickTimer.Interval = 500;
        }

        private void setupGame()
        {
            isGameOver = false;
            score = 0;
            ballx = 5;
            bally = 5;
            playerSpeed = 12;
            toolStripLabel1.Text = "Score: " + score;
            //  349, 268
            ball.Left = 355;
            ball.Top = 268;
            player.Left = 312;
            gameTimer.Start();

            //List<PictureBox> pbs = panel1.Controls.Cast<PictureBox>().ToList();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "blocks")
                {
                    x.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                }
            }
        }

        private void gameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            toolStripLabel1.Text = "Score: " + score + " " + message;
        }

        private void PlaceBlocks()
        {
            blockArray = new PictureBox[15];
            int a = 0;
            int top = 50;
            int left = 100;

            for (int i = 0; i < blockArray.Length; i++)
            {
                blockArray[i] = new PictureBox();
                blockArray[i].Height = 32;
                blockArray[i].Width = 100;
                blockArray[i].Tag = "blocks";
                blockArray[i].BackColor = Color.White;

                if (a == 5)
                {
                    top = top + 50;
                    left = 100;
                    a = 0;
                }

                if (a < 5)
                {
                    a++;
                    blockArray[i].Left = left;
                    blockArray[i].Top = top;
                    this.Controls.Add(blockArray[i]);
                    left = left + 130;
                }
            }
            setupGame();
        }

        private void removeBlocks()
        {
            foreach (PictureBox x in blockArray)
            {
                this.Controls.Remove(x);
            }
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "Score: " + score;

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }

            if (goRight == true && player.Left < 683)
            {
                player.Left += playerSpeed;
            }

            ball.Left += ballx;
            ball.Top += bally;

            if (ball.Left < 0 || ball.Left > 759)
            {
                ballx = -ballx;
            }
            if (ball.Top < 33)
            {
                bally = -bally;
            }

            if (ball.Bounds.IntersectsWith(player.Bounds))
            {
                ball.Top = 378;
                bally = rnd.Next(5, 12) * -1;

                if (ballx < 0)
                {
                    ballx = rnd.Next(5, 12) * -1;
                }
                else
                {
                    ballx = rnd.Next(5, 12);
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "blocks")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;
                        bally = -bally;
                        this.Controls.Remove(x);
                    }
                }
            }

            if (score == 15)
            {
                gameOver("You Win!! Press Enter to Play Again");
            }
            if (ball.Top > 530)
            {
                gameOver("You Lose!! Press Enter to Try Again");
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                removeBlocks();
                PlaceBlocks();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            File.Delete(path);
            Close();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                gameTimer.Stop();
            }
            else
            {
                gameTimer.Start();
            }
        }

        private void doubleClickTimer_Tick(object sender, EventArgs e)
        {
            doubleClickTimer.Stop();
            if (isPaused)
            {
                DialogResult refresh = MessageBox.Show("Do you really wanna refresh the game?", "", MessageBoxButtons.YesNo);
                if (refresh == DialogResult.Yes)
                {
                    refreshGame();
                    isPaused = false;
                }
            }
            else
            {
                refreshGame();
            }

        }
        private void refreshGame()
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(toolStripLabel1.Text + " Refresh\n");
            }
            gameTimer.Stop();
            removeBlocks();
            PlaceBlocks();
            gameTimer.Start();
        }

        private void refreshDoubleClick(object sender, EventArgs e)
        {
            doubleClickTimer.Stop();
            refreshGame();
        }

        private void refreshButton_Click(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1)
            {
                doubleClickTimer.Start();
            }
        }

        private void printScore_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string filePath = @"info.txt";

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                Font font = new Font("Arial", 14);

                float lineHeight = font.GetHeight(e.Graphics);
                float y = e.MarginBounds.Top;

                while (y + lineHeight < e.MarginBounds.Bottom && !streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    e.Graphics.DrawString(line, font, Brushes.Black, e.MarginBounds.Left, y);
                    y += lineHeight;
                }

                e.HasMorePages = !streamReader.EndOfStream;

            }
        }

        private void PrintGameInfo(object sender, EventArgs e)
        {
            gameTimer.Stop();
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printScore;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printScore.Print();
            }
        }
    }
}
