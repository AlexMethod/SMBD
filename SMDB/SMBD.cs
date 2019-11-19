using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMDB.Classes;
using System.IO;

namespace SMDB
{
    public partial class SMBD : Form
    {
        #region SMDB
        //APP CONSTRUCTOR
        public SMBD()
        {
            InitializeComponent();

            /*
             * INITIAL VALUES 
             */

            //Size Properties
            this.WindowState = FormWindowState.Maximized;
            TreeView.Width = this.Width;
            TreeView.Height = this.Height;
            Tools_Results.Width = this.Width;
            Tools_Results.Height = this.Height;

            this.MinimumSize = this.Size;

            //Menu Properties
            MenuSeparator1.Enabled = false;
            MenuSeparator4.Enabled = false;
            MenuSeparator3.Enabled = false;


            MenuDisconnectDB.Enabled = false;
            MenuDeleteDB.Enabled = false;
            MenuHDisconnectDB.Enabled = false;
            MenuHDeleteDB.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //FIRST HORIZONTAL MENU
        #region MENU_OPTIONS
        private void MenuNewDB_Click(object sender, EventArgs e)
        {
            CreateDatabase();
        }
        private void MenuConnectDB_Click(object sender, EventArgs e)
        {
            OpenDatabase();
        }
        private void MenuDisconnectDB_Click(object sender, EventArgs e)
        {
            //Close
        }
        private void MenuClose_Click(object sender, EventArgs e)
        {

        }
        private void MenuDeleteDB_Click(object sender, EventArgs e)
        {
            DeleteDatabase();
        }
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        //SECOND HORIZONTAL MENU
        #region MENU_HORIZONTAL_OPTIONS
        private void MenuHConnectDB_Click(object sender, EventArgs e)
        {
            OpenDatabase();
        }
        private void MenuHDisconnectDB_Click(object sender, EventArgs e)
        {
            CloseDatabase();
        }
        private void MenuHNewDB_Click(object sender, EventArgs e)
        {
            CreateDatabase();
        }
        private void MenuHDeleteDB_Click(object sender, EventArgs e)
        {
            DeleteDatabase();
        }
        #endregion
        //REFRESH
        #region UPDATES
        public void MenuUpdate(bool enable)
        {
            /**Desactiva o activa los botones dependiendo de si hay una 
             * actual base de datos o no
             * */
            if (enable)
            {
                //Menu update
                MenuDisconnectDB.Enabled = true;
                MenuHDisconnectDB.Enabled = true;
                MenuHDeleteDB.Enabled = true;
                MenuDeleteDB.Enabled = true;
            }
            else
            {
                //Menu update
                MenuDisconnectDB.Enabled = false;
                MenuHDisconnectDB.Enabled = false;
                MenuDeleteDB.Enabled = false;
                MenuHDeleteDB.Enabled = false;
            }
        }
        public void TitleUpdate()
        {
            this.Text = DB.Path;
        }
        public void DisplayDB()
        {
            TreeView.Nodes.Clear();

            TreeNode[] tables = new TreeNode[DB.tables.Count];
            for (int indexTable = 0; indexTable < tables.Length; indexTable++)
            {
                Table t = DB.tables[indexTable];
                if(t.attributes.Count > 0)
                {
                    TreeNode[] attributes = new TreeNode[t.attributes.Count];
                    for (int indexAttr = 0; indexAttr < t.attributes.Count; indexAttr++)
                    {
                        Attribute_ attr = t.attributes[indexAttr];
                        if(attr.KT == "PK")
                        {
                            attributes[indexAttr] = new TreeNode(attr.Name, 33, 33);
                        }
                        else if (attr.KT == "FK")
                        {
                            attributes[indexAttr] = new TreeNode(attr.Name, 34, 34);
                        }
                        else
                        {
                            attributes[indexAttr] = new TreeNode(attr.Name, 32, 32);
                        }


                        
                        attributes[indexAttr].ContextMenuStrip = MenuRAttribute;
                    }
                    tables[indexTable] = new TreeNode(t.ShortName,0,0, attributes);
                }
                else
                {
                    tables[indexTable] = new TreeNode(t.ShortName,0,0);
                }
                tables[indexTable].ContextMenuStrip = MenuRightTable;
            }

            TreeNode rootDatabase = new TreeNode(DB.Name, 10, 10, tables);
            TreeView.Nodes.Add(rootDatabase);
            rootDatabase.ContextMenuStrip = MenuRightTreeView;
            //TreeView.ExpandAll();
            ExpandToLevel(TreeView.Nodes, 1);

        }
        #endregion
        //KEYBOARD COMMANDS FOR QUICK ACCESS
        #region SHORTCUTS
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.C)) //CONNECT
            {
                //MessageBox.Show("CONNECT TO DATABASE");
                OpenDatabase();
                return true;
            }
            if (keyData == (Keys.Control | Keys.D)) //DISCONNECT
            {
                MessageBox.Show("DISCONNECT FROM DATABASE");
                return true;
            }
            if (keyData == (Keys.Alt | Keys.Control | Keys.N)) //NEW DATABASE
            {
                //MessageBox.Show("NEW DATABASE");
                CreateDatabase();
                return true;
            }
            if (keyData == (Keys.Control | Keys.Alt | Keys.X)) //DELETE DB
            {
                DeleteDatabase();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        #endregion

        #region DATABASE
        public void CreateDatabase()
        {
            Create_DB = new CREATE_DB();
            Create_DB.Parent_SMBD = this;
            Create_DB.Show();
        }
        public void DeleteDatabase()
        {
            string messageAnswer = String.Format("Are you sure you want to delete the current Database{0}{1}", Environment.NewLine, DB.Name);
            string messageError = "The object is not available";
            if (DB.isDB())
            {
                DialogResult result = MessageBox.Show(messageAnswer, "Delete Database!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DB.Delete();
                    Text = "SMBD";
                    MenuUpdate(false);
                    TreeView.Nodes.Clear();
                }
            }
            else
            {
                MessageBox.Show(messageError, "Invalid Object", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void RenameDatabase(string newName)
        {
            if (newName != null && newName != "")
            {
                DB.Rename(newName);
            }
            else
            {
                string message = "The DB must have a name";
                DialogResult result = MessageBox.Show(message, "Not Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        
        public void CloseDatabase()
        {
            TreeView.Nodes.Clear();
            MenuUpdate(false);
            Text = "SMBD";
            DB = null;
        }
        public void OpenDatabase()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string lastPath = currentAppDirectory + "\\" + "lastPath.lp";
            FileHandler.createFile(lastPath);
            //FileStream file_lastPath = FileHandler.openFile(lastPath);

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string[] folders = folderBrowserDialog.SelectedPath.Split('\\');
                DB = new Database(folders[folders.Length - 1], folderBrowserDialog.SelectedPath, false);
                if (DB.isDB())
                {
                    MenuUpdate(true);
                    TitleUpdate();
                    DisplayDB();
                }
                else
                {
                    string message = "The selected object is not a DB";
                    DB = null;
                    DialogResult result = MessageBox.Show(message, "Not a DB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    OpenDatabase();
                }

            }
        }

        #region MENU_RIGHT_CLICK
        private void MenuRCreateTable_Click(object sender, EventArgs e)
        {
            CreateTable();
        }
        #endregion
        #endregion

        #region TABLE
        private void CreateTable()
        {
            Create_Table = new CREATE_TABLE(this);
            Create_Table.Show();
        }
        public void RenameTable(string oldName, string newName)
        {
            if (newName != null && newName != "" && DB.Path != "")
            {
                string origin = DB.Path + "\\" + oldName + ".dbtable";
                string destiny = DB.Path + "\\" + newName + ".dbtable";

                DB.tables.Find(x => x.Name == origin).Rename(destiny);
            }
            else
            {
                string message = "The Table must have a name";
                DialogResult result = MessageBox.Show(message, "Not Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void DeleteTable()
        {

            TreeNode selected = TreeView.SelectedNode;
            string messageErrorInvalidObject = "Invalid object";
            string messageErrorDeleteTable = "The table cannot be deleted because it has a foreign relationship";

            string tablePath = Path.Combine(DB.Path, selected.Text + ".dbtable");
            Table TableToDelete = DB.tables.Find(x=> x.Name == tablePath);
            int IDTable = TableToDelete.IDTable;
            


            if(selected != null)
            {
                if (ValidateDeletingTable(IDTable))
                {
                    string messageAnswer = String.Format("Are you sure you want to delete the current Table{0} {1}", Environment.NewLine,selected.Text);
                    DialogResult result = MessageBox.Show(messageAnswer, "Delete Database!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                    
                        DB.tables.Find(x => x.Name == tablePath).Delete();
                        DB.tables.Remove(DB.tables.Find(x => x.Name == tablePath));
                        DisplayDB();
                    }
                }
                else
                {
                    MessageBox.Show(messageErrorDeleteTable, "Cannot delete table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(messageErrorInvalidObject, "Invalid Object", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            
        }

        public bool ValidateDeletingTable(int IDTable)
        {
            bool isOkReferentialIntegrity = true;

            var TablesAttributes = DB.tables.Select(s => s.attributes);

            foreach (var TableAttributes in TablesAttributes)
            {
                int CantFK = TableAttributes.FindAll(x => x.KT == "FK" && x.FK == IDTable).Count();
                if (CantFK > 0) return false;
            }

            return isOkReferentialIntegrity;
        }

        #region MENU_RIGHT_CLICK
        private void MenuRTableDeleteTable_Click(object sender, EventArgs e)
        {
            DeleteTable();
        }
        #endregion
        #endregion

        #region ATTRIBUTE
        //INSIDE THIS GOES ATTRIBUTE METHODS TO HANDLE ATTRIBUTES
        #endregion

        #region TEXTBOX_NAME_HANDLER
        //Controls what object (DB,Table,Atribute) is going to be edited (Name)
        private void TreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Level == 0)
                {
                    isEditDB = true;
                    isEditTable = false;
                    isEditAttribute = false;
                }
                else if (e.Node.Level == 1)
                {
                    isEditDB = false;
                    isEditTable = true;
                    isEditAttribute = false;
                }
                else if (e.Node.Level == 2)
                {
                    isEditDB = false;
                    isEditTable = false;
                    isEditAttribute = true;
                }
            }
            else
            {
                isEditDB = false;
                isEditTable = false;
                isEditAttribute = false;
            }


            //if (e.Node != null && e.Node.Level != 0)
            //{
            //    e.CancelEdit = true;
            //}
        }
        //Applies the method of the current control to be edited (Name)
        private void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != null && e.Label != null && e.Label != "")
            {
                if (isEditDB)
                {
                    RenameDatabase(e.Label);
                }
                else if (isEditTable)
                {
                    RenameTable(e.Node.Text, e.Label);
                }
                else if (isEditAttribute)
                {
                    //RenameAttribute(e.Node.Parent.Text,e.Node.Text,e.Label);
                }

            }
            else
            {
                isEditDB = false;
                isEditTable = false;
                isEditAttribute = false;
            }

            //if (e.Label != null && e.Label != "")
            //{
            //    RenameDatabase(e.Label);
            //}

        }




        #endregion

        //SELECT NODE WHEN RIGHT CLICK
        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView.SelectedNode = e.Node;

            if (e.Node != null)
            {
                if (e.Node.Level == 0)
                {
                    //Do something
                }
                else if (e.Node.Level == 1)
                {
                    //Do Something
                    ShowTableRecords();


                }
                else if (e.Node.Level == 2)
                {
                    //Do Something
                }
            }
        }

        private void TreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView.SelectedNode = e.Node;
            
            if (e.Node != null)
            {
                if (e.Node.Level == 0)
                {
                    //Do something
                }
                else if (e.Node.Level == 1)
                {
                    //Do Something
                    

                }
                else if (e.Node.Level == 2)
                {
                    //Do Something
                }
            }
        }

        private void ExpandToLevel(TreeNodeCollection nodes, int level)
        {
            if (level > 0)
            {
                foreach (TreeNode node in nodes)
                {
                    node.Expand();
                    ExpandToLevel(node.Nodes, level - 1);
                }
            }
        }

        private void MenuRTableAddAttribute_Click(object sender, EventArgs e)
        {
            TreeNode selected = TreeView.SelectedNode;
            Table t = DB.tables.Where(x => x.ShortName == selected.Text).First();
            CREATE_TABLE create_table = new CREATE_TABLE("Add Attribute",this);
            create_table.SetEditTable(t);
            create_table.Show();
        }

        private void MenuRAttributeEdit_Click(object sender, EventArgs e)
        {
            TreeNode selected = TreeView.SelectedNode;
            Table t = DB.tables.Where(x => x.ShortName == selected.Parent.Text).First();
            Attribute_ a = t.attributes.Where(x => x.Name == selected.Text).First();
            CREATE_TABLE create_table = new CREATE_TABLE("Edit Attribute", this);
            create_table.SetEditAttribute(t,a);
            create_table.Show();
        }

        private void MenuRAttributeDelete_Click(object sender, EventArgs e)
        {
            TreeNode selected = TreeView.SelectedNode;
            Table t = DB.tables.Where(x => x.ShortName == selected.Parent.Text).First();
            Attribute_ a = t.attributes.Where(x => x.Name == selected.Text).First();
            a.Delete();
            t.GetAttributes();
            DisplayDB();
        }

        public void ShowTableRecords()
        {
            Table CurrentTable = DB.tables.Where(x => x.ShortName == TreeView.SelectedNode.Text).Count() > 0 ?
                    DB.tables.Where(x => x.ShortName == TreeView.SelectedNode.Text).First() : null;

            if (CurrentTable != null)
            {
                //Show table 
                TableView.Columns.Clear();
                foreach (var attribute in CurrentTable.attributes)
                {
                    DataGridTextBoxColumn x = new DataGridTextBoxColumn();
                    x.HeaderText = attribute.Name;
                    TableView.Columns.Add(attribute.Name, attribute.Name);
                }
            }
        }
    }
}
