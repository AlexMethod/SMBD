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
            string path = this.selectedPath + "\\" + this.txtName.Text;
            System.IO.Directory.CreateDirectory(path);
            this.Parent_SMBD.currentPath = path;
            this.Parent_SMBD.currentDB = this.txtName.Text;
            this.Hide();
        }
    }
}
