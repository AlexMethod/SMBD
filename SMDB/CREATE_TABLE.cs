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
        public CREATE_TABLE(SMBD parent_smbd)
        {
            Parent_SMBD = parent_smbd;
            InitializeComponent();
        }
        public CREATE_TABLE(string Title,SMBD parent_smbd)
        {
            Text = Title; Parent_SMBD = parent_smbd;
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
            ExceptionError NoTableName = new ExceptionError("The table must have a name","NO TABLE NAME");
            ExceptionError SameTableName = new ExceptionError("The table name already exists","SAME TABLE NAME");


            string newFile = Parent_SMBD.DB.Path + "\\" + txtName.Text + ".dbtable";
            bool isOkAttributes = false;
            try {
                if (txtName.Text == "") throw NoTableName;
                if (Parent_SMBD.DB.tables.Where(x => x.ShortName == txtName.Text).Count() > 0 && Command =="ALTA") throw SameTableName;
                isOkAttributes = ValidateAttributes();
            }
            catch (ExceptionError err) { err.showMessage(); }

            if (isOkAttributes)
            {
                Table NTable = Command == "ALTA" ? new Table(newFile, Parent_SMBD.DB.GetNextIDTable()) : TableEdit;
                List<Attribute_> attributes = SaveAttributes(NTable);
                NTable.GetAttributes();
                Parent_SMBD.DB.tables.Add(NTable);
                Parent_SMBD.DisplayDB();
                Hide();
            }
            
        }

        private void DGAttributes_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewComboBoxCell CBCell = new DataGridViewComboBoxCell();
            DataGridViewCellCollection cellCollection = DGAttributes.Rows[e.Row.Index].Cells;

            foreach(Table t in Parent_SMBD.DB.tables)
            {
                CBCell.Items.Add(t.ShortName);
            }
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
                    rowSelected.Cells[2].ReadOnly = true;
                }
                else
                {
                    rowSelected.Cells[2].Value = "100";
                    rowSelected.Cells[2].ReadOnly = false;
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
                    rowSelected.Cells[4].Value = "";
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
            if (DGAttributes.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                DGAttributes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private List<Attribute_> SaveAttributes(Table table)
        {
            List<Attribute_> attributes = new List<Attribute_>();

            for(int i = 0;i<DGAttributes.Rows.Count - 1;i++)
            {
                DataGridViewRow row = DGAttributes.Rows[i];

                string Name = (string)row.Cells[0].Value;
                string DataType = (string)row.Cells[1].Value;
                string length = (string)row.Cells[2].Value;
                int Length = Convert.ToInt32(length);
                string KeyType = (string)row.Cells[3].Value;
                string fKType = (string)row.Cells[4].Value;
                int FKType = Parent_SMBD.DB.tables.Where(x => x.ShortName == fKType).Count() == 1 ? Parent_SMBD.DB.tables.Where(x => x.ShortName == fKType).First().IDTable : -1;
                Attribute_ attribute = new Attribute_(table.Name, table.ShortName, Name, DataType, Length, KeyType, FKType);
            }

            return attributes;
        }
        private bool ValidateAttributes()
        {
            int cantPK = 0; //Must be just 0 or 1
            if (Command == "EDICION") cantPK = TableEdit.attributes.Where(x => x.KT == "PK").Count();
            ExceptionError DataError = new ExceptionError("It cannot be empty values for attributes","INCORRECT DATA");
            ExceptionError PKError = new ExceptionError("The are more than one PK attributes", "NO MORE THAN ONE PK PERMITTED");
            ExceptionError DecimalError = new ExceptionError("The Lenght must be only an integer number", "INCORRECT LENGTH");
            ExceptionError NoAttributes = new ExceptionError("A table must have at least one attribute", "ATTRIBUTES QUANTITY AT LEAST ONE");
            ExceptionError NoTableFKError = new ExceptionError("At least one attribute with Key Type FK doesn't have a foreign table", "NO FOREIGN TABLE");
            ExceptionError KeyTypeError = new ExceptionError("Attributes with Key types PK or FK must be of Data Type INT", "INCORRECT DATA TYPE FOR KEYS");

            if (DGAttributes.Rows.Count == 1) throw NoAttributes;
            for(int i = 0; i<DGAttributes.Rows.Count -1; i++)
            {
                DataGridViewRow row = DGAttributes.Rows[i];
                
                string Name = (string)row.Cells[0].Value ?? "";
                string DataType = (string)row.Cells[1].Value;
                string Length = (string)row.Cells[2].Value;
                string KeyType = (string)row.Cells[3].Value;
                string FKType = (string)row.Cells[4].Value;

                if (KeyType == "PK") cantPK++;
                if (Name == "" || DataType == "" || Length == "" || KeyType == "") throw DataError;
                if (cantPK > 1) throw PKError;
                if (KeyType == "FK" && FKType == "") throw NoTableFKError;
                try { int integer = Convert.ToInt32(Length); } catch(Exception e) { throw DecimalError; }
                if ((KeyType == "PK" || KeyType == "FK") && (DataType == "STRING" || DataType == "FLOAT")) throw KeyTypeError;
                
            }

            return true;
        }

        public void SetEdit(Table t)
        {
            txtName.Text = t.ShortName; txtName.ReadOnly = true;
            TableEdit = t;
            Command = "EDICION";
            Text = "Add Atribute";

        }
    }
}
