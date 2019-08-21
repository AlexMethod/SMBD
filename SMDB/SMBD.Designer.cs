namespace SMDB
{
    partial class SMBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMBD));
            this.MenuCurrentDB = new System.Windows.Forms.MenuStrip();
            this.MenuSeparator5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHorizontal = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConnectDB = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDisconnectDB = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNewDB = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDeleteDB = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.MenuCurrentDB.SuspendLayout();
            this.MenuHorizontal.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuCurrentDB
            // 
            this.MenuCurrentDB.AllowMerge = false;
            this.MenuCurrentDB.AutoSize = false;
            this.MenuCurrentDB.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuCurrentDB.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuCurrentDB.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MenuCurrentDB.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuCurrentDB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSeparator5});
            this.MenuCurrentDB.Location = new System.Drawing.Point(0, 33);
            this.MenuCurrentDB.Name = "MenuCurrentDB";
            this.MenuCurrentDB.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuCurrentDB.Size = new System.Drawing.Size(202, 582);
            this.MenuCurrentDB.TabIndex = 1;
            this.MenuCurrentDB.Text = "menuStrip2";
            // 
            // MenuSeparator5
            // 
            this.MenuSeparator5.Name = "MenuSeparator5";
            this.MenuSeparator5.Size = new System.Drawing.Size(198, 29);
            this.MenuSeparator5.Text = "-----------------------";
            // 
            // MenuHorizontal
            // 
            this.MenuHorizontal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuHorizontal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.MenuHorizontal.Location = new System.Drawing.Point(0, 0);
            this.MenuHorizontal.Name = "MenuHorizontal";
            this.MenuHorizontal.Size = new System.Drawing.Size(1345, 33);
            this.MenuHorizontal.TabIndex = 2;
            this.MenuHorizontal.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuConnectDB,
            this.MenuDisconnectDB,
            this.MenuSeparator1,
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem4,
            this.MenuSeparator4,
            this.MenuRecentFiles,
            this.MenuSeparator3,
            this.toolStripMenuItem6});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MenuConnectDB
            // 
            this.MenuConnectDB.Image = global::SMDB.Properties.Resources.okdb;
            this.MenuConnectDB.Name = "MenuConnectDB";
            this.MenuConnectDB.Size = new System.Drawing.Size(278, 30);
            this.MenuConnectDB.Text = "Connect DB   Ctrl+C";
            this.MenuConnectDB.Click += new System.EventHandler(this.MenuConnectDB_Click);
            // 
            // MenuDisconnectDB
            // 
            this.MenuDisconnectDB.Image = global::SMDB.Properties.Resources.nodb;
            this.MenuDisconnectDB.Name = "MenuDisconnectDB";
            this.MenuDisconnectDB.Size = new System.Drawing.Size(278, 30);
            this.MenuDisconnectDB.Text = "Disconnect DB   Ctrl+D";
            this.MenuDisconnectDB.Click += new System.EventHandler(this.MenuDisconnectDB_Click);
            // 
            // MenuSeparator1
            // 
            this.MenuSeparator1.Name = "MenuSeparator1";
            this.MenuSeparator1.Size = new System.Drawing.Size(278, 30);
            this.MenuSeparator1.Text = "-----------------------";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNewProject,
            this.MenuNewFile,
            this.MenuSeparator2,
            this.MenuNewDB});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(278, 30);
            this.newToolStripMenuItem.Text = "New";
            // 
            // MenuNewProject
            // 
            this.MenuNewProject.Image = global::SMDB.Properties.Resources.projectdb;
            this.MenuNewProject.Name = "MenuNewProject";
            this.MenuNewProject.Size = new System.Drawing.Size(271, 30);
            this.MenuNewProject.Text = "Project   Ctrl+Shift+N";
            // 
            // MenuNewFile
            // 
            this.MenuNewFile.Image = global::SMDB.Properties.Resources.filedb;
            this.MenuNewFile.Name = "MenuNewFile";
            this.MenuNewFile.Size = new System.Drawing.Size(271, 30);
            this.MenuNewFile.Text = "File   Ctrl+N";
            // 
            // MenuSeparator2
            // 
            this.MenuSeparator2.Name = "MenuSeparator2";
            this.MenuSeparator2.Size = new System.Drawing.Size(271, 30);
            this.MenuSeparator2.Text = "-----------------------";
            // 
            // MenuNewDB
            // 
            this.MenuNewDB.Image = global::SMDB.Properties.Resources.folderdb;
            this.MenuNewDB.Name = "MenuNewDB";
            this.MenuNewDB.Size = new System.Drawing.Size(271, 30);
            this.MenuNewDB.Text = "Database   Ctrl+Alt+N";
            this.MenuNewDB.Click += new System.EventHandler(this.MenuNewDB_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem2,
            this.fileToolStripMenuItem2});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(278, 30);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // projectToolStripMenuItem2
            // 
            this.projectToolStripMenuItem2.Image = global::SMDB.Properties.Resources.folderdb;
            this.projectToolStripMenuItem2.Name = "projectToolStripMenuItem2";
            this.projectToolStripMenuItem2.Size = new System.Drawing.Size(266, 30);
            this.projectToolStripMenuItem2.Text = "Project   Ctrl+Shift+O";
            // 
            // fileToolStripMenuItem2
            // 
            this.fileToolStripMenuItem2.Image = global::SMDB.Properties.Resources.filedb;
            this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
            this.fileToolStripMenuItem2.Size = new System.Drawing.Size(266, 30);
            this.fileToolStripMenuItem2.Text = "File   Ctrl+O";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuClose,
            this.MenuDeleteDB});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(278, 30);
            this.toolStripMenuItem4.Text = "Close";
            // 
            // MenuClose
            // 
            this.MenuClose.Image = global::SMDB.Properties.Resources.keydb;
            this.MenuClose.Name = "MenuClose";
            this.MenuClose.Size = new System.Drawing.Size(273, 30);
            this.MenuClose.Text = "Close   Ctrl+X";
            // 
            // MenuDeleteDB
            // 
            this.MenuDeleteDB.Image = global::SMDB.Properties.Resources.deletedb;
            this.MenuDeleteDB.Name = "MenuDeleteDB";
            this.MenuDeleteDB.Size = new System.Drawing.Size(273, 30);
            this.MenuDeleteDB.Text = "Delete DB   Ctrl+Alt+X";
            // 
            // MenuSeparator4
            // 
            this.MenuSeparator4.Name = "MenuSeparator4";
            this.MenuSeparator4.Size = new System.Drawing.Size(278, 30);
            this.MenuSeparator4.Text = "-----------------------";
            // 
            // MenuRecentFiles
            // 
            this.MenuRecentFiles.Name = "MenuRecentFiles";
            this.MenuRecentFiles.Size = new System.Drawing.Size(278, 30);
            this.MenuRecentFiles.Text = "Recent files";
            // 
            // MenuSeparator3
            // 
            this.MenuSeparator3.Name = "MenuSeparator3";
            this.MenuSeparator3.Size = new System.Drawing.Size(278, 30);
            this.MenuSeparator3.Text = "-----------------------";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(278, 30);
            this.toolStripMenuItem6.Text = "Exit          Alt+F4";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // SMBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1345, 615);
            this.Controls.Add(this.MenuCurrentDB);
            this.Controls.Add(this.MenuHorizontal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SMBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMBD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MenuCurrentDB.ResumeLayout(false);
            this.MenuCurrentDB.PerformLayout();
            this.MenuHorizontal.ResumeLayout(false);
            this.MenuHorizontal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuCurrentDB;
        private System.Windows.Forms.MenuStrip MenuHorizontal;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem MenuConnectDB;
        private System.Windows.Forms.ToolStripMenuItem MenuDisconnectDB;
        private System.Windows.Forms.ToolStripMenuItem MenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuNewProject;
        private System.Windows.Forms.ToolStripMenuItem MenuNewFile;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuNewDB;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem MenuSeparator4;
        private System.Windows.Forms.ToolStripMenuItem MenuRecentFiles;
        private System.Windows.Forms.ToolStripMenuItem MenuSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;

        //MY VARIABLES-----------------------------------------------
        public string currentPath = "";
        private CREATE_DB Create_DB = new CREATE_DB();
        public string currentDB = "";

        //-----------------------------------------------------------
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuClose;
        private System.Windows.Forms.ToolStripMenuItem MenuDeleteDB;
        private System.Windows.Forms.ToolStripMenuItem MenuSeparator5;

    }
}

