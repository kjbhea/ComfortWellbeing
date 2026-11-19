namespace ComfortWellbeing.ui
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.시스템ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.메인업무ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.코드관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.시스템ToolStripMenuItem,
            this.메인업무ToolStripMenuItem,
            this.코드관리ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1029, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 시스템ToolStripMenuItem
            // 
            this.시스템ToolStripMenuItem.Name = "시스템ToolStripMenuItem";
            this.시스템ToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.시스템ToolStripMenuItem.Text = "시스템";
            // 
            // 메인업무ToolStripMenuItem
            // 
            this.메인업무ToolStripMenuItem.Name = "메인업무ToolStripMenuItem";
            this.메인업무ToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.메인업무ToolStripMenuItem.Text = "메인업무";
            this.메인업무ToolStripMenuItem.Click += new System.EventHandler(this.메인업무ToolStripMenuItem_Click);
            // 
            // 코드관리ToolStripMenuItem
            // 
            this.코드관리ToolStripMenuItem.Name = "코드관리ToolStripMenuItem";
            this.코드관리ToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.코드관리ToolStripMenuItem.Text = "코드관리";
            this.코드관리ToolStripMenuItem.Click += new System.EventHandler(this.코드관리ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 638);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 시스템ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 메인업무ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 코드관리ToolStripMenuItem;
    }
}