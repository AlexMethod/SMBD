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
            SplitContainer.Width = this.Width;
            SplitContainer.Height = this.Height;

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

        //Decapricated
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics G = e.Graphics;
            //G.DrawRectangle(Pens.Black, 0, 30, 200, 500);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

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

        public void OpenDatabase()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string lastPath = currentAppDirectory + "\\" + "lastPath.lp";
            FileHandler.createFile(lastPath);
            //FileStream file_lastPath = FileHandler.openFile(lastPath);

            if(folderBrowserDialog.ShowDialog() == DialogResult.OK){
                this.currentPath = folderBrowserDialog.SelectedPath;
                string[] folders = this.currentPath.Split('\\'); 
                this.currentDB = folders[folders.Length-1];
                if (isDB())
                {
                    MenuUpdate(true);
                    TitleUpdate();
                    DisplayDB();
                }
                else
                {
                    string message = "The selected object is not a DB";
                    DialogResult result = MessageBox.Show(message, "Not a DB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    OpenDatabase();
                }
                
            }
        }

        public void CloseDatabase()
        {
            TreeView.Nodes.Clear();
            MenuUpdate(false);
            this.Text = "SMBD";
            this.currentDB = "";
            this.currentPath = "";
        }

        public bool isDB()
        {
            bool response = false;
            string[] files = System.IO.Directory.GetFiles(this.currentPath);
            foreach (string file in files)
            {
                string filename = file.Split('.')[1];
                if (filename == "db")
                {
                    response = true;
                    break;
                }
            }
            return response;
        }

        public void CreateDatabase()
        {
            this.Create_DB = new CREATE_DB();
            this.Create_DB.Parent_SMBD = this;
            this.Create_DB.Show();
        }

        public void DeleteDatabase()
        {
            string messageAnswer = String.Format("Are you sure you want to delete the current Database{0}{1}",Environment.NewLine,this.currentDB);
            string messageError = "The object is not available";
            if (isDB())
            {
                DialogResult result = MessageBox.Show(messageAnswer, "Delete Database!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    System.IO.Directory.Delete(this.currentPath, true);
                    this.currentPath = "";
                    this.currentDB = "";
                    this.Text = "SMBD";
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
            if (newName != null && newName != "" )
            {
                string origin = this.currentPath;
                string destiny = this.currentPath.Replace(this.currentDB, newName);
                string[] files = Directory.GetFiles(origin);
                string[] newFiles = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    string newFile = files[i].Replace(this.currentDB, newName);
                    newFiles[i] = newFile;
                }
                if (isDB())
                {
                    Directory.Delete(origin, true);
                    Directory.CreateDirectory(destiny);
                    FileHandler.createFiles(newFiles);
                    this.currentPath = destiny;
                    this.currentDB = newName;
                    this.Text = destiny;
                }
            }
            else
            {
                string message = "The DB must have a name";
                DialogResult result = MessageBox.Show(message, "Not Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void RenameTable(string oldName,string newName)
        {
            if (newName != null && newName != ""  && this.currentPath != "")
            {
                string origin = this.currentPath + "\\" + oldName + ".dbtable";
                string destiny = this.currentPath + "\\" + newName + ".dbtable";

                File.Move(origin, destiny);
            }
            else
            {
                string message = "The Table must have a name";
                DialogResult result = MessageBox.Show(message, "Not Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
            this.Text = this.currentPath;
        }

        private void MenuConnectDB_Click(object sender, EventArgs e)
        {
            OpenDatabase();
        }

        private void MenuDisconnectDB_Click(object sender, EventArgs e)
        {
            //Close
        }

        private void MenuNewDB_Click(object sender, EventArgs e)
        {
            CreateDatabase();
        }

        public void DisplayDB()
        {

            //Display DB
            //Display all tables
            TreeView.Nodes.Clear();
            string[] files = System.IO.Directory.GetFiles(this.currentPath);
            string[] tables = Array.FindAll(files, x => x.Split('.')[1] == "dbtable");
            
            TreeNode[] childs = new TreeNode[tables.Length];
            for (int i = 0; i < tables.Length; i++)
            {
                string table_name = tables[i].Split('\\')[tables[i].Split('\\').Length - 1].Split('.')[0];
                childs[i] = new TreeNode(table_name,0,0);
            }
            TreeNode rootDatabase = new TreeNode(this.currentDB,10,10,childs);
            rootDatabase.ContextMenuStrip = MenuRightTreeView;
            TreeView.Nodes.Add(rootDatabase);
            TreeView.ExpandAll();

        }

        private void MenuRCreateTable_Click(object sender, EventArgs e)
        {
            //Create table
            this.Create_Table = new CREATE_TABLE();
            this.Create_Table.Parent_SMBD = this;
            this.Create_Table.Show();
            
        }

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

        private void MenuClose_Click(object sender, EventArgs e)
        {

        }

        private void MenuHDeleteDB_Click(object sender, EventArgs e)
        {
            DeleteDatabase();
        }

        private void MenuDeleteDB_Click(object sender, EventArgs e)
        {
            DeleteDatabase();
        }

        private void MenuRRenameDB_Click(object sender, EventArgs e)
        {
            
        }

        //Controls what object is going to be edited (Name)
        private void TreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if(e.Node != null)
            {
                if(e.Node.Level == 0)
                {
                    isEditDB = true;
                    isEditTable = false;
                    isEditAttribute = false;
                }
                else if(e.Node.Level == 1)
                {
                    isEditDB = false;
                    isEditTable = true;
                    isEditAttribute = false;
                }
                else if(e.Node.Level == 2)
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

        private void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if(e.Node != null && e.Label != null && e.Label != "")
            {
                if (isEditDB)
                {
                    RenameDatabase(e.Label);
                }else if (isEditTable)
                {
                    RenameTable(e.Node.Text,e.Label);
                }else if (isEditAttribute)
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
    }
}
