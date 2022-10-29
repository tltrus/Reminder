namespace reminder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuFormShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuRightHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAnime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAutorun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timerOpacity = new System.Windows.Forms.Timer(this.components);
            this.timerHide = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Reminder";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAbout,
            this.toolStripSeparator2,
            this.toolStripMenuFormShow,
            this.toolStripMenuItem3,
            this.toolStripMenuTopMost,
            this.toolStripMenuRightHide,
            this.toolStripMenuAnime,
            this.toolStripMenuAutorun,
            this.toolStripSeparator1,
            this.toolStripMenuExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 208);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuAbout
            // 
            this.toolStripMenuAbout.Name = "toolStripMenuAbout";
            this.toolStripMenuAbout.Size = new System.Drawing.Size(188, 24);
            this.toolStripMenuAbout.Text = "О программе...";
            this.toolStripMenuAbout.Click += new System.EventHandler(this.toolStripMenuAbout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // toolStripMenuFormShow
            // 
            this.toolStripMenuFormShow.Name = "toolStripMenuFormShow";
            this.toolStripMenuFormShow.Size = new System.Drawing.Size(188, 24);
            this.toolStripMenuFormShow.Text = "Развернуть";
            this.toolStripMenuFormShow.Click += new System.EventHandler(this.toolStripMenuFormShow_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(188, 24);
            this.toolStripMenuItem3.Text = "Свернуть";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuTopMost
            // 
            this.toolStripMenuTopMost.CheckOnClick = true;
            this.toolStripMenuTopMost.Name = "toolStripMenuTopMost";
            this.toolStripMenuTopMost.Size = new System.Drawing.Size(188, 24);
            this.toolStripMenuTopMost.Text = "Поверх окон";
            this.toolStripMenuTopMost.CheckedChanged += new System.EventHandler(this.toolStripMenuTopMost_CheckedChanged);
            // 
            // toolStripMenuRightHide
            // 
            this.toolStripMenuRightHide.CheckOnClick = true;
            this.toolStripMenuRightHide.Name = "toolStripMenuRightHide";
            this.toolStripMenuRightHide.Size = new System.Drawing.Size(188, 24);
            this.toolStripMenuRightHide.Text = "Скрывать сбоку";
            this.toolStripMenuRightHide.CheckedChanged += new System.EventHandler(this.toolStripMenuRightHide_CheckedChanged);
            // 
            // toolStripMenuAnime
            // 
            this.toolStripMenuAnime.CheckOnClick = true;
            this.toolStripMenuAnime.Name = "toolStripMenuAnime";
            this.toolStripMenuAnime.Size = new System.Drawing.Size(188, 24);
            this.toolStripMenuAnime.Text = "Анимация окна";
            // 
            // toolStripMenuAutorun
            // 
            this.toolStripMenuAutorun.CheckOnClick = true;
            this.toolStripMenuAutorun.Name = "toolStripMenuAutorun";
            this.toolStripMenuAutorun.Size = new System.Drawing.Size(188, 24);
            this.toolStripMenuAutorun.Text = "Автозапуск";
            this.toolStripMenuAutorun.CheckedChanged += new System.EventHandler(this.toolStripMenuAutorun_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // toolStripMenuExit
            // 
            this.toolStripMenuExit.Name = "toolStripMenuExit";
            this.toolStripMenuExit.Size = new System.Drawing.Size(188, 24);
            this.toolStripMenuExit.Text = "Выход";
            this.toolStripMenuExit.Click += new System.EventHandler(this.ToolStripMenuExit_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Maroon;
            this.richTextBox1.Location = new System.Drawing.Point(8, 9);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(286, 287);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseDown);
            this.richTextBox1.MouseLeave += new System.EventHandler(this.richTextBox1_MouseLeave);
            this.richTextBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseMove);
            // 
            // timerOpacity
            // 
            this.timerOpacity.Tick += new System.EventHandler(this.timerOpacity_Tick);
            // 
            // timerHide
            // 
            this.timerHide.Interval = 10;
            this.timerHide.Tick += new System.EventHandler(this.timerHide_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 305);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.4D;
            this.ShowIcon = false;
            this.Text = "Reminder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFormShow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuExit;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuTopMost;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuRightHide;
        private System.Windows.Forms.Timer timerOpacity;
        private System.Windows.Forms.Timer timerHide;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAnime;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAutorun;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAbout;
    }
}

