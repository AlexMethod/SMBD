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

                SaveRegistries();
                Hide();
            }
        }

        public void SaveRegistries()
        {
            Table Table = Parent_SMBD.TableSelected;
            long tamFile = FileHandler.getFileLength(Table.Name);
            List<Registry> registries = Table.GetRegistries();
            if(registries.Count() == 0) Table.DirRegistry = tamFile;
            
            for (int i = 0; i < TableViewRecord.Rows.Count - 1; i++)
            {
                DataGridViewRow row = TableViewRecord.Rows[i];
                List<Data> datas = new List<Data>();
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    DataGridViewCell cell = row.Cells[j];
                    Attribute_ Attribute = Parent_SMBD.TableSelected.attributes[j];
                    string value = cell.Value != null ? cell.Value.ToString() : "";
                    
                    Data data = new Data(value, Attribute);
                    datas.Add(data);
                }
                Registry registry = new Registry(Table.Name, datas);
            }

            Parent_SMBD.ShowTableRecords();
        }

        private bool ValidateRecords()
        {
            
            ExceptionError DataTypeError = new ExceptionError("There are incorrect data type values", "INCORRECT DATA");
            ExceptionError ReferentialIntegrityForeignError = new ExceptionError("The Foreing Key does not exist", "REFERENCIAL INTEGRITY");
            ExceptionError SamePKError = new ExceptionError("The table already contains a registry with the PK inserted", "SAME PK");


            Table Table = Parent_SMBD.TableSelected;
            List<Data> datas = new List<Data>();
            int CantPK = 0;
            for (int i = 0; i < TableViewRecord.Rows.Count - 1; i++)
            {
                DataGridViewRow row = TableViewRecord.Rows[i];

                for( int j = 0; j < row.Cells.Count; j++)
                {
                    DataGridViewCell cell = row.Cells[j];
                    
                    Attribute_ Attribute = Parent_SMBD.TableSelected.attributes[j];

                    string value = cell.Value != null ? cell.Value.ToString() : "";
                    string AttributeName = Attribute.Name;
                    string KT = Attribute.KT;
                    string DT = Attribute.DT;
                    int FK = Attribute.FK;

                    if (KT == "PK") CantPK++;
                    if ((KT == "PK" || KT == "FK") && value == "") throw DataTypeError;
                    try { if (DT == "INT" || DT == "FLOAT") { Convert.ToDouble(value); } }catch(Exception err) { throw DataTypeError; }
                    if (CantPK > 1) throw SamePKError;
                    //Si el atributo es una llave foranea, debera existir el registro ingresado
                    if(KT == "FK" && FK != -1)
                    {
                        Table ForeignTable = Parent_SMBD.DB.tables.Where(x => x.IDTable == FK).FirstOrDefault();

                        List<Registry> foreignRegistries = ForeignTable.GetRegistries();
                        

                        if (foreignRegistries.Count() == 0) throw ReferentialIntegrityForeignError;

                        if (!validateForeignRegistry(foreignRegistries, value, DT)) throw ReferentialIntegrityForeignError;
                    }

                    if(KT == "PK")
                    {
                        List<Registry> registries = Table.GetRegistries();
                        if (!validatePKRegistry(registries, value, DT)) throw SamePKError;
                    }
                }
            }

            return true;
        }

        public bool validateForeignRegistry(List<Registry> registries, string value, string DT)
        {
            bool response = false;

            if(DT == "INT")
            {
                int Value = Convert.ToInt32(value);

                foreach(Registry registry in registries)
                {
                    Data PK = registry.Values.Where(x => x.Attribute.KT == "PK").First();
                    dynamic dynamicPKValue = PK.Value;
                    int PKValue = dynamicPKValue;
                    if(Value == PKValue)
                    {
                        response = true;
                    }
                }
            }
            else if(DT == "FLOAT")
            {
                float Value = Convert.ToSingle(value);
                foreach (Registry registry in registries)
                {
                    Data PK = registry.Values.Where(x => x.Attribute.KT == "PK").First();
                    dynamic dynamicPKValue = PK.Value;
                    float PKValue = dynamicPKValue;
                    if (Value == PKValue) { response = true; }
                }
            }
            else if(DT == "STRING")
            {
                string Value = value;
                foreach (Registry registry in registries)
                {
                    Data PK = registry.Values.Where(x => x.Attribute.KT == "PK").First();
                    dynamic dynamicPKValue = PK.Value;
                    string PKValue = dynamicPKValue;

                    if (Value == FormatString(PKValue))
                    {
                        response = true;
                    }
                }
            }


            return response;
        }

        public bool validatePKRegistry(List<Registry> registries, string value, string DT)
        {
            bool response = true;

            if (DT == "INT")
            {
                int Value = Convert.ToInt32(value);

                foreach (Registry registry in registries)
                {
                    Data PK = registry.Values.Where(x => x.Attribute.KT == "PK").First();
                    dynamic dynamicPKValue = PK.Value;
                    int PKValue = dynamicPKValue;
                    if (Value == PKValue)
                    {
                        response = false;
                    }
                }
            }
            else if (DT == "FLOAT")
            {
                float Value = Convert.ToSingle(value);
                foreach (Registry registry in registries)
                {
                    Data PK = registry.Values.Where(x => x.Attribute.KT == "PK").First();
                    dynamic dynamicPKValue = PK.Value;
                    float PKValue = dynamicPKValue;
                    if (Value == PKValue) { response = false; }
                }
            }
            else if (DT == "STRING")
            {
                string Value = value;
                foreach (Registry registry in registries)
                {
                    Data PK = registry.Values.Where(x => x.Attribute.KT == "PK").First();
                    dynamic dynamicPKValue = PK.Value;
                    string PKValue = dynamicPKValue;

                    if (Value == FormatString(PKValue))
                    {
                        response = false;
                    }
                }
            }


            return response;
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

        public string FormatString(string str)
        {
            string result = string.Empty;
            int cantLimitString = 0;

            foreach(char c in str)
            {
                if(c == '\0')
                {
                    cantLimitString++;
                }
            }

            int startIndex = str.Length - cantLimitString;
            result = str.Remove(startIndex, cantLimitString);

            return result;
        }
    }
}
