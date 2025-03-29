namespace DemoEXXX24
{
    partial class ModelForm
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
            System.Windows.Forms.Label modelNameLabel;
            System.Windows.Forms.Label manufacturerIDLabel;
            this.demEx24DataSet = new DemoEXXX24.DemEx24DataSet();
            this.modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.ModelTableAdapter();
            this.tableAdapterManager = new DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager();
            this.manufacturerTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.ManufacturerTableAdapter();
            this.modelDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.manufacturerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.modelNameTextBox = new System.Windows.Forms.TextBox();
            this.manufacturerIDComboBox = new System.Windows.Forms.ComboBox();
            this.manufacturerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            modelNameLabel = new System.Windows.Forms.Label();
            manufacturerIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // modelNameLabel
            // 
            modelNameLabel.AutoSize = true;
            modelNameLabel.Location = new System.Drawing.Point(18, 106);
            modelNameLabel.Name = "modelNameLabel";
            modelNameLabel.Size = new System.Drawing.Size(70, 13);
            modelNameLabel.TabIndex = 46;
            modelNameLabel.Text = "Model Name:";
            // 
            // manufacturerIDLabel
            // 
            manufacturerIDLabel.AutoSize = true;
            manufacturerIDLabel.Location = new System.Drawing.Point(1, 132);
            manufacturerIDLabel.Name = "manufacturerIDLabel";
            manufacturerIDLabel.Size = new System.Drawing.Size(87, 13);
            manufacturerIDLabel.TabIndex = 47;
            manufacturerIDLabel.Text = "Manufacturer ID:";
            // 
            // demEx24DataSet1
            // 
            this.demEx24DataSet.DataSetName = "DemEx24DataSet1";
            this.demEx24DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // modelBindingSource
            // 
            this.modelBindingSource.DataMember = "Model";
            this.modelBindingSource.DataSource = this.demEx24DataSet;
            // 
            // modelTableAdapter
            // 
            this.modelTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ComponentTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.EquipmentComponentTableAdapter = null;
            this.tableAdapterManager.EquipmentTableAdapter = null;
            this.tableAdapterManager.FaultTypeTableAdapter = null;
            this.tableAdapterManager.ManufacturerTableAdapter = this.manufacturerTableAdapter;
            this.tableAdapterManager.ModelTableAdapter = this.modelTableAdapter;
            this.tableAdapterManager.PartsOrderComponentTableAdapter = null;
            this.tableAdapterManager.PartsOrderTableAdapter = null;
            this.tableAdapterManager.PersonTableAdapter = null;
            this.tableAdapterManager.RequestTableAdapter = null;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // manufacturerTableAdapter
            // 
            this.manufacturerTableAdapter.ClearBeforeFill = true;
            // 
            // modelDataGridView
            // 
            this.modelDataGridView.AutoGenerateColumns = false;
            this.modelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.modelDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.modelDataGridView.DataSource = this.modelBindingSource;
            this.modelDataGridView.Location = new System.Drawing.Point(1, 8);
            this.modelDataGridView.Name = "modelDataGridView";
            this.modelDataGridView.Size = new System.Drawing.Size(251, 90);
            this.modelDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ModelName";
            this.dataGridViewTextBoxColumn2.HeaderText = "ModelName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ManufacturerID";
            this.dataGridViewTextBoxColumn3.DataSource = this.manufacturerBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "ManufacturerName";
            this.dataGridViewTextBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn3.HeaderText = "ManufacturerID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "ManufacturerID";
            // 
            // manufacturerBindingSource
            // 
            this.manufacturerBindingSource.DataMember = "Manufacturer";
            this.manufacturerBindingSource.DataSource = this.demEx24DataSet;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(177, 169);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 46;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(96, 169);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateBtn.TabIndex = 45;
            this.UpdateBtn.Text = "Сохранить";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(15, 169);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 44;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // modelNameTextBox
            // 
            this.modelNameTextBox.CausesValidation = false;
            this.modelNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modelBindingSource, "ModelName", true));
            this.modelNameTextBox.Location = new System.Drawing.Point(94, 103);
            this.modelNameTextBox.Name = "modelNameTextBox";
            this.modelNameTextBox.Size = new System.Drawing.Size(158, 20);
            this.modelNameTextBox.TabIndex = 47;
            // 
            // manufacturerIDComboBox
            // 
            this.manufacturerIDComboBox.CausesValidation = false;
            this.manufacturerIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.modelBindingSource, "ManufacturerID", true));
            this.manufacturerIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.modelBindingSource, "ManufacturerID", true));
            this.manufacturerIDComboBox.DataSource = this.manufacturerBindingSource1;
            this.manufacturerIDComboBox.DisplayMember = "ManufacturerName";
            this.manufacturerIDComboBox.FormattingEnabled = true;
            this.manufacturerIDComboBox.Location = new System.Drawing.Point(94, 129);
            this.manufacturerIDComboBox.Name = "manufacturerIDComboBox";
            this.manufacturerIDComboBox.Size = new System.Drawing.Size(158, 21);
            this.manufacturerIDComboBox.TabIndex = 48;
            this.manufacturerIDComboBox.ValueMember = "ManufacturerID";
            // 
            // manufacturerBindingSource1
            // 
            this.manufacturerBindingSource1.DataMember = "Manufacturer";
            this.manufacturerBindingSource1.DataSource = this.demEx24DataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(100, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "+ Добавить произваодителя";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 201);
            this.Controls.Add(this.label2);
            this.Controls.Add(manufacturerIDLabel);
            this.Controls.Add(this.manufacturerIDComboBox);
            this.Controls.Add(modelNameLabel);
            this.Controls.Add(this.modelNameTextBox);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.modelDataGridView);
            this.Name = "ModelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModelForm";
            this.Load += new System.EventHandler(this.ModelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DemEx24DataSet demEx24DataSet;
        private System.Windows.Forms.BindingSource modelBindingSource;
        private DemEx24DataSetTableAdapters.ModelTableAdapter modelTableAdapter;
        private DemEx24DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView modelDataGridView;
        private DemEx24DataSetTableAdapters.ManufacturerTableAdapter manufacturerTableAdapter;
        private System.Windows.Forms.BindingSource manufacturerBindingSource;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox modelNameTextBox;
        private System.Windows.Forms.ComboBox manufacturerIDComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource manufacturerBindingSource1;
        private System.Windows.Forms.Label label2;
    }
}