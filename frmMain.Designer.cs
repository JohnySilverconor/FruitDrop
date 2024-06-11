namespace com.langesite.fruitdrop
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuSoundOn = new System.Windows.Forms.MenuItem();
            this.menuSoundOff = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.pbGameBox = new System.Windows.Forms.PictureBox();
            this.lblScoreLabel = new System.Windows.Forms.Label();
            this.lblScoreValue = new System.Windows.Forms.Label();
            this.pbOne = new System.Windows.Forms.PictureBox();
            this.pbTwo = new System.Windows.Forms.PictureBox();
            this.pbThree = new System.Windows.Forms.PictureBox();
            this.pbFour = new System.Windows.Forms.PictureBox();
            this.pbFive = new System.Windows.Forms.PictureBox();
            this.pbZero = new System.Windows.Forms.PictureBox();
            this.lblLine = new System.Windows.Forms.Label();
            this.pbPop = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem3);
            this.menuItem1.MenuItems.Add(this.menuItem5);
            this.menuItem1.MenuItems.Add(this.menuItem4);
            this.menuItem1.Text = "Game";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "New";
            this.menuItem3.Click += new System.EventHandler(this.menuGameNew_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.MenuItems.Add(this.menuSoundOn);
            this.menuItem5.MenuItems.Add(this.menuSoundOff);
            this.menuItem5.Text = "Sound";
            // 
            // menuSoundOn
            // 
            this.menuSoundOn.Checked = true;
            this.menuSoundOn.Text = "On";
            this.menuSoundOn.Click += new System.EventHandler(this.menuSoundOn_Click);
            // 
            // menuSoundOff
            // 
            this.menuSoundOff.Text = "Off";
            this.menuSoundOff.Click += new System.EventHandler(this.menuSoundOff_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Exit";
            this.menuItem4.Click += new System.EventHandler(this.menuGameExit_Click);
            // 
            // pbGameBox
            // 
            this.pbGameBox.BackColor = System.Drawing.Color.Transparent;
            this.pbGameBox.Location = new System.Drawing.Point(3, 27);
            this.pbGameBox.Name = "pbGameBox";
            this.pbGameBox.Size = new System.Drawing.Size(234, 238);
            this.pbGameBox.Click += new System.EventHandler(this.pbGameBox_Click);
            // 
            // lblScoreLabel
            // 
            this.lblScoreLabel.Location = new System.Drawing.Point(4, 4);
            this.lblScoreLabel.Name = "lblScoreLabel";
            this.lblScoreLabel.Size = new System.Drawing.Size(40, 20);
            this.lblScoreLabel.Text = "Score:";
            // 
            // lblScoreValue
            // 
            this.lblScoreValue.Location = new System.Drawing.Point(41, 4);
            this.lblScoreValue.Name = "lblScoreValue";
            this.lblScoreValue.Size = new System.Drawing.Size(100, 19);
            // 
            // pbOne
            // 
            this.pbOne.BackColor = System.Drawing.Color.Transparent;
            this.pbOne.Image = ((System.Drawing.Image)(resources.GetObject("pbOne.Image")));
            this.pbOne.Location = new System.Drawing.Point(174, 179);
            this.pbOne.Name = "pbOne";
            this.pbOne.Size = new System.Drawing.Size(28, 32);
            this.pbOne.Visible = false;
            // 
            // pbTwo
            // 
            this.pbTwo.BackColor = System.Drawing.Color.Transparent;
            this.pbTwo.Image = ((System.Drawing.Image)(resources.GetObject("pbTwo.Image")));
            this.pbTwo.Location = new System.Drawing.Point(38, 179);
            this.pbTwo.Name = "pbTwo";
            this.pbTwo.Size = new System.Drawing.Size(28, 32);
            this.pbTwo.Visible = false;
            // 
            // pbThree
            // 
            this.pbThree.BackColor = System.Drawing.Color.Transparent;
            this.pbThree.Image = ((System.Drawing.Image)(resources.GetObject("pbThree.Image")));
            this.pbThree.Location = new System.Drawing.Point(72, 179);
            this.pbThree.Name = "pbThree";
            this.pbThree.Size = new System.Drawing.Size(28, 32);
            this.pbThree.Visible = false;
            // 
            // pbFour
            // 
            this.pbFour.BackColor = System.Drawing.Color.Transparent;
            this.pbFour.Image = ((System.Drawing.Image)(resources.GetObject("pbFour.Image")));
            this.pbFour.Location = new System.Drawing.Point(106, 179);
            this.pbFour.Name = "pbFour";
            this.pbFour.Size = new System.Drawing.Size(28, 32);
            this.pbFour.Visible = false;
            // 
            // pbFive
            // 
            this.pbFive.BackColor = System.Drawing.Color.Transparent;
            this.pbFive.Image = ((System.Drawing.Image)(resources.GetObject("pbFive.Image")));
            this.pbFive.Location = new System.Drawing.Point(140, 179);
            this.pbFive.Name = "pbFive";
            this.pbFive.Size = new System.Drawing.Size(28, 32);
            this.pbFive.Visible = false;
            // 
            // pbZero
            // 
            this.pbZero.BackColor = System.Drawing.Color.Transparent;
            this.pbZero.Image = ((System.Drawing.Image)(resources.GetObject("pbZero.Image")));
            this.pbZero.Location = new System.Drawing.Point(41, 141);
            this.pbZero.Name = "pbZero";
            this.pbZero.Size = new System.Drawing.Size(28, 32);
            this.pbZero.Visible = false;
            // 
            // lblLine
            // 
            this.lblLine.BackColor = System.Drawing.Color.Black;
            this.lblLine.Location = new System.Drawing.Point(0, 20);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(240, 2);
            // 
            // pbPop
            // 
            this.pbPop.BackColor = System.Drawing.Color.Transparent;
            this.pbPop.Image = ((System.Drawing.Image)(resources.GetObject("pbPop.Image")));
            this.pbPop.Location = new System.Drawing.Point(75, 141);
            this.pbPop.Name = "pbPop";
            this.pbPop.Size = new System.Drawing.Size(28, 32);
            this.pbPop.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pbPop);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.pbZero);
            this.Controls.Add(this.pbFive);
            this.Controls.Add(this.pbFour);
            this.Controls.Add(this.pbThree);
            this.Controls.Add(this.pbTwo);
            this.Controls.Add(this.pbOne);
            this.Controls.Add(this.lblScoreValue);
            this.Controls.Add(this.lblScoreLabel);
            this.Controls.Add(this.pbGameBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "frmMain";
            this.Text = "Fruit Drop";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGameBox;
        private System.Windows.Forms.Label lblScoreLabel;
        private System.Windows.Forms.Label lblScoreValue;
        private System.Windows.Forms.PictureBox pbOne;
        private System.Windows.Forms.PictureBox pbTwo;
        private System.Windows.Forms.PictureBox pbThree;
        private System.Windows.Forms.PictureBox pbFour;
        private System.Windows.Forms.PictureBox pbFive;
        private System.Windows.Forms.PictureBox pbZero;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.PictureBox pbPop;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuSoundOn;
        private System.Windows.Forms.MenuItem menuSoundOff;
    }
}

