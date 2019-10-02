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
            foreach (DataGridViewRow gridViewRow in DGAttributes.Rows)
            {
                gridViewRow.HeaderCell.ContextMenuStrip = MenuRRow;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newFile = Parent_SMBD.DB.Path + "\\" + txtName.Text + ".dbtable";
            Table NTable = new Table(newFile, Parent_SMBD.DB.GetNextIDTable());
            Parent_SMBD.DB.tables.Add(NTable);
            Parent_SMBD.DisplayDB();
            Hide();
        }

        private void DGAttributes_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewComboBoxCell CBCell = new DataGridViewComboBoxCell();
            DataGridViewCellCollection cellCollection = DGAttributes.Rows[e.Row.Index].Cells;

            CBCell.Items.Add("Tabla1");
            CBCell.Items.Add("Tabla2");
            CBCell.Items.Add("Tabla3");
            CBCell.Items.Add("Tabla4");
            CBCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;


            cellCollection[4] = CBCell;
            e.Row.Cells[1].Value = "INT";
            e.Row.Cells[3].Value = "PK";
            
        }

        private void DGAttributes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow gridViewRow in this.DGAttributes.Rows)
            {
                gridViewRow.HeaderCell.ContextMenuStrip = MenuRRow;
            }
        }

        private void DGAttributes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow rowSelected = DGAttributes.Rows[e.RowIndex >= 0 ? e.RowIndex : 0];
            if (!rowSelected.IsNewRow && e.ColumnIndex == 5)
            {
                DGAttributes.Rows.Remove(rowSelected);
            }

            if( ((string)rowSelected.Cells[1].Value == "INT") || ((string)rowSelected.Cells[1].Value == "FLOAT") )
            {
                rowSelected.Cells[2].Value = "4";
            }
            else
            {
                rowSelected.Cells[2].Value = "100";
            }
        }

        private void DGAttributes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowSelected = DGAttributes.Rows[e.RowIndex >= 0 ? e.RowIndex : 0];

            //DataType
            if(e.ColumnIndex == 1)
            {
                if( ((string)rowSelected.Cells[1].Value == "INT") || ((string)rowSelected.Cells[1].Value == "FLOAT"))
                {
                    rowSelected.Cells[2].Value = "4";
                }
                else
                {
                    rowSelected.Cells[2].Value = "100";
                }
            }
            //KeyType
            else if(e.ColumnIndex == 3)
            {
                if( (string)rowSelected.Cells[3].Value == "FK")
                {
                    rowSelected.Cells[4].ReadOnly = false;
                }
                else
                {
                    rowSelected.Cells[4].ReadOnly = true;
                }
            }
            //FKTable
            else if(e.ColumnIndex == 4)
            {

            }
        }

        //Used to fire when the value of a combobox in the datagridview has changed
        private void DGAttributes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.DGAttributes.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                DGAttributes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
