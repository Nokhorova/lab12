namespace DemoEXXX24
{
    partial class EquipmentForm
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
            System.Windows.Forms.Label equipmentNameLabel;
            System.Windows.Forms.Label modelIDLabel;
            this.label2 = new System.Windows.Forms.Label();
            this.demEx24DataSet = new DemoEXXX24.DemEx24DataSet();
            this.equipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.EquipmentTableAdapter();
            this.tableAdapterManager = new DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager();
            this.modelTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.ModelTableAdapter();
            this.equipmentDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentNameTextBox = new System.Windows.Forms.TextBox();
            this.modelIDComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            equipmentNameLabel = new System.Windows.Forms.Label();
            modelIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // equipmentNameLabel
            // 
            equipmentNameLabel.AutoSize = true;
            equipmentNameLabel.Location = new System.Drawing.Point(24, 124);
            equipmentNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            equipmentNameLabel.Name = "equipmentNameLabel";
            equipmentNameLabel.Size = new System.Drawing.Size(114, 16);
            equipmentNameLabel.TabIndex = 38;
            equipmentNameLabel.Text = "Equipment Name:";
            // 
            // modelIDLabel
            // 
            modelIDLabel.AutoSize = true;
            modelIDLabel.Location = new System.Drawing.Point(75, 156);
            modelIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            modelIDLabel.Name = "modelIDLabel";
            modelIDLabel.Size = new System.Drawing.Size(64, 16);
            modelIDLabel.TabIndex = 39;
            modelIDLabel.Text = "Model ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(149, 182);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "+ Добавить модель";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // demEx24DataSet
            // 
            this.demEx24DataSet.DataSetName = "DemEx24DataSet1";
            this.demEx24DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // equipmentBindingSource
            // 
            this.equipmentBindingSource.DataMember = "Equipment";
            this.equipmentBindingSource.DataSource = this.demEx24DataSet;
            // 
            // equipmentTableAdapter
            // 
            this.equipmentTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ComponentTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.EquipmentComponentTableAdapter = null;
            this.tableAdapterManager.EquipmentTableAdapter = this.equipmentTableAdapter;
            this.tableAdapterManager.FaultTypeTableAdapter = null;
            this.tableAdapterManager.ManufacturerTableAdapter = null;
            this.tableAdapterManager.ModelTableAdapter = this.modelTableAdapter;
            this.tableAdapterManager.PartsOrderComponentTableAdapter = null;
            this.tableAdapterManager.PartsOrderTableAdapter = null;
            this.tableAdapterManager.PersonTableAdapter = null;
            this.tableAdapterManager.RequestTableAdapter = null;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // modelTableAdapter
            // 
            this.modelTableAdapter.ClearBeforeFill = true;
            // 
            // equipmentDataGridView
            // 
            this.equipmentDataGridView.AutoGenerateColumns = false;
            this.equipmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.equipmentDataGridView.DataSource = this.equipmentBindingSource;
            this.equipmentDataGridView.Location = new System.Drawing.Point(16, 12);
            this.equipmentDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.equipmentDataGridView.Name = "equipmentDataGridView";
            this.equipmentDataGridView.RowHeadersWidth = 51;
            this.equipmentDataGridView.Size = new System.Drawing.Size(329, 101);
            this.equipmentDataGridView.TabIndex = 38;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "EquipmentName";
            this.dataGridViewTextBoxColumn2.HeaderText = "EquipmentName";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ModelID";
            this.dataGridViewTextBoxColumn3.DataSource = this.modelBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "ModelName";
            this.dataGridViewTextBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn3.HeaderText = "ModelID";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "ModelID";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // modelBindingSource
            // 
            this.modelBindingSource.DataMember = "Model";
            this.modelBindingSource.DataSource = this.demEx24DataSet;
            // 
            // equipmentNameTextBox
            // 
            this.equipmentNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentBindingSource, "EquipmentName", true));
            this.equipmentNameTextBox.Location = new System.Drawing.Point(153, 121);
            this.equipmentNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.equipmentNameTextBox.Name = "equipmentNameTextBox";
            this.equipmentNameTextBox.Size = new System.Drawing.Size(193, 22);
            this.equipmentNameTextBox.TabIndex = 39;
            // 
            // modelIDComboBox
            // 
            this.modelIDComboBox.CausesValidation = false;
            this.modelIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentBindingSource, "ModelID", true));
            this.modelIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.equipmentBindingSource, "ModelID", true));
            this.modelIDComboBox.DataSource = this.modelBindingSource;
            this.modelIDComboBox.DisplayMember = "ModelName";
            this.modelIDComboBox.FormattingEnabled = true;
            this.modelIDComboBox.Location = new System.Drawing.Point(153, 153);
            this.modelIDComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.modelIDComboBox.Name = "modelIDComboBox";
            this.modelIDComboBox.Size = new System.Drawing.Size(193, 24);
            this.modelIDComboBox.TabIndex = 40;
            this.modelIDComboBox.ValueMember = "ModelID";
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(236, 202);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(100, 28);
            this.DeleteBtn.TabIndex = 43;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(128, 202);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(100, 28);
            this.UpdateBtn.TabIndex = 42;
            this.UpdateBtn.Text = "Сохранить";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(20, 202);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(100, 28);
            this.AddBtn.TabIndex = 41;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // EquipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 247);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(modelIDLabel);
            this.Controls.Add(this.modelIDComboBox);
            this.Controls.Add(equipmentNameLabel);
            this.Controls.Add(this.equipmentNameTextBox);
            this.Controls.Add(this.equipmentDataGridView);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EquipmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EquipmentForm";
            this.Load += new System.EventHandler(this.EquipmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private DemEx24DataSet demEx24DataSet;
        private System.Windows.Forms.BindingSource equipmentBindingSource;
        private DemEx24DataSetTableAdapters.EquipmentTableAdapter equipmentTableAdapter;
        private DemEx24DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DemEx24DataSetTableAdapters.ModelTableAdapter modelTableAdapter;
        private System.Windows.Forms.DataGridView equipmentDataGridView;
        private System.Windows.Forms.BindingSource modelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TextBox equipmentNameTextBox;
        private System.Windows.Forms.ComboBox modelIDComboBox;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button AddBtn;
    }
}