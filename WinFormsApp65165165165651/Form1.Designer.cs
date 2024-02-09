namespace WinFormsApp65165165165651
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ToolStrip toolStrip1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            closeButton = new ToolStripButton();
            printButton = new ToolStripButton();
            refreshButton = new ToolStripButton();
            stopButton = new ToolStripButton();
            toolStripLabel1 = new ToolStripLabel();
            player = new PictureBox();
            ball = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            doubleClickTimer = new System.Windows.Forms.Timer(components);
            printScore = new System.Drawing.Printing.PrintDocument();
            toolStrip1 = new ToolStrip();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.BackColor = Color.Black;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { closeButton, printButton, refreshButton, stopButton, toolStripLabel1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(878, 40);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // closeButton
            // 
            closeButton.Alignment = ToolStripItemAlignment.Right;
            closeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            closeButton.Image = (Image)resources.GetObject("closeButton.Image");
            closeButton.ImageTransparentColor = Color.Magenta;
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(29, 37);
            closeButton.Text = "toolStripButton1";
            closeButton.Click += closeButton_Click;
            // 
            // printButton
            // 
            printButton.Alignment = ToolStripItemAlignment.Right;
            printButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            printButton.Image = (Image)resources.GetObject("printButton.Image");
            printButton.ImageTransparentColor = Color.Magenta;
            printButton.Name = "printButton";
            printButton.Size = new Size(29, 37);
            printButton.Text = "toolStripButton1";
            printButton.Click += PrintGameInfo;
            // 
            // refreshButton
            // 
            refreshButton.Alignment = ToolStripItemAlignment.Right;
            refreshButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            refreshButton.DoubleClickEnabled = true;
            refreshButton.Image = (Image)resources.GetObject("refreshButton.Image");
            refreshButton.ImageTransparentColor = Color.Magenta;
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(29, 37);
            refreshButton.Text = "toolStripButton2";
            refreshButton.DoubleClick += refreshDoubleClick;
            refreshButton.MouseDown += refreshButton_Click;
            // 
            // stopButton
            // 
            stopButton.Alignment = ToolStripItemAlignment.Right;
            stopButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            stopButton.Image = (Image)resources.GetObject("stopButton.Image");
            stopButton.ImageTransparentColor = Color.Magenta;
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(29, 37);
            stopButton.Text = "toolStripButton3";
            stopButton.Click += stopButton_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripLabel1.ForeColor = Color.White;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(84, 37);
            toolStripLabel1.Text = "Score: 0";
            // 
            // player
            // 
            player.BackColor = Color.FromArgb(224, 224, 224);
            player.Location = new Point(353, 535);
            player.Margin = new Padding(3, 4, 3, 4);
            player.Name = "player";
            player.Size = new Size(114, 43);
            player.TabIndex = 1;
            player.TabStop = false;
            // 
            // ball
            // 
            ball.BackColor = Color.Yellow;
            ball.Location = new Point(399, 357);
            ball.Margin = new Padding(3, 4, 3, 4);
            ball.Name = "ball";
            ball.Size = new Size(29, 33);
            ball.TabIndex = 1;
            ball.TabStop = false;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 20;
            gameTimer.Tick += mainGameTimerEvent;
            // 
            // doubleClickTimer
            // 
            doubleClickTimer.Tick += doubleClickTimer_Tick;
            // 
            // printScore
            // 
            printScore.PrintPage += printScore_PrintPage;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(878, 643);
            Controls.Add(toolStrip1);
            Controls.Add(ball);
            Controls.Add(player);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            KeyDown += keyisdown;
            KeyUp += keyisup;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox player;
        private PictureBox ball;
        private System.Windows.Forms.Timer gameTimer;
        private ToolStrip toolStrip1;
        private ToolStripButton closeButton;
        private ToolStripButton refreshButton;
        private ToolStripButton stopButton;
        private ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Timer doubleClickTimer;
        private System.Drawing.Printing.PrintDocument printScore;
        private ToolStripButton printButton;
    }
}