namespace SMDB
{
    partial class CREATE_RECORD
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
            this.TituloTabla = new System.Windows.Forms.Label();
            this.TableViewRecord = new System.Windows.Forms.DataGridView();
            this.btnSaveRecords = new System.Windows.Forms.Button();
            this.btnCancelRecords = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TableViewRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TituloTabla
            // 
            this.TituloTabla.AutoSize = true;
            this.TituloTabla.Location = new System.Drawing.Point(12, 103);
            this.TituloTabla.Name = "TituloTabla";
            this.TituloTabla.Size = new System.Drawing.Size(128, 20);
            this.TituloTabla.TabIndex = 1;
            this.TituloTabla.Text = "Add new records";
            // 
            // TableViewRecord
            // 
            this.TableViewRecord.AllowUserToAddRows = false;
            this.TableViewRecord.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.TableViewRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableViewRecord.Location = new System.Drawing.Point(12, 149);
            this.TableViewRecord.Name = "TableViewRecord";
            this.TableViewRecord.ReadOnly = true;
            this.TableViewRecord.RowHeadersVisible = false;
            this.TableViewRecord.RowTemplate.Height = 28;
            this.TableViewRecord.Size = new System.Drawing.Size(1104, 138);
            this.TableViewRecord.TabIndex = 2;
            this.TableViewRecord.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableViewRecord_CellClick);
            this.TableViewRecord.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableViewRecord_CellValueChanged);
            this.TableViewRecord.CurrentCellDirtyStateChanged += new System.EventHandler(this.TableViewRecord_CurrentCellDirtyStateChanged);
            this.TableViewRecord.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.TableViewRecord_EditingControlShowing);
            // 
            // btnSaveRecords
            // 
            this.btnSaveRecords.Location = new System.Drawing.Point(910, 397);
            this.btnSaveRecords.Name = "btnSaveRecords";
            this.btnSaveRecords.Size = new System.Drawing.Size(86, 41);
            this.btnSaveRecords.TabIndex = 8;
            this.btnSaveRecords.Text = "&OK";
            this.btnSaveRecords.UseVisualStyleBackColor = true;
            this.btnSaveRecords.Click += new System.EventHandler(this.btnSaveRecords_Click);
            // 
            // btnCancelRecords
            // 
            this.btnCancelRecords.Location = new System.Drawing.Point(1032, 397);
            this.btnCancelRecords.Name = "btnCancelRecords";
            this.btnCancelRecords.Size = new System.Drawing.Size(86, 41);
            this.btnCancelRecords.TabIndex = 9;
            this.btnCancelRecords.Text = "Cancel";
            this.btnCancelRecords.UseVisualStyleBackColor = true;
            this.btnCancelRecords.Click += new System.EventHandler(this.btnCancelRecords_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SMDB.Properties.Resources.records;
            this.pictureBox1.InitialImage = global::SMDB.Properties.Resources.healthdb;
            this.pictureBox1.Location = new System.Drawing.Point(27, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // CREATE_RECORD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSaveRecords);
            this.Controls.Add(this.btnCancelRecords);
            this.Controls.Add(this.TableViewRecord);
            this.Controls.Add(this.TituloTabla);
            this.Name = "CREATE_RECORD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CREATE_RECORD";
            ((System.ComponentModel.ISupportInitialize)(this.TableViewRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TituloTabla;
        private System.Windows.Forms.DataGridView TableViewRecord;
        private System.Windows.Forms.Button btnSaveRecords;
        private System.Windows.Forms.Button btnCancelRecords;
        private System.Windows.Forms.PictureBox pictureBox1;

        //My variables
        SMBD Parent_SMBD;

        //---------------
    }
}