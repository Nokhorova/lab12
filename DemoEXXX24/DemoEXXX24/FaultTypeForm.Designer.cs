namespace DemoEXXX24
{
    partial class FaultTypeForm
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
            System.Windows.Forms.Label faultTypeNameLabel;
            this.demEx24DataSet = new DemoEXXX24.DemEx24DataSet();
            this.faultTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.faultTypeTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.FaultTypeTableAdapter();
            this.tableAdapterManager = new DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager();
            this.faultTypeDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faultTypeNameTextBox = new System.Windows.Forms.TextBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            faultTypeNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faultTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faultTypeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // faultTypeNameLabel
            // 
            faultTypeNameLabel.AutoSize = true;
            faultTypeNameLabel.Location = new System.Drawing.Point(5, 135);
            faultTypeNameLabel.Name = "faultTypeNameLabel";
            faultTypeNameLabel.Size = new System.Drawing.Size(91, 13);
            faultTypeNameLabel.TabIndex = 1;
            faultTypeNameLabel.Text = "Fault Type Name:";
            // 
            // demEx24DataSet1
            // 
            this.demEx24DataSet.DataSetName = "DemEx24DataSet1";
            this.demEx24DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // faultTypeBindingSource
            // 
            this.faultTypeBindingSource.DataMember = "FaultType";
            this.faultTypeBindingSource.DataSource = this.demEx24DataSet;
            // 
            // faultTypeTableAdapter
            // 
            this.faultTypeTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ComponentTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.EquipmentComponentTableAdapter = null;
            this.tableAdapterManager.EquipmentTableAdapter = null;
            this.tableAdapterManager.FaultTypeTableAdapter = this.faultTypeTableAdapter;
            this.tableAdapterManager.ManufacturerTableAdapter = null;
            this.tableAdapterManager.ModelTableAdapter = null;
            this.tableAdapterManager.PartsOrderComponentTableAdapter = null;
            this.tableAdapterManager.PartsOrderTableAdapter = null;
            this.tableAdapterManager.PersonTableAdapter = null;
            this.tableAdapterManager.RequestTableAdapter = null;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // faultTypeDataGridView
            // 
            this.faultTypeDataGridView.AutoGenerateColumns = false;
            this.faultTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.faultTypeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.faultTypeDataGridView.DataSource = this.faultTypeBindingSource;
            this.faultTypeDataGridView.Location = new System.Drawing.Point(3, 2);
            this.faultTypeDataGridView.Name = "faultTypeDataGridView";
            this.faultTypeDataGridView.Size = new System.Drawing.Size(244, 124);
            this.faultTypeDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FaultTypeID";
            this.dataGridViewTextBoxColumn1.HeaderText = "FaultTypeID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FaultTypeName";
            this.dataGridViewTextBoxColumn2.HeaderText = "FaultTypeName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // faultTypeNameTextBox
            // 
            this.faultTypeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.faultTypeBindingSource, "FaultTypeName", true));
            this.faultTypeNameTextBox.Location = new System.Drawing.Point(102, 132);
            this.faultTypeNameTextBox.Name = "faultTypeNameTextBox";
            this.faultTypeNameTextBox.Size = new System.Drawing.Size(145, 20);
            this.faultTypeNameTextBox.TabIndex = 2;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(172, 158);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 35;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(91, 158);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateBtn.TabIndex = 34;
            this.UpdateBtn.Text = "Сохранить";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(10, 158);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 33;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // FaultTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 191);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(faultTypeNameLabel);
            this.Controls.Add(this.faultTypeNameTextBox);
            this.Controls.Add(this.faultTypeDataGridView);
            this.Name = "FaultTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FaultTypeForm";
            this.Load += new System.EventHandler(this.FaultTypeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faultTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faultTypeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DemEx24DataSet demEx24DataSet;
        private System.Windows.Forms.BindingSource faultTypeBindingSource;
        private DemEx24DataSetTableAdapters.FaultTypeTableAdapter faultTypeTableAdapter;
        private DemEx24DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView faultTypeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox faultTypeNameTextBox;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button AddBtn;
    }
}