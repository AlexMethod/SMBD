using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.MinimumSize = this.Size;

            //Menu Properties
            MenuSeparator1.Enabled = false;
            MenuSeparator2.Enabled = false;
            MenuSeparator3.Enabled = false;
            MenuSeparator4.Enabled = false;
            MenuSeparator5.Enabled = false;

            MenuDisconnectDB.Enabled = false;
            MenuClose.Enabled = false;
            MenuDeleteDB.Enabled = false;
        }

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
            if (keyData == (Keys.Control | Keys.X)) //CLOSE
            {
                MessageBox.Show("CLOSE CURRENT FILE OR PROJECT");
                return true;
            }
            if (keyData == (Keys.Control | Keys.N)) //NEW FILE
            {
                MessageBox.Show("NEW FILE");
                return true;
            }
            if (keyData == (Keys.Control | Keys.O)) //OPEN FILE
            {
                MessageBox.Show("OPEN FILE");
                return true;
            }
            if (keyData == (Keys.Alt | Keys.Control | Keys.N)) //NEW DATABASE
            {
                //MessageBox.Show("NEW DATABASE");
                CreateDatabase();
                return true;
            }
            if (keyData == (Keys.Control | Keys.Shift | Keys.N)) //NEW PROJECT
            {
                MessageBox.Show("NEW PROJECT");
                return true;
            }
            if (keyData == (Keys.Control | Keys.Shift | Keys.O)) //OPEN PROJECT
            {
                MessageBox.Show("OPEN PROJECT");
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
            
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK){
                this.currentPath = folderBrowserDialog.SelectedPath;
                string[] folders = this.currentPath.Split('\\'); 
                this.currentDB = folders[folders.Length-1];

                MenuUpdate(true);
                TitleUpdate();
                DisplayDB();
            }
        }

        public void CreateDatabase()
        {
            this.Create_DB = new CREATE_DB();
            this.Create_DB.Parent_SMBD = this;
            this.Create_DB.Show();

            MenuUpdate(true);
            TitleUpdate();
        }

        public void DeleteDatabase()
        {
            string message = String.Format("Are you sure you want to delete the current Database{0}{1}",Environment.NewLine,this.currentDB);
            DialogResult result = MessageBox.Show(message, "ALERT", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
            {
                System.IO.Directory.Delete(this.currentPath, true);
                this.currentPath = "";
                this.currentDB = "";
                this.Text = "SMBD";
                MenuUpdate(false);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuUpdate(bool enable)
        {
            if (enable)
            {
                //Menu update
                MenuDisconnectDB.Enabled = true;
                MenuClose.Enabled = true;
                MenuDeleteDB.Enabled = true;
            }
            else
            {
                //Menu update
                MenuDisconnectDB.Enabled = false;
                MenuClose.Enabled = false;
                MenuDeleteDB.Enabled = false;
            }
        }
        private void TitleUpdate()
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

        private void DisplayDB()
        {

            //Display DB
            MenuCurrentDB.Items.Clear();
            MenuCurrentDB.Items.Add(this.currentDB, SMDB.Properties.Resources.severaldb);

            //Display all tables
            string[] files = System.IO.Directory.GetFiles(this.currentPath);
            List<string> diccionaries = new List<string>();
            foreach (string file in files)
            {
                string[] arrFiles = file.Split('.');
                if (arrFiles[1] == "dd")
                {
                    diccionaries.Add(file);
                }
            }

        }
    }
}
