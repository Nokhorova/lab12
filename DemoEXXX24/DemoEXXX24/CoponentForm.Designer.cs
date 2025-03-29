namespace DemoEXXX24
{
    partial class CoponentForm
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
            System.Windows.Forms.Label componentNameLabel;
            this.demEx24DataSet = new DemoEXXX24.DemEx24DataSet();
            this.componentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.componentTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.ComponentTableAdapter();
            this.tableAdapterManager = new DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager();
            this.componentDataGridView = new System.Windows.Forms.DataGridView();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componentNameTextBox = new System.Windows.Forms.TextBox();
            componentNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // demEx24DataSet1
            // 
            this.demEx24DataSet.DataSetName = "DemEx24DataSet1";
            this.demEx24DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // componentBindingSource
            // 
            this.componentBindingSource.DataMember = "Component";
            this.componentBindingSource.DataSource = this.demEx24DataSet;
            // 
            // componentTableAdapter
            // 
            this.componentTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ComponentTableAdapter = this.componentTableAdapter;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.EquipmentComponentTableAdapter = null;
            this.tableAdapterManager.EquipmentTableAdapter = null;
            this.tableAdapterManager.FaultTypeTableAdapter = null;
            this.tableAdapterManager.ManufacturerTableAdapter = null;
            this.tableAdapterManager.ModelTableAdapter = null;
            this.tableAdapterManager.PartsOrderComponentTableAdapter = null;
            this.tableAdapterManager.PartsOrderTableAdapter = null;
            this.tableAdapterManager.PersonTableAdapter = null;
            this.tableAdapterManager.RequestTableAdapter = null;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // componentDataGridView
            // 
            this.componentDataGridView.AutoGenerateColumns = false;
            this.componentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.componentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.componentDataGridView.DataSource = this.componentBindingSource;
            this.componentDataGridView.Location = new System.Drawing.Point(1, 1);
            this.componentDataGridView.Name = "componentDataGridView";
            this.componentDataGridView.Size = new System.Drawing.Size(218, 133);
            this.componentDataGridView.TabIndex = 1;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(144, 167);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(71, 23);
            this.DeleteBtn.TabIndex = 49;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(72, 167);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(71, 23);
            this.UpdateBtn.TabIndex = 48;
            this.UpdateBtn.Text = "Сохранить";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(1, 167);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(71, 23);
            this.AddBtn.TabIndex = 47;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ComponentName";
            this.dataGridViewTextBoxColumn2.HeaderText = "ComponentName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // componentNameLabel
            // 
            componentNameLabel.AutoSize = true;
            componentNameLabel.Location = new System.Drawing.Point(2, 143);
            componentNameLabel.Name = "componentNameLabel";
            componentNameLabel.Size = new System.Drawing.Size(95, 13);
            componentNameLabel.TabIndex = 49;
            componentNameLabel.Text = "Component Name:";
            // 
            // componentNameTextBox
            // 
            this.componentNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.componentBindingSource, "ComponentName", true));
            this.componentNameTextBox.Location = new System.Drawing.Point(103, 140);
            this.componentNameTextBox.Name = "componentNameTextBox";
            this.componentNameTextBox.Size = new System.Drawing.Size(112, 20);
            this.componentNameTextBox.TabIndex = 50;
            // 
            // CoponentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 210);
            this.Controls.Add(componentNameLabel);
            this.Controls.Add(this.componentNameTextBox);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.componentDataGridView);
            this.Name = "CoponentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CoponentForm";
            this.Load += new System.EventHandler(this.CoponentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DemEx24DataSet demEx24DataSet;
        private System.Windows.Forms.BindingSource componentBindingSource;
        private DemEx24DataSetTableAdapters.ComponentTableAdapter componentTableAdapter;
        private DemEx24DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView componentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox componentNameTextBox;
    }
}