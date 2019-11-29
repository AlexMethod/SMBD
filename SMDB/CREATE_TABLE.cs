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
            DataGridViewRowEventArgs e = new DataGridViewRowEventArgs(DGAttributes.Rows[0]);
            DGAttributes_DefaultValuesNeeded(new object(), e);
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
            ExceptionError ExistingRecords = new ExceptionError("It is not possible to add a new attribute since the table already contains at least one record", "CANNOT ADD ATTRIBUTES");


            string newFile = Parent_SMBD.DB.Path + "\\" + txtName.Text + ".dbtable";
            bool isOkAttributes = false;
            try {
                if (txtName.Text == "") throw NoTableName;
                if (Parent_SMBD.DB.tables.Where(x => x.ShortName == txtName.Text).Count() > 0 && Command =="ADD_TABLE") throw SameTableName;
                //Table NTable = Command == "ADD_TABLE" ? new Table(newFile, Parent_SMBD.DB.GetNextIDTable()) : TableEdit;
                isOkAttributes = ValidateAttributes();
            }
            catch (ExceptionError err) { err.showMessage(); }

            if (isOkAttributes)
            {
                try
                {
                    Table NTable = Command == "ADD_TABLE" ? new Table(newFile, Parent_SMBD.DB.GetNextIDTable()) : TableEdit;
                    if (NTable.DirRegistros != -1) throw ExistingRecords;
                    List<Attribute_> attributes = SaveAttributes(NTable);
                    NTable.GetAttributes();
                    if (Command == "ADD_TABLE") Parent_SMBD.DB.tables.Add(NTable);
                    Parent_SMBD.DisplayDB();
                    Hide();
                }
                catch(ExceptionError err) { err.showMessage(); }
                
            }
            
        }

        private void DGAttributes_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewComboBoxCell CBCell = new DataGridViewComboBoxCell();
            DataGridViewCellCollection cellCollection = DGAttributes.Rows[e.Row.Index].Cells;

            foreach(Table t in Parent_SMBD.DB.tables)
            {
                if(t.attributes.Where(x=> x.KT == "PK").Count() > 0)
                {
                    CBCell.Items.Add(t.ShortName);
                }
                
            }
            CBCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

            
            if (Command == "EDIT_ATTRIBUTE")
            {
                string FKTable = AttributeEdit.FK != -1 ? Parent_SMBD.DB.tables.Where(x => x.IDTable == AttributeEdit.FK).First().ShortName : "";
                if(FKTable != "")
                {
                    CBCell.Value = FKTable;
                }
                
            }

            cellCollection[4] = CBCell;
            if(Command != "EDIT_ATTRIBUTE")
            {
                e.Row.Cells[1].Value = "INT";
                e.Row.Cells[3].Value = "PK";
            }
            
            
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
            if(Command == "ADD_TABLE")
            {
                DataGridViewRow rowSelected = DGAttributes.Rows[e.RowIndex >= 0 ? e.RowIndex : 0];
                if (!rowSelected.IsNewRow && e.ColumnIndex == 5)
                {
                    DGAttributes.Rows.Remove(rowSelected);
                }

                if (((string)rowSelected.Cells[1].Value == "INT") || ((string)rowSelected.Cells[1].Value == "FLOAT"))
                {
                    if(rowSelected.Cells[2].Value == null || (string)rowSelected.Cells[2].Value == "" || (string)rowSelected.Cells[2].Value != "4") rowSelected.Cells[2].Value = "4";
                }
                else
                {
                    if (rowSelected.Cells[2].Value == null || (string)rowSelected.Cells[2].Value == "" || (string)rowSelected.Cells[2].Value != "50") rowSelected.Cells[2].Value = "50";
                }
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
                    if (rowSelected.Cells[2].Value == null || (string)rowSelected.Cells[2].Value == "" || (string)rowSelected.Cells[2].Value != "4") rowSelected.Cells[2].Value = "4";
                    rowSelected.Cells[2].ReadOnly = true;
                }
                else
                {
                    if (rowSelected.Cells[2].Value == null || (string)rowSelected.Cells[2].Value == "" || (string)rowSelected.Cells[2].Value != "50") rowSelected.Cells[2].Value = "50";
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
            if (Command == "EDIT_ATTRIBUTE" && AttributeEdit != null) AttributeEdit.Delete();
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
                long RewritableAA = table.GetRewritableAA();
                Attribute_ attribute = new Attribute_(table.Name, table.ShortName, Name, DataType, Length, KeyType, FKType, RewritableAA);
            }

            return attributes;
        }
        private bool ValidateAttributes()
        {

            int cantPK = 0; //Must be just 0 or 1
            if (Command == "EDIT_TABLE") cantPK = TableEdit.attributes.Where(x => x.KT == "PK" && x.Status == 1).Count();
            ExceptionError DataError = new ExceptionError("It cannot be empty values for attributes","INCORRECT DATA");
            ExceptionError PKError = new ExceptionError("The are more than one PK attributes", "NO MORE THAN ONE PK PERMITTED");
            ExceptionError DecimalError = new ExceptionError("The Lenght must be only an integer number", "INCORRECT LENGTH");
            ExceptionError PKDataTypeError = new ExceptionError("Attribute with foreign table does not match data type", "DATA TYPE ERROR");
            ExceptionError NoTableFKError = new ExceptionError("At least one attribute with Key Type FK doesn't have a foreign table", "NO FOREIGN TABLE");
            ExceptionError KeyTypeError = new ExceptionError("Attributes with Key types PK or FK must be of Data Type INT", "INCORRECT DATA TYPE FOR KEYS");
            ExceptionError SameNameAttribute = new ExceptionError("There are some attributes with the same name","SAME NAME FOR ATTRIBUTES");

            //if (DGAttributes.Rows.Count == 1) throw NoAttributes;
            if (DGAttributes.Rows.Count != DGAttributes.Rows.Cast<DataGridViewRow>().Select(x => x.Cells[0].Value).Distinct().Count()) throw SameNameAttribute;
            if (Command == "EDIT_TABLE") { for (int i = 0; i < DGAttributes.Rows.Count - 1; i++) { if (TableEdit.attributes.Select(x=> x.Name).Contains(DGAttributes.Rows[i].Cells[0].Value)) throw SameNameAttribute; }  }
            for (int i = 0; i<DGAttributes.Rows.Count -1; i++)
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
                if(KeyType == "FK")
                {
                    Table t = Parent_SMBD.DB.tables.Where(x => x.ShortName == FKType).First();
                    string PKType = t.attributes.Where(x=> x.KT == "PK").First().DT;
                    if (PKType != DataType) throw PKDataTypeError;
                }
                try { int integer = Convert.ToInt32(Length); } catch(Exception e) { throw DecimalError; }
                
            }

            return true;
        }

        public void SetEditTable(Table t)
        {
            txtName.Text = t.ShortName; txtName.ReadOnly = true;
            TableEdit = t;
            Command = "EDIT_TABLE";
            Text = "Add Atribute";

        }

        public void SetEditAttribute(Table t,Attribute_ a)
        {
            txtName.Text = t.ShortName; txtName.ReadOnly = true;
            //DGAttributes.ReadOnly = true;

            DGAttributes.Rows[0].Cells[0].Value = a.Name;
            DGAttributes.Rows[0].Cells[1].Value = a.DT;
            DGAttributes.Rows[0].Cells[2].Value = a.Length.ToString();
            DGAttributes.Rows[0].Cells[3].Value = a.KT;
            
            TableEdit = t;
            AttributeEdit = a;
            Command = "EDIT_ATTRIBUTE";
            Text = "Edit Atribute";
            DataGridViewRowEventArgs e = new DataGridViewRowEventArgs(DGAttributes.Rows[0]);
            DGAttributes_DefaultValuesNeeded(new object(), e);
        }
    }
}
