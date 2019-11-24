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
    public partial class CREATE_RECORD : Form
    {
        public CREATE_RECORD(Table table,SMBD parent)
        {
            InitializeComponent();
            Text = "ADD RECORDS";
            Parent_SMBD = parent;

            TableViewRecord.AllowUserToAddRows = true;
            TableViewRecord.ReadOnly = false;
            if (table != null)
            {
                //Show table 
                TableViewRecord.Columns.Clear();
                foreach (var attribute in table.attributes)
                {
                    DataGridViewColumn column = new DataGridViewColumn();
                    
                    TableViewRecord.Columns.Add(attribute.Name, attribute.Name);
                    
                }
            }

        }

        private void btnCancelRecords_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSaveRecords_Click(object sender, EventArgs e)
        {
            ExceptionError NoTableName = new ExceptionError("The table must have a name", "NO TABLE NAME");
            ExceptionError SameTableName = new ExceptionError("The table name already exists", "SAME TABLE NAME");


            //string newFile = Parent_SMBD.DB.Path + "\\" + txtName.Text + ".dbtable";
            bool isOkRecords = false;
            try
            {
                isOkRecords = ValidateRecords();
            }
            catch (ExceptionError err) { err.showMessage(); }

            if (isOkRecords)
            {

                Parent_SMBD.TableSelected.SaveRecords();
                Hide();
            }
        }

        private bool ValidateRecords()
        {
            
            
            ExceptionError DataTypeError = new ExceptionError("There are incorrect data type values", "INCORRECT DATA");
            ExceptionError ReferentialIntegrityError = new ExceptionError("The Foreing Key does not exist", "REFERENCIAL INTEGRITY");
            
            
            for (int i = 0; i < TableViewRecord.Rows.Count - 1; i++)
            {
                DataGridViewRow row = TableViewRecord.Rows[i];

                for( int j = 0; j < row.Cells.Count; j++)
                {
                    DataGridViewCell cell = row.Cells[j];
                    var hola = 0;

                }
            }

            return true;
        }

        private void TableViewRecord_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ExceptionError DataError = new ExceptionError("Incorrect value", "INCORRECT DATA");

            e.Control.KeyPress -= new KeyPressEventHandler(IntColumn_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(FloatColumn_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(StringColumn_KeyPress);

            int columnIndex = TableViewRecord.CurrentCell.ColumnIndex;
            string columnName = TableViewRecord.Columns[columnIndex].Name;

            //Obtiene los atributos agrupados por tipo de dato
            var IntAttributes = Parent_SMBD.TableSelected.attributes.Where(x => x.DT == "INT");
            var FloatAttributes = Parent_SMBD.TableSelected.attributes.Where(x => x.DT == "FLOAT");
            var StringAttributes = Parent_SMBD.TableSelected.attributes.Where(x => x.DT == "STRING");

            //Crea una lista de los nombres de los atributos agrupados por tipo de dato
            List<string> NamesIntAttributes = IntAttributes.Count() > 0 ? IntAttributes.Select(s => s.Name).ToList() : new List<string>();
            List<string> NamesFloatAttributes = FloatAttributes.Count() > 0 ? FloatAttributes.Select(s => s.Name).ToList() : new List<string>();
            List<string> NamesStringAttributes = StringAttributes.Count() > 0 ? StringAttributes.Select(s => s.Name).ToList() : new List<string>();

            //Verifica el tipo de la celda actual
            bool typeInt = NamesIntAttributes.Contains(columnName);
            bool typeFloat = NamesFloatAttributes.Contains(columnName);
            bool stringType = NamesStringAttributes.Contains(columnName);

            
            //Verifica que el dato que esta ingresando sea un numero ya sea entero o flotante
            //if (TableViewRecord.CurrentCell.Value != null && (typeInt || typeFloat))
            //{
            //    string currentValue = (string)TableViewRecord.CurrentCell.Value;

            //    try
            //    {
            //        double value = Convert.ToDouble(currentValue);
            //    }
            //    catch(Exception err)
            //    {
            //        DataError.showMessage(); 
            //    }
            //}

            //Valida que no se puedan ingresar letras si el tipo de atributo es entero o flotante
            if (typeInt)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(IntColumn_KeyPress);
                }
            }else if (typeFloat)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(FloatColumn_KeyPress);
                }
            }else if (stringType)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(StringColumn_KeyPress);
                }
            }

        }

        private void IntColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FloatColumn_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void StringColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            int columnIndex = TableViewRecord.CurrentCell.ColumnIndex;
            string columnName = TableViewRecord.Columns[columnIndex].Name;
            Attribute_ Attribute = Parent_SMBD.TableSelected.attributes.Find(x => x.Name == columnName);
            
            if(Attribute != null)
            {
                int MaxLength = Attribute.Length;
                if (TableViewRecord.CurrentCell.Value != null)
                {
                    string value = (string)TableViewRecord.CurrentCell.Value;
                    
                    if (value.Length  >= MaxLength && e.KeyChar != '\b')
                    {
                        
                        e.Handled = true;
                    }
                    
                }
            }

            
        }

        private void TableViewRecord_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowSelected = TableViewRecord.Rows[e.RowIndex >= 0 ? e.RowIndex : 0];
            string value = rowSelected.Cells[e.ColumnIndex].Value != null ? (string)rowSelected.Cells[e.ColumnIndex].Value : "";


            TableViewRecord.CurrentCell.Value = value;
        }

        private void TableViewRecord_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (TableViewRecord.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                TableViewRecord.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
