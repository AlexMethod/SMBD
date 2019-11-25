using SMDB.Classes;
using System.Windows.Forms;
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
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.MenuHConnectDB = new System.Windows.Forms.ToolStripButton();
            this.MenuHDisconnectDB = new System.Windows.Forms.ToolStripButton();
            this.MenuHNewDB = new System.Windows.Forms.ToolStripButton();
            this.MenuHDeleteDB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuHRunQuery = new System.Windows.Forms.ToolStripButton();
            this.Tools_Results = new System.Windows.Forms.SplitContainer();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.ImagesList = new System.Windows.Forms.ImageList(this.components);
            this.SQL_Table = new System.Windows.Forms.SplitContainer();
            this.SQLQuery = new System.Windows.Forms.TextBox();
            this.TableView = new System.Windows.Forms.DataGridView();
            this.MenuRightTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuRCreateTable = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRightTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuRTableAddAttribute = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuRTableDeleteTable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuRTableAddRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRAttribute = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuRAttributeEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuRAttributeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuHorizontal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tools_Results)).BeginInit();
            this.Tools_Results.Panel1.SuspendLayout();
            this.Tools_Results.Panel2.SuspendLayout();
            this.Tools_Results.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SQL_Table)).BeginInit();
            this.SQL_Table.Panel1.SuspendLayout();
            this.SQL_Table.Panel2.SuspendLayout();
            this.SQL_Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableView)).BeginInit();
            this.MenuRightTreeView.SuspendLayout();
            this.MenuRightTable.SuspendLayout();
            this.MenuRAttribute.SuspendLayout();
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
            this.MenuExit});
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
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(278, 30);
            this.MenuExit.Text = "Exit          Alt+F4";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
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
            this.MenuHDeleteDB,
            this.toolStripSeparator5,
            this.toolStripSeparator6,
            this.MenuHRunQuery});
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
            // 
            // MenuHRunQuery
            // 
            this.MenuHRunQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuHRunQuery.Image = global::SMDB.Properties.Resources.play;
            this.MenuHRunQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuHRunQuery.Name = "MenuHRunQuery";
            this.MenuHRunQuery.Size = new System.Drawing.Size(28, 28);
            this.MenuHRunQuery.Text = "Run Query";
            this.MenuHRunQuery.Click += new System.EventHandler(this.MenuHRunQuery_Click);
            // 
            // Tools_Results
            // 
            this.Tools_Results.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tools_Results.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tools_Results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tools_Results.Location = new System.Drawing.Point(0, 64);
            this.Tools_Results.Name = "Tools_Results";
            // 
            // Tools_Results.Panel1
            // 
            this.Tools_Results.Panel1.Controls.Add(this.TreeView);
            // 
            // Tools_Results.Panel2
            // 
            this.Tools_Results.Panel2.Controls.Add(this.SQL_Table);
            this.Tools_Results.Size = new System.Drawing.Size(1345, 551);
            this.Tools_Results.SplitterDistance = 243;
            this.Tools_Results.TabIndex = 4;
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
            this.TreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView_NodeMouseClick);
            this.TreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView_NodeMouseDoubleClick);
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
            this.ImagesList.Images.SetKeyName(31, "attribute1.png");
            this.ImagesList.Images.SetKeyName(32, "attribute2.png");
            this.ImagesList.Images.SetKeyName(33, "keyPK.png");
            this.ImagesList.Images.SetKeyName(34, "keyFK.png");
            // 
            // SQL_Table
            // 
            this.SQL_Table.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SQL_Table.Location = new System.Drawing.Point(0, 0);
            this.SQL_Table.Name = "SQL_Table";
            this.SQL_Table.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SQL_Table.Panel1
            // 
            this.SQL_Table.Panel1.Controls.Add(this.SQLQuery);
            // 
            // SQL_Table.Panel2
            // 
            this.SQL_Table.Panel2.Controls.Add(this.TableView);
            this.SQL_Table.Size = new System.Drawing.Size(1242, 902);
            this.SQL_Table.SplitterDistance = 236;
            this.SQL_Table.TabIndex = 1;
            // 
            // SQLQuery
            // 
            this.SQLQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SQLQuery.Location = new System.Drawing.Point(0, 0);
            this.SQLQuery.Multiline = true;
            this.SQLQuery.Name = "SQLQuery";
            this.SQLQuery.Size = new System.Drawing.Size(1240, 234);
            this.SQLQuery.TabIndex = 0;
            // 
            // TableView
            // 
            this.TableView.AllowUserToAddRows = false;
            this.TableView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.TableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableView.Location = new System.Drawing.Point(0, 0);
            this.TableView.Name = "TableView";
            this.TableView.ReadOnly = true;
            this.TableView.RowHeadersVisible = false;
            this.TableView.RowTemplate.Height = 28;
            this.TableView.Size = new System.Drawing.Size(1240, 660);
            this.TableView.TabIndex = 0;
            this.TableView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableView_CellClick);
            this.TableView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableView_CellValueChanged);
            this.TableView.CurrentCellDirtyStateChanged += new System.EventHandler(this.TableView_CurrentCellDirtyStateChanged);
            this.TableView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.TableView_EditingControlShowing);
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
            // MenuRightTable
            // 
            this.MenuRightTable.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuRightTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuRTableAddAttribute,
            this.toolStripSeparator1,
            this.MenuRTableDeleteTable,
            this.toolStripSeparator4,
            this.MenuRTableAddRecord});
            this.MenuRightTable.Name = "MenuRightTable";
            this.MenuRightTable.Size = new System.Drawing.Size(212, 106);
            // 
            // MenuRTableAddAttribute
            // 
            this.MenuRTableAddAttribute.Name = "MenuRTableAddAttribute";
            this.MenuRTableAddAttribute.Size = new System.Drawing.Size(211, 30);
            this.MenuRTableAddAttribute.Text = "Add Attribute";
            this.MenuRTableAddAttribute.Click += new System.EventHandler(this.MenuRTableAddAttribute_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // MenuRTableDeleteTable
            // 
            this.MenuRTableDeleteTable.Name = "MenuRTableDeleteTable";
            this.MenuRTableDeleteTable.Size = new System.Drawing.Size(211, 30);
            this.MenuRTableDeleteTable.Text = "Delete Table";
            this.MenuRTableDeleteTable.Click += new System.EventHandler(this.MenuRTableDeleteTable_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(208, 6);
            // 
            // MenuRTableAddRecord
            // 
            this.MenuRTableAddRecord.Name = "MenuRTableAddRecord";
            this.MenuRTableAddRecord.Size = new System.Drawing.Size(211, 30);
            this.MenuRTableAddRecord.Text = "Add new record";
            this.MenuRTableAddRecord.Click += new System.EventHandler(this.MenuRTableAddRecord_Click);
            // 
            // MenuRAttribute
            // 
            this.MenuRAttribute.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuRAttribute.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuRAttributeEdit,
            this.toolStripSeparator2,
            this.MenuRAttributeDelete,
            this.toolStripSeparator3});
            this.MenuRAttribute.Name = "MenuRAttribute";
            this.MenuRAttribute.Size = new System.Drawing.Size(210, 76);
            // 
            // MenuRAttributeEdit
            // 
            this.MenuRAttributeEdit.Name = "MenuRAttributeEdit";
            this.MenuRAttributeEdit.Size = new System.Drawing.Size(209, 30);
            this.MenuRAttributeEdit.Text = "Edit Attribute";
            this.MenuRAttributeEdit.Click += new System.EventHandler(this.MenuRAttributeEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(206, 6);
            // 
            // MenuRAttributeDelete
            // 
            this.MenuRAttributeDelete.Name = "MenuRAttributeDelete";
            this.MenuRAttributeDelete.Size = new System.Drawing.Size(209, 30);
            this.MenuRAttributeDelete.Text = "Delete Attribute";
            this.MenuRAttributeDelete.Click += new System.EventHandler(this.MenuRAttributeDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
            // 
            // SMBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1345, 615);
            this.Controls.Add(this.Tools_Results);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MenuHorizontal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SMBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMBD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuHorizontal.ResumeLayout(false);
            this.MenuHorizontal.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Tools_Results.Panel1.ResumeLayout(false);
            this.Tools_Results.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tools_Results)).EndInit();
            this.Tools_Results.ResumeLayout(false);
            this.SQL_Table.Panel1.ResumeLayout(false);
            this.SQL_Table.Panel1.PerformLayout();
            this.SQL_Table.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SQL_Table)).EndInit();
            this.SQL_Table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableView)).EndInit();
            this.MenuRightTreeView.ResumeLayout(false);
            this.MenuRightTable.ResumeLayout(false);
            this.MenuRAttribute.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem MenuExit;

        //MY VARIABLES-----------------------------------------------
        public string currentPath = "";
        private CREATE_DB Create_DB = new CREATE_DB();
        private CREATE_TABLE Create_Table;
        private CREATE_RECORD Create_Record;
        public Table TableSelected; 
        public string currentDB = "";
        public bool isEditDB = false;
        public bool isEditTable = false;
        public bool isEditAttribute = false;
        public Database DB = null;
        public bool isEditableTable = false;

        //-----------------------------------------------------------
        private System.Windows.Forms.ToolStripMenuItem MenuDeleteDB;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer Tools_Results;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton MenuHConnectDB;
        private System.Windows.Forms.ToolStripButton MenuHNewDB;
        private System.Windows.Forms.ToolStripButton MenuHDisconnectDB;
        private System.Windows.Forms.ContextMenuStrip MenuRightTreeView;
        private System.Windows.Forms.ToolStripMenuItem MenuRCreateTable;
        private System.Windows.Forms.ToolStripButton MenuHDeleteDB;
        private System.Windows.Forms.ImageList ImagesList;
        private System.Windows.Forms.ContextMenuStrip MenuRightTable;
        private System.Windows.Forms.ToolStripMenuItem MenuRTableDeleteTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuRTableAddAttribute;
        private System.Windows.Forms.ContextMenuStrip MenuRAttribute;
        private System.Windows.Forms.ToolStripMenuItem MenuRAttributeEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuRAttributeDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem MenuRTableAddRecord;
        private DataGridView TableView;
        private SplitContainer SQL_Table;
        private TextBox SQLQuery;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton MenuHRunQuery;
    }
}

