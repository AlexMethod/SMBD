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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMBD));
            this.MenuHorizontal = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConnectDB = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDisconnectDB = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNewDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDeleteDB = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.MenuHConnectDB = new System.Windows.Forms.ToolStripButton();
            this.MenuHDisconnectDB = new System.Windows.Forms.ToolStripButton();
            this.MenuHNewDB = new System.Windows.Forms.ToolStripButton();
            this.MenuHDeleteDB = new System.Windows.Forms.ToolStripButton();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.ImagesList = new System.Windows.Forms.ImageList(this.components);
            this.MenuRightTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuRCreateTable = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHorizontal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.MenuRightTreeView.SuspendLayout();
            this.SuspendLayout();
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
            this.MenuNewDB});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(278, 30);
            this.newToolStripMenuItem.Text = "New";
            // 
            // MenuNewDB
            // 
            this.MenuNewDB.Image = global::SMDB.Properties.Resources.folderdb;
            this.MenuNewDB.Name = "MenuNewDB";
            this.MenuNewDB.Size = new System.Drawing.Size(271, 30);
            this.MenuNewDB.Text = "Database   Ctrl+Alt+N";
            this.MenuNewDB.Click += new System.EventHandler(this.MenuNewDB_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuDeleteDB});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(278, 30);
            this.toolStripMenuItem4.Text = "Close";
            // 
            // MenuDeleteDB
            // 
            this.MenuDeleteDB.Image = global::SMDB.Properties.Resources.deletedb;
            this.MenuDeleteDB.Name = "MenuDeleteDB";
            this.MenuDeleteDB.Size = new System.Drawing.Size(273, 30);
            this.MenuDeleteDB.Text = "Delete DB   Ctrl+Alt+X";
            this.MenuDeleteDB.Click += new System.EventHandler(this.MenuDeleteDB_Click);
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
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.MenuHConnectDB,
            this.MenuHDisconnectDB,
            this.MenuHNewDB,
            this.MenuHDeleteDB});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1345, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 28);
            this.toolStripLabel1.Text = "Database";
            // 
            // MenuHConnectDB
            // 
            this.MenuHConnectDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuHConnectDB.Image = global::SMDB.Properties.Resources.okdb;
            this.MenuHConnectDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuHConnectDB.Name = "MenuHConnectDB";
            this.MenuHConnectDB.Size = new System.Drawing.Size(28, 28);
            this.MenuHConnectDB.Text = "Connect DB";
            this.MenuHConnectDB.Click += new System.EventHandler(this.MenuHConnectDB_Click);
            // 
            // MenuHDisconnectDB
            // 
            this.MenuHDisconnectDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuHDisconnectDB.Image = global::SMDB.Properties.Resources.nodb;
            this.MenuHDisconnectDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuHDisconnectDB.Name = "MenuHDisconnectDB";
            this.MenuHDisconnectDB.Size = new System.Drawing.Size(28, 28);
            this.MenuHDisconnectDB.Text = "Disconnect DB";
            this.MenuHDisconnectDB.Click += new System.EventHandler(this.MenuHDisconnectDB_Click);
            // 
            // MenuHNewDB
            // 
            this.MenuHNewDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuHNewDB.Image = global::SMDB.Properties.Resources.folderdb;
            this.MenuHNewDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuHNewDB.Name = "MenuHNewDB";
            this.MenuHNewDB.Size = new System.Drawing.Size(28, 28);
            this.MenuHNewDB.Text = "Create DB";
            this.MenuHNewDB.Click += new System.EventHandler(this.MenuHNewDB_Click);
            // 
            // MenuHDeleteDB
            // 
            this.MenuHDeleteDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuHDeleteDB.Image = global::SMDB.Properties.Resources.deletedb;
            this.MenuHDeleteDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuHDeleteDB.Name = "MenuHDeleteDB";
            this.MenuHDeleteDB.Size = new System.Drawing.Size(28, 28);
            this.MenuHDeleteDB.Text = "Delete DB";
            this.MenuHDeleteDB.Click += new System.EventHandler(this.MenuHDeleteDB_Click);
            // 
            // SplitContainer
            // 
            this.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 64);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.TreeView);
            this.SplitContainer.Size = new System.Drawing.Size(1345, 551);
            this.SplitContainer.SplitterDistance = 243;
            this.SplitContainer.TabIndex = 4;
            // 
            // TreeView
            // 
            this.TreeView.Cursor = System.Windows.Forms.Cursors.Default;
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.ImageIndex = 16;
            this.TreeView.ImageList = this.ImagesList;
            this.TreeView.LabelEdit = true;
            this.TreeView.Location = new System.Drawing.Point(0, 0);
            this.TreeView.Name = "TreeView";
            this.TreeView.SelectedImageIndex = 0;
            this.TreeView.Size = new System.Drawing.Size(241, 549);
            this.TreeView.TabIndex = 0;
            this.TreeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeView_BeforeLabelEdit);
            this.TreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeView_AfterLabelEdit);
            // 
            // ImagesList
            // 
            this.ImagesList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImagesList.ImageStream")));
            this.ImagesList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImagesList.Images.SetKeyName(0, "table-icon.jpg");
            this.ImagesList.Images.SetKeyName(1, "background.jpg");
            this.ImagesList.Images.SetKeyName(2, "bd.png");
            this.ImagesList.Images.SetKeyName(3, "bdblue.png");
            this.ImagesList.Images.SetKeyName(4, "computerdb.jpg");
            this.ImagesList.Images.SetKeyName(5, "connectdb.jpg");
            this.ImagesList.Images.SetKeyName(6, "db.ico");
            this.ImagesList.Images.SetKeyName(7, "DB_Architecture.png");
            this.ImagesList.Images.SetKeyName(8, "dbPlatinum.ico");
            this.ImagesList.Images.SetKeyName(9, "deletedb.png");
            this.ImagesList.Images.SetKeyName(10, "dotteddb.png");
            this.ImagesList.Images.SetKeyName(11, "filedb.png");
            this.ImagesList.Images.SetKeyName(12, "folderdb.png");
            this.ImagesList.Images.SetKeyName(13, "healthdb.png");
            this.ImagesList.Images.SetKeyName(14, "keydb.png");
            this.ImagesList.Images.SetKeyName(15, "lockdb.png");
            this.ImagesList.Images.SetKeyName(16, "nodb.png");
            this.ImagesList.Images.SetKeyName(17, "okdb.png");
            this.ImagesList.Images.SetKeyName(18, "plusdb.png");
            this.ImagesList.Images.SetKeyName(19, "positiondb.jpg");
            this.ImagesList.Images.SetKeyName(20, "projectdb.png");
            this.ImagesList.Images.SetKeyName(21, "relationdb.jpg");
            this.ImagesList.Images.SetKeyName(22, "reloaddb.png");
            this.ImagesList.Images.SetKeyName(23, "searchdb.png");
            this.ImagesList.Images.SetKeyName(24, "settingsdb.png");
            this.ImagesList.Images.SetKeyName(25, "severaldb.png");
            this.ImagesList.Images.SetKeyName(26, "tooldb.png");
            this.ImagesList.Images.SetKeyName(27, "uploaddb.jpg");
            this.ImagesList.Images.SetKeyName(28, "user.png");
            this.ImagesList.Images.SetKeyName(29, "userdb.png");
            this.ImagesList.Images.SetKeyName(30, "usersdb.png");
            // 
            // MenuRightTreeView
            // 
            this.MenuRightTreeView.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuRightTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuRCreateTable});
            this.MenuRightTreeView.Name = "MenuRightTreeView";
            this.MenuRightTreeView.Size = new System.Drawing.Size(179, 34);
            // 
            // MenuRCreateTable
            // 
            this.MenuRCreateTable.Name = "MenuRCreateTable";
            this.MenuRCreateTable.Size = new System.Drawing.Size(178, 30);
            this.MenuRCreateTable.Text = "Create table";
            this.MenuRCreateTable.Click += new System.EventHandler(this.MenuRCreateTable_Click);
            // 
            // SMBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1345, 615);
            this.Controls.Add(this.SplitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MenuHorizontal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SMBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMBD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MenuHorizontal.ResumeLayout(false);
            this.MenuHorizontal.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.SplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.MenuRightTreeView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuHorizontal;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuConnectDB;
        private System.Windows.Forms.ToolStripMenuItem MenuDisconnectDB;
        private System.Windows.Forms.ToolStripMenuItem MenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuNewDB;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem MenuSeparator4;
        private System.Windows.Forms.ToolStripMenuItem MenuRecentFiles;
        private System.Windows.Forms.ToolStripMenuItem MenuSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;

        //MY VARIABLES-----------------------------------------------
        public string currentPath = "";
        private CREATE_DB Create_DB = new CREATE_DB();
        private CREATE_TABLE Create_Table = new CREATE_TABLE();
        public string currentDB = "";

        //-----------------------------------------------------------
        private System.Windows.Forms.ToolStripMenuItem MenuDeleteDB;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton MenuHConnectDB;
        private System.Windows.Forms.ToolStripButton MenuHNewDB;
        private System.Windows.Forms.ToolStripButton MenuHDisconnectDB;
        private System.Windows.Forms.ContextMenuStrip MenuRightTreeView;
        private System.Windows.Forms.ToolStripMenuItem MenuRCreateTable;
        private System.Windows.Forms.ToolStripButton MenuHDeleteDB;
        private System.Windows.Forms.ImageList ImagesList;

    }
}

