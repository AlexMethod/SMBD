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

namespace SMDB
{
    public partial class CREATE_TABLE : Form
    {
        public CREATE_TABLE()
        {
            InitializeComponent();
        }

        private void btnCancelDB_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CREATE_TABLE_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newFile = this.Parent_SMBD.currentPath + "\\" + txtName.Text + ".dbtable";
            FileHandler.createFile(newFile);
            this.Parent_SMBD.DisplayDB();
            this.Hide();
        }
    }
}
