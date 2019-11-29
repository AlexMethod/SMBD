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
        #region SMDB
        //APP CONSTRUCTOR
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
            Tools_Results.Width = this.Width;
            Tools_Results.Height = this.Height;

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
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //FIRST HORIZONTAL MENU
        #region MENU_OPTIONS
        private void MenuNewDB_Click(object sender, EventArgs e)
        {
            CreateDatabase();
        }
        private void MenuConnectDB_Click(object sender, EventArgs e)
        {
            OpenDatabase();
        }
        private void MenuDisconnectDB_Click(object sender, EventArgs e)
        {
            //Close
        }
        private void MenuClose_Click(object sender, EventArgs e)
        {

        }
        private void MenuDeleteDB_Click(object sender, EventArgs e)
        {
            DeleteDatabase();
        }
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        //SECOND HORIZONTAL MENU
        #region MENU_HORIZONTAL_OPTIONS
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
        private void MenuHDeleteDB_Click(object sender, EventArgs e)
        {
            DeleteDatabase();
        }
        #endregion
        //REFRESH
        #region UPDATES
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
            this.Text = DB.Path;
        }
        public void DisplayDB()
        {
            TreeView.Nodes.Clear();

            TreeNode[] tables = new TreeNode[DB.tables.Count];
            for (int indexTable = 0; indexTable < tables.Length; indexTable++)
            {
                Table t = DB.tables[indexTable];
                if(t.attributes.Count > 0)
                {
                    TreeNode[] attributes = new TreeNode[t.attributes.Count];
                    for (int indexAttr = 0; indexAttr < t.attributes.Count; indexAttr++)
                    {
                        Attribute_ attr = t.attributes[indexAttr];
                        if(attr.KT == "PK")
                        {
                            attributes[indexAttr] = new TreeNode(attr.Name, 33, 33);
                        }
                        else if (attr.KT == "FK")
                        {
                            attributes[indexAttr] = new TreeNode(attr.Name, 34, 34);
                        }
                        else
                        {
                            attributes[indexAttr] = new TreeNode(attr.Name, 32, 32);
                        }


                        
                        attributes[indexAttr].ContextMenuStrip = MenuRAttribute;
                    }
                    tables[indexTable] = new TreeNode(t.ShortName,0,0, attributes);
                }
                else
                {
                    tables[indexTable] = new TreeNode(t.ShortName,0,0);
                }
                tables[indexTable].ContextMenuStrip = MenuRightTable;
            }

            TreeNode rootDatabase = new TreeNode(DB.Name, 10, 10, tables);
            TreeView.Nodes.Add(rootDatabase);
            rootDatabase.ContextMenuStrip = MenuRightTreeView;
            //TreeView.ExpandAll();
            ExpandToLevel(TreeView.Nodes, 1);

        }
        #endregion
        //KEYBOARD COMMANDS FOR QUICK ACCESS
        #region SHORTCUTS
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
        #endregion
        #endregion

        #region DATABASE
        public void CreateDatabase()
        {
            Create_DB = new CREATE_DB();
            Create_DB.Parent_SMBD = this;
            Create_DB.Show();
        }
        public void DeleteDatabase()
        {
            string messageAnswer = String.Format("Are you sure you want to delete the current Database{0}{1}", Environment.NewLine, DB.Name);
            string messageError = "The object is not available";
            if (DB.isDB())
            {
                DialogResult result = MessageBox.Show(messageAnswer, "Delete Database!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DB.Delete();
                    Text = "SMBD";
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
            if (newName != null && newName != "")
            {
                DB.Rename(newName);
            }
            else
            {
                string message = "The DB must have a name";
                DialogResult result = MessageBox.Show(message, "Not Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        
        public void CloseDatabase()
        {
            TreeView.Nodes.Clear();
            MenuUpdate(false);
            Text = "SMBD";
            DB = null;
        }
        public void OpenDatabase()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string lastPath = currentAppDirectory + "\\" + "lastPath.lp";
            FileHandler.createFile(lastPath);
            //FileStream file_lastPath = FileHandler.openFile(lastPath);

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string[] folders = folderBrowserDialog.SelectedPath.Split('\\');
                DB = new Database(folders[folders.Length - 1], folderBrowserDialog.SelectedPath, false);
                if (DB.isDB())
                {
                    MenuUpdate(true);
                    TitleUpdate();
                    DisplayDB();
                }
                else
                {
                    string message = "The selected object is not a DB";
                    DB = null;
                    DialogResult result = MessageBox.Show(message, "Not a DB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    OpenDatabase();
                }

            }
        }

        #region MENU_RIGHT_CLICK
        private void MenuRCreateTable_Click(object sender, EventArgs e)
        {
            CreateTable();
        }
        #endregion
        #endregion

        #region TABLE
        private void CreateTable()
        {
            Create_Table = new CREATE_TABLE(this);
            Create_Table.Show();
        }
        public void RenameTable(string oldName, string newName)
        {
            if (newName != null && newName != "" && DB.Path != "")
            {
                string origin = DB.Path + "\\" + oldName + ".dbtable";
                string destiny = DB.Path + "\\" + newName + ".dbtable";

                DB.tables.Find(x => x.Name == origin).Rename(destiny);
            }
            else
            {
                string message = "The Table must have a name";
                DialogResult result = MessageBox.Show(message, "Not Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void DeleteTable()
        {

            TreeNode selected = TreeView.SelectedNode;
            string messageErrorInvalidObject = "Invalid object";
            string messageErrorDeleteTable = "The table cannot be deleted because it has a foreign relationship";

            string tablePath = Path.Combine(DB.Path, selected.Text + ".dbtable");
            Table TableToDelete = DB.tables.Find(x=> x.Name == tablePath);
            int IDTable = TableToDelete.IDTable;
            


            if(selected != null)
            {
                if (ValidateDeletingTable(IDTable))
                {
                    string messageAnswer = String.Format("Are you sure you want to delete the current Table{0} {1}", Environment.NewLine,selected.Text);
                    DialogResult result = MessageBox.Show(messageAnswer, "Delete Database!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                    
                        DB.tables.Find(x => x.Name == tablePath).Delete();
                        DB.tables.Remove(DB.tables.Find(x => x.Name == tablePath));
                        DisplayDB();
                    }
                }
                else
                {
                    MessageBox.Show(messageErrorDeleteTable, "Cannot delete table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(messageErrorInvalidObject, "Invalid Object", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            
        }

        public bool ValidateDeletingTable(int IDTable)
        {
            bool isOkReferentialIntegrity = true;

            var TablesAttributes = DB.tables.Select(s => s.attributes);

            foreach (var TableAttributes in TablesAttributes)
            {
                int CantFK = TableAttributes.FindAll(x => x.KT == "FK" && x.FK == IDTable).Count();
                if (CantFK > 0) return false;
            }

            return isOkReferentialIntegrity;
        }

        #region MENU_RIGHT_CLICK
        private void MenuRTableDeleteTable_Click(object sender, EventArgs e)
        {
            DeleteTable();
        }
        #endregion
        #endregion

        #region ATTRIBUTE
        //INSIDE THIS GOES ATTRIBUTE METHODS TO HANDLE ATTRIBUTES
        #endregion

        #region TEXTBOX_NAME_HANDLER
        //Controls what object (DB,Table,Atribute) is going to be edited (Name)
        private void TreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Level == 0)
                {
                    isEditDB = true;
                    isEditTable = false;
                    isEditAttribute = false;
                }
                else if (e.Node.Level == 1)
                {
                    isEditDB = false;
                    isEditTable = true;
                    isEditAttribute = false;
                }
                else if (e.Node.Level == 2)
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
        //Applies the method of the current control to be edited (Name)
        private void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != null && e.Label != null && e.Label != "")
            {
                if (isEditDB)
                {
                    RenameDatabase(e.Label);
                }
                else if (isEditTable)
                {
                    RenameTable(e.Node.Text, e.Label);
                }
                else if (isEditAttribute)
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




        #endregion

        //SELECT NODE WHEN RIGHT CLICK
        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView.SelectedNode = e.Node;

            if (e.Node != null)
            {
                if (e.Node.Level == 0)
                {
                    //Do something
                }
                else if (e.Node.Level == 1)
                {
                    //Do Something
                    ShowTableRecords();


                }
                else if (e.Node.Level == 2)
                {
                    //Do Something
                }
            }
        }

        private void TreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView.SelectedNode = e.Node;
            
            if (e.Node != null)
            {
                if (e.Node.Level == 0)
                {
                    //Do something
                }
                else if (e.Node.Level == 1)
                {
                    //Do Something
                    

                }
                else if (e.Node.Level == 2)
                {
                    //Do Something
                }
            }
        }

        private void ExpandToLevel(TreeNodeCollection nodes, int level)
        {
            if (level > 0)
            {
                foreach (TreeNode node in nodes)
                {
                    node.Expand();
                    ExpandToLevel(node.Nodes, level - 1);
                }
            }
        }

        private void MenuRTableAddAttribute_Click(object sender, EventArgs e)
        {
            ExceptionError EditAttributesError = new ExceptionError("Cannot Add, Delete or Update any Attribute since the table contains already registries", "CANNOT EDIT ATTRIBUTES");

            try
            {
                TreeNode selected = TreeView.SelectedNode;
                Table t = DB.tables.Where(x => x.ShortName == selected.Text).First();
                if (t.registries.Count() > 0) { throw EditAttributesError; }
                CREATE_TABLE create_table = new CREATE_TABLE("Add Attribute", this);
                create_table.SetEditTable(t);
                create_table.Show();
            }
            catch(ExceptionError err) { err.showMessage(); }
            
        }

        private void MenuRAttributeEdit_Click(object sender, EventArgs e)
        {
            TreeNode selected = TreeView.SelectedNode;
            Table t = DB.tables.Where(x => x.ShortName == selected.Parent.Text).First();
            Attribute_ a = t.attributes.Where(x => x.Name == selected.Text).First();
            CREATE_TABLE create_table = new CREATE_TABLE("Edit Attribute", this);
            create_table.SetEditAttribute(t,a);
            create_table.Show();
        }

        private void MenuRAttributeDelete_Click(object sender, EventArgs e)
        {
            TreeNode selected = TreeView.SelectedNode;
            Table t = DB.tables.Where(x => x.ShortName == selected.Parent.Text).First();
            Attribute_ a = t.attributes.Where(x => x.Name == selected.Text).First();
            a.Delete();
            t.GetAttributes();
            DisplayDB();
        }

        public void ShowTableRecords()
        {
            isEditableTable = true;
            TableSelected = DB.tables.Where(x => x.ShortName == TreeView.SelectedNode.Text).Count() > 0 ?
                    DB.tables.Where(x => x.ShortName == TreeView.SelectedNode.Text).First() : null;

            try
            {

                if (TableSelected != null)
                {
                    List<Registry> registries = TableSelected.GetRegistries();

                    //Encabezados
                    TableView.Columns.Clear();
                    
                    TableView.ReadOnly = false;
                    foreach (var attribute in TableSelected.attributes)
                    {
                        TableView.Columns.Add(attribute.Name, attribute.Name);
                    }

                    //Boton de edicion
                    DataGridViewImageColumn columImageEdit = new DataGridViewImageColumn();
                    columImageEdit.Name = "Edit";
                    columImageEdit.HeaderText = "";
                    columImageEdit.Image = Properties.Resources.edit1;
                    columImageEdit.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    columImageEdit.Width = 30;
                    TableView.Columns.Add(columImageEdit);

                    //Boton de borrado

                    DataGridViewImageColumn columImage = new DataGridViewImageColumn();
                    columImage.Name = "Delete";
                    columImage.HeaderText = "";
                    columImage.Width = 30;
                    TableView.Columns.Add(columImage);

                    
                    TableView.Rows.Add();
                    DataGridViewRow layoutRow = (DataGridViewRow)TableView.Rows[0].Clone();
                    TableView.Rows.Clear();


                    //Valores
                    foreach (Registry registry in registries)
                    {
                        DataGridViewRow row = (DataGridViewRow)layoutRow.Clone();
                        for (int i = 0; i < registry.Values.Count(); i++)
                        {
                            Data d = registry.Values[i];
                            row.Cells[i].Value = d.Value;
                        }
                        TableView.Rows.Add(row);
                    }

                    TableSelected.registries = registries;
                }
            }
            catch(ExceptionError err) { err.showMessage(); }

            

            
        }

        public void ShowTableRecordsFromQuery()
        {
            isEditableTable = false;
            Query query = null;

            try
            {

                if (validateQuery())
                {
                    query = GetQuery();
                }

                TableSelected = query.Table;

                if (TableSelected != null)
                {
                    List<Registry> registries = new List<Registry>();
                    if (query.isWhere)
                    {
                        List<Registry> auxRegistries = TableSelected.GetRegistries();

                        foreach(Registry registry in auxRegistries)
                        {
                            Data d = registry.Values.Where(x => x.Attribute.Name == query.Column).First();
                            string DT = d.Attribute.DT;
                            switch (query.Operation)
                            {
                                case "=":

                                    if(DT == "STRING")
                                    {
                                        if (FormatString(d.Value) == query.Value)
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    else if(DT == "INT"){
                                        if (d.Value == Convert.ToInt32(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }else if(DT == "FLOAT")
                                    {
                                        if (d.Value == Convert.ToSingle(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    
                                    break;
                                case ">":

                                    if (DT == "STRING")
                                    {
                                        if (FormatString(d.Value) > query.Value)
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    else if (DT == "INT")
                                    {
                                        if (d.Value > Convert.ToInt32(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    else if (DT == "FLOAT")
                                    {
                                        if (d.Value > Convert.ToSingle(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    break;
                                case "<":

                                    if (DT == "STRING")
                                    {
                                        if (FormatString(d.Value) < query.Value)
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    else if (DT == "INT")
                                    {
                                        if (d.Value < Convert.ToInt32(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    else if (DT == "FLOAT")
                                    {
                                        if (d.Value < Convert.ToSingle(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    break;
                                case ">=":

                                    if (DT == "STRING")
                                    {
                                        if (FormatString(d.Value) >= query.Value)
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    else if (DT == "INT")
                                    {
                                        if (d.Value >= Convert.ToInt32(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    else if (DT == "FLOAT")
                                    {
                                        if (d.Value >= Convert.ToSingle(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    break;
                                case "<=":

                                    if (DT == "STRING")
                                    {
                                        if (FormatString(d.Value) <= query.Value)
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    else if (DT == "INT")
                                    {
                                        if (d.Value <= Convert.ToInt32(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    else if (DT == "FLOAT")
                                    {
                                        if (d.Value <= Convert.ToSingle(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    break;
                                case "<>":

                                    if (DT == "STRING")
                                    {
                                        if (FormatString(d.Value) != query.Value)
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    else if (DT == "INT")
                                    {
                                        if (d.Value != Convert.ToInt32(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    else if (DT == "FLOAT")
                                    {
                                        if (d.Value != Convert.ToSingle(query.Value))
                                        {
                                            registries.Add(registry);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        registries = TableSelected.GetRegistries();
                    }
                    
                    List<Registry> AllRegistries = TableSelected.GetRegistries();

                    //Encabezados
                    TableView.Columns.Clear();
                    TableView.ReadOnly = true;
                    TableView.AllowUserToAddRows = false;
                    foreach (var column in query.Columns)
                    {
                        Attribute_ attribute = query.Table.attributes.Where(x => x.Name == column).First();
                        TableView.Columns.Add(attribute.Name, attribute.Name);
                    }

                    TableView.Rows.Add();
                    DataGridViewRow layoutRow = (DataGridViewRow)TableView.Rows[0].Clone();
                    TableView.Rows.Clear();

                    //Valores
                    foreach (Registry registry in registries)
                    {
                        DataGridViewRow row = (DataGridViewRow)layoutRow.Clone();

                        for(int i = 0; i< query.Columns.Count(); i++)
                        {
                            string column = query.Columns[i];
                            Attribute_ attribute = query.Table.attributes.Where(x => x.Name == column).First();
                            Data d = registry.Values.Where(x => x.Attribute.Name == column).First();
                            row.Cells[i].Value = d.Value;
                        }
                        TableView.Rows.Add(row);
                    }

                    TableSelected.registries = AllRegistries;
                }
            }
            catch (ExceptionError err) { err.showMessage(); }

        }

        private void MenuRTableAddRecord_Click(object sender, EventArgs e)
        {
            Create_Record = new CREATE_RECORD(TableSelected,this);
            Create_Record.Show();
        }

        public bool validateQuery()
        {
            ExceptionError BadSintaxis = new ExceptionError("Incorrect sintaxis, use instead [SELECT | select ] [COLUMS | *] [FROM | from] [TABLE NAME] or [SELECT | select ] [COLUMS | *] [FROM | from] [TABLE NAME] [WHERE | where] [COLUMN] [OPERATOR] [VALUE]", "ERROR");
            ExceptionError ConnectionError = new ExceptionError("The is not a DB connected", "CONNECTION ERROR");
            ExceptionError SelectError = new ExceptionError("Use SELECT or select", "SELECT ERROR");
            ExceptionError ColumnsError = new ExceptionError("The column does not exist", "COLUMNS ERROR");
            ExceptionError FromError = new ExceptionError("Use FROM or from", "FROM ERROR");
            ExceptionError TableError = new ExceptionError("The table does not exist", "TABLE ERROR");
            ExceptionError WhereError = new ExceptionError("Use WHERE or where", "WHERE ERROR");
            ExceptionError ColumnError = new ExceptionError("The column does not exist", "COLUMN ERROR");
            ExceptionError OperationError = new ExceptionError("Invalid operation", "OPERATION ERROR");
            ExceptionError ValueError = new ExceptionError("The value type does not match the column type", "VALUE ERROR");


            if (DB == null) throw ConnectionError;
            List<string> tableNames = DB.tables.Select(x => x.ShortName).ToList();
            List<string> Operations = new List<string>();
            Operations.Add("=");
            Operations.Add(">");
            Operations.Add("<");
            Operations.Add(">=");
            Operations.Add("<=");
            Operations.Add("<>");



            if (SQLQuery.Text == "") return false;
            if (SQLQuery.Text != "")
            {
                string query = SQLQuery.Text;

                string[] commands = query.Split().Where(x => x != "").ToArray();

                if (commands.Length != 4 && commands.Length != 8) throw BadSintaxis;


                string select = "";
                string columns = "";
                string from = "";
                string table = "";
                string where = "";
                string column = "";
                string operation = "";
                string value = "";

                Table Table = null;
                List<string> attributeNames = new List<string>();
                List<string> selectedColumns = new List<string>();

                if (commands.Length == 4 || commands.Length == 8)
                {
                    select = commands[0];
                    columns = commands[1];
                    from = commands[2];
                    table = commands[3];

                    if (select.ToLower() != "select") throw SelectError;
                    if (from.ToLower() != "from") throw FromError;
                    if (!tableNames.Contains(table)) throw TableError;

                    Table = DB.tables.Where(x => x.ShortName == table).First();
                    attributeNames = Table.attributes.Select(x => x.Name).ToList();
                    selectedColumns = new List<string>();

                    if (columns != "*")
                    {
                        selectedColumns = columns.Split(',').Where(x => x != "").ToList();
                        if (selectedColumns.Count() == 0) throw ColumnsError;
                        foreach (string selectedColumn in selectedColumns)
                        {
                            if (!attributeNames.Contains(selectedColumn)) throw ColumnsError;
                        }
                    }
                    else
                    {
                        selectedColumns = attributeNames;
                    }
                }
                if (commands.Length == 8)
                {
                    where = commands[4];
                    column = commands[5];
                    operation = commands[6];
                    value = commands[7];



                    if (where.ToLower() != "where") throw WhereError;
                    if (!Operations.Contains(operation)) throw OperationError;
                    if (!attributeNames.Contains(column)) throw ColumnError;

                    Attribute_ attribute = Table.attributes.Where(x => x.Name == column).First();

                    if (attribute.DT == "STRING" && value[0] != '\'' && value[column.Length - 1] != '\'') throw ValueError;
                    if (attribute.DT == "INT")
                    {
                        try
                        {
                            Convert.ToInt32(value);
                        }
                        catch (Exception) { throw ValueError; }
                    }
                    if (attribute.DT == "FLOAT")
                    {
                        try
                        {
                            Convert.ToSingle(value);
                        }
                        catch (Exception) { throw ValueError; }
                    }
                }
            }


            return true;


        }

        public Query GetQuery()
        {
            Query Query = new Query();

            string query = SQLQuery.Text;
            string[] commands = query.Split().Where(x => x != "").ToArray();

            
            string columns = "";
            string table = "";
            string column = "";
            string operation = "";
            string value = "";

            
            columns = commands[1];
            table = commands[3];

            Table Table = null;
            List<string> attributeNames = new List<string>();
            List<string> selectedColumns = new List<string>();


            Table = DB.tables.Where(x => x.ShortName == table).First();
            attributeNames = Table.attributes.Select(x => x.Name).ToList();
            if (columns != "*")
            {
                selectedColumns = columns.Split(',').Where(x => x != "").ToList();
            }
            else
            {
                selectedColumns = attributeNames;
            }
            
            
            if (commands.Length == 8)
            {
                column = commands[5];
                operation = commands[6];
                value = commands[7];

                Attribute_ attribute = Table.attributes.Where(x => x.Name == column).First();
                Query.Column = column;
                Query.DT = attribute.DT;
                Query.Operation = operation;
                if (attribute.DT == "STRING")
                {
                    value = value.Remove(0, 1);
                    value = value.Remove(value.Length - 1, 1);
                }
                Query.Value = value;
                Query.isWhere = true;
            }
            else
            {
                Query.isWhere = false;
            }

            
            Query.Columns = selectedColumns;
            Query.Table = Table;
            


            return Query;
        }

        private void MenuHRunQuery_Click(object sender, EventArgs e)
        {
            ShowTableRecordsFromQuery();
        }

        public string FormatString(string str)
        {
            string result = string.Empty;
            int cantLimitString = 0;

            foreach (char c in str)
            {
                if (c == '\0')
                {
                    cantLimitString++;
                }
            }

            int startIndex = str.Length - cantLimitString;
            result = str.Remove(startIndex, cantLimitString);

            return result;
        }

        private void TableView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ExceptionError ConstraintError = new ExceptionError("This registry cannot be deleted cause there are at least one registry using it in a foreign relation", "CANNOT DELETE REGISTRY");
            if(e.RowIndex != -1 && isEditableTable)
            {
                DataGridViewRow rowSelected = TableView.Rows[e.RowIndex >= 0 ? e.RowIndex : 0];
                RowSelected = rowSelected;
                if (!rowSelected.IsNewRow && e.ColumnIndex == TableView.Columns.Count - 1) //Borrar registro
                {
                    string messageAnswer = String.Format("Are you sure you want to delete the selected registry");
                    DialogResult result = MessageBox.Show(messageAnswer, "Delete Registsry!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {


                        try
                        {

                            Registry registryToDelete = TableSelected.registries[rowSelected.Index];
                            List<Table> ForeignTables = DB.tables.Where(x => x.attributes.Where(y => y.FK == TableSelected.IDTable).Count() > 0).ToList();
                            foreach (Table t in ForeignTables)
                            {
                                List<Registry> registries = t.GetRegistries();
                                foreach (Registry registry in registries)
                                {
                                    List<Data> ValuesFK = registry.Values.Where(x => x.Attribute.FK == TableSelected.IDTable).ToList();
                                    dynamic ValueToDeletePK = registryToDelete.Values.Where(x => x.Attribute.KT == "PK").First().Value;
                                    foreach (Data d in ValuesFK)
                                    {
                                        dynamic ValueFK = d.Value;
                                        if (ValueFK == ValueToDeletePK)
                                        {
                                            //Error
                                            throw ConstraintError;
                                        }
                                    }
                                }

                            }

                            registryToDelete.Delete(TableSelected.Name);
                            TableSelected.GetRegistries();
                            ShowTableRecords();
                        }
                        catch (ExceptionError err) { err.showMessage(); }

                    }

                }
                else if (!rowSelected.IsNewRow && e.ColumnIndex == TableView.Columns.Count - 2) //Editar registro
                {
                    ExceptionError NullValueForIntFloat = new ExceptionError("Values of type INT or FLOAT cannot be empty", "ERROR VALUE");

                    try
                    {
                        Registry registryToEdit = TableSelected.registries.Count() > 0 ? TableSelected.registries[RowSelected.Index] : null;
                        List<Data> values = new List<Data>();
                        for (int i = 0; i < rowSelected.Cells.Count - 2; i++)
                        {
                            DataGridViewCell cell = rowSelected.Cells[i];
                            Attribute_ attribute = TableSelected.attributes[i];

                            if(attribute.DT == "INT")
                            {
                                try
                                {
                                    Convert.ToInt32(cell.Value);
                                }
                                catch (Exception) { throw NullValueForIntFloat; }
                            }
                            if (attribute.DT == "FLOAT")
                            {
                                try
                                {
                                    Convert.ToSingle(cell.Value);
                                }
                                catch (Exception) { throw NullValueForIntFloat; }
                            }
                            Data data = new Data(cell.Value, attribute);
                            values.Add(data);
                        }

                        registryToEdit.Update(TableSelected.Name, values);

                    }
                    catch(ExceptionError err) { err.showMessage(); }
                    
                }
            }
        }

        private void IntColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            Registry registryToEdit = TableSelected.registries.Count() > 0 ? TableSelected.registries[RowSelected.Index] : null;

            bool isRegistryInForeignRelation = registryToEdit != null ? isRegistryInRelation(registryToEdit) : false;
            bool isCurrentCellPK = registryToEdit != null ? registryToEdit.Values[TableView.CurrentCell.ColumnIndex].Attribute.KT == "PK" : false;
            bool isNotPossibleToEdit = isRegistryInForeignRelation && isCurrentCellPK;
            
            
            if (   (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || isNotPossibleToEdit  )
            {
                e.Handled = true;
            }
        }

        private void FloatColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            Registry registryToEdit = TableSelected.registries.Count() > 0 ? TableSelected.registries[RowSelected.Index] : null;

            bool isRegistryInForeignRelation = registryToEdit != null ? isRegistryInRelation(registryToEdit) : false;
            bool isCurrentCellPK = registryToEdit != null ? registryToEdit.Values[TableView.CurrentCell.ColumnIndex].Attribute.KT == "PK" : false;
            bool isNotPossibleToEdit = isRegistryInForeignRelation && isCurrentCellPK;

            if (  (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.')) || isNotPossibleToEdit )
            {
                e.Handled = true;
            }
        }

        private void StringColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            int columnIndex = TableView.CurrentCell.ColumnIndex;
            string columnName = TableView.Columns[columnIndex].Name;
            Attribute_ Attribute = TableSelected.attributes.Find(x => x.Name == columnName);


            Registry registryToEdit = TableSelected.registries.Count() > 0 ? TableSelected.registries[RowSelected.Index] : null;

            bool isRegistryInForeignRelation = registryToEdit != null ? isRegistryInRelation(registryToEdit) : false;
            bool isCurrentCellPK = registryToEdit != null ? registryToEdit.Values[TableView.CurrentCell.ColumnIndex].Attribute.KT == "PK" : false;
            bool isNotPossibleToEdit = isRegistryInForeignRelation && isCurrentCellPK;


            if (Attribute != null)
            {
                int MaxLength = Attribute.Length;
                if (TableView.CurrentCell.Value != null)
                {
                    string rawValue = (string)TableView.CurrentCell.Value;
                    string value = FormatString(rawValue);
                    if ( (value.Length >= MaxLength && e.KeyChar != '\b') || isNotPossibleToEdit)
                    {
                        e.Handled = true;
                    }

                }
            }


        }

        private void TableView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ExceptionError DataError = new ExceptionError("Incorrect value", "INCORRECT DATA");

            e.Control.KeyPress -= new KeyPressEventHandler(IntColumn_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(FloatColumn_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(StringColumn_KeyPress);

            int columnIndex = TableView.CurrentCell.ColumnIndex;
            string columnName = TableView.Columns[columnIndex].Name;

            //Obtiene los atributos agrupados por tipo de dato
            var IntAttributes = TableSelected.attributes.Where(x => x.DT == "INT");
            var FloatAttributes = TableSelected.attributes.Where(x => x.DT == "FLOAT");
            var StringAttributes = TableSelected.attributes.Where(x => x.DT == "STRING");

            //Crea una lista de los nombres de los atributos agrupados por tipo de dato
            List<string> NamesIntAttributes = IntAttributes.Count() > 0 ? IntAttributes.Select(s => s.Name).ToList() : new List<string>();
            List<string> NamesFloatAttributes = FloatAttributes.Count() > 0 ? FloatAttributes.Select(s => s.Name).ToList() : new List<string>();
            List<string> NamesStringAttributes = StringAttributes.Count() > 0 ? StringAttributes.Select(s => s.Name).ToList() : new List<string>();

            //Verifica el tipo de la celda actual
            bool typeInt = NamesIntAttributes.Contains(columnName);
            bool typeFloat = NamesFloatAttributes.Contains(columnName);
            bool stringType = NamesStringAttributes.Contains(columnName);


            //Valida que no se puedan ingresar letras si el tipo de atributo es entero o flotante
            if (typeInt)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(IntColumn_KeyPress);
                }
            }
            else if (typeFloat)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(FloatColumn_KeyPress);
                }
            }
            else if (stringType)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(StringColumn_KeyPress);
                }
            }
        }

        private void TableView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowSelected = TableView.Rows[e.RowIndex >= 0 ? e.RowIndex : 0];
            string value = rowSelected.Cells[e.ColumnIndex].Value != null ? (string)rowSelected.Cells[e.ColumnIndex].Value : "";

            
            TableView.CurrentCell.Value = value;
        }

        private void TableView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (TableView.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                TableView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        public bool isRegistryInRelation(Registry registryToBeEdited)
        {
            
            bool blockPK = false;

            List<Table> ForeignTables = DB.tables.Where(x => x.attributes.Where(y => y.FK == TableSelected.IDTable).Count() > 0).ToList();
            foreach (Table t in ForeignTables)
            {
                List<Registry> registries = t.GetRegistries();
                foreach (Registry registry in registries)
                {
                    List<Data> ValuesFK = registry.Values.Where(x => x.Attribute.FK == TableSelected.IDTable).ToList();
                    dynamic ValueToDeletePK = registryToBeEdited.Values.Where(x => x.Attribute.KT == "PK").First().Value;
                    foreach (Data d in ValuesFK)
                    {
                        dynamic ValueFK = d.Value;
                        if (ValueFK == ValueToDeletePK)
                        {
                            blockPK = true;
                        }
                    }
                }

            }
            return blockPK;
        }
    }
}
