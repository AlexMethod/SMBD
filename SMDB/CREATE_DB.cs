using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SMDB.Classes;

namespace SMDB
{
    public partial class CREATE_DB : Form
    {
        public CREATE_DB()
        {
            InitializeComponent();
            this.txtName.Text = "New Database 1";
            this.txtLocation.Text = "C:\\Documents\\SDBM Studio";
        }

        private void btnCancelDB_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.selectedPath = folderBrowserDialog.SelectedPath;
                this.txtLocation.Text = this.selectedPath;
            }
        }

        private void btnSaveDB_Click(object sender, EventArgs e)
        {
            string path = selectedPath + "\\" + txtName.Text;
            string metadata = path + "\\" + ".db";
            
            Parent_SMBD.DB = new Database(txtName.Text,path);
            Parent_SMBD.MenuUpdate(true);
            Parent_SMBD.TitleUpdate();
            Parent_SMBD.DisplayDB();
            Hide();
        }
    }
}
