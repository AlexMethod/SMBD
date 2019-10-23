using SMDB.Classes;
namespace SMDB
{
    partial class CREATE_TABLE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.MenuRRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MRRowDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.DGAttributes = new System.Windows.Forms.DataGridView();
            this.DGName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DGLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGKeyType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DGFKTable = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DGBorrar = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MenuRRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGAttributes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(968, 387);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 41);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "&OK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1078, 387);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 41);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancelDB_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SMDB.Properties.Resources.table_icon;
            this.pictureBox1.InitialImage = global::SMDB.Properties.Resources.healthdb;
            this.pictureBox1.Location = new System.Drawing.Point(37, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(131, 104);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(981, 26);
            this.txtName.TabIndex = 8;
            // 
            // MenuRRow
            // 
            this.MenuRRow.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuRRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MRRowDeleteRow});
            this.MenuRRow.Name = "MenuRRow";
            this.MenuRRow.Size = new System.Drawing.Size(174, 34);
            // 
            // MRRowDeleteRow
            // 
            this.MRRowDeleteRow.Name = "MRRowDeleteRow";
            this.MRRowDeleteRow.Size = new System.Drawing.Size(173, 30);
            this.MRRowDeleteRow.Text = "Delete Row";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Attributes:";
            // 
            // DGAttributes
            // 
            this.DGAttributes.AllowUserToResizeColumns = false;
            this.DGAttributes.AllowUserToResizeRows = false;
            this.DGAttributes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DGAttributes.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DGAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGName,
            this.DGDataType,
            this.DGLength,
            this.DGKeyType,
            this.DGFKTable,
            this.DGBorrar});
            this.DGAttributes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGAttributes.Location = new System.Drawing.Point(37, 164);
            this.DGAttributes.MultiSelect = false;
            this.DGAttributes.Name = "DGAttributes";
            this.DGAttributes.RowHeadersVisible = false;
            this.DGAttributes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGAttributes.RowTemplate.Height = 28;
            this.DGAttributes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGAttributes.Size = new System.Drawing.Size(892, 224);
            this.DGAttributes.TabIndex = 16;
            this.DGAttributes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGAttributes_CellClick);
            this.DGAttributes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGAttributes_CellValueChanged);
            this.DGAttributes.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGAttributes_CurrentCellDirtyStateChanged);
            this.DGAttributes.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DGAttributes_DefaultValuesNeeded);
            this.DGAttributes.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DGAttributes_RowsAdded);
            // 
            // DGName
            // 
            this.DGName.ContextMenuStrip = this.MenuRRow;
            this.DGName.HeaderText = "Name";
            this.DGName.Name = "DGName";
            // 
            // DGDataType
            // 
            this.DGDataType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.DGDataType.HeaderText = "DataType";
            this.DGDataType.Items.AddRange(new object[] {
            "INT",
            "FLOAT",
            "STRING"});
            this.DGDataType.Name = "DGDataType";
            // 
            // DGLength
            // 
            this.DGLength.HeaderText = "Length";
            this.DGLength.Name = "DGLength";
            // 
            // DGKeyType
            // 
            this.DGKeyType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.DGKeyType.HeaderText = "KeyType";
            this.DGKeyType.Items.AddRange(new object[] {
            "PK",
            "FK",
            "NA"});
            this.DGKeyType.Name = "DGKeyType";
            // 
            // DGFKTable
            // 
            this.DGFKTable.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.DGFKTable.HeaderText = "FKTable";
            this.DGFKTable.Items.AddRange(new object[] {
            "ToDelete"});
            this.DGFKTable.Name = "DGFKTable";
            // 
            // DGBorrar
            // 
            this.DGBorrar.HeaderText = "";
            this.DGBorrar.Image = global::SMDB.Properties.Resources.nodb;
            this.DGBorrar.Name = "DGBorrar";
            this.DGBorrar.Width = 50;
            // 
            // CREATE_TABLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 440);
            this.Controls.Add(this.DGAttributes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "CREATE_TABLE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CREATE_TABLE";
            this.Load += new System.EventHandler(this.CREATE_TABLE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MenuRRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGAttributes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;

        //MY VARIABLES
        public SMBD Parent_SMBD;
        public string Command = "ADD_TABLE";
        public Table TableEdit;
        public Attribute_ AttributeEdit;
        //-------------------
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip MenuRRow;
        private System.Windows.Forms.ToolStripMenuItem MRRowDeleteRow;
        private System.Windows.Forms.DataGridView DGAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGName;
        private System.Windows.Forms.DataGridViewComboBoxColumn DGDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGLength;
        private System.Windows.Forms.DataGridViewComboBoxColumn DGKeyType;
        private System.Windows.Forms.DataGridViewComboBoxColumn DGFKTable;
        private System.Windows.Forms.DataGridViewImageColumn DGBorrar;
    }
}