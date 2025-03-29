namespace DemoEXXX24
{
    partial class RequestPartsOrderForm
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
            System.Windows.Forms.Label orderDateLabel;
            System.Windows.Forms.Label requestIDLabel;
            System.Windows.Forms.Label repairSpecialistIDLabel;
            System.Windows.Forms.Label commentLabel;
            this.demEx24DataSet = new DemoEXXX24.DemEx24DataSet();
            this.partsOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partsOrderTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.PartsOrderTableAdapter();
            this.tableAdapterManager = new DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager();
            this.personTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.PersonTableAdapter();
            this.requestTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.RequestTableAdapter();
            this.partsOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.requestIDComboBox = new System.Windows.Forms.ComboBox();
            this.requestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repairSpecialistIDComboBox = new System.Windows.Forms.ComboBox();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.requestBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            orderDateLabel = new System.Windows.Forms.Label();
            requestIDLabel = new System.Windows.Forms.Label();
            repairSpecialistIDLabel = new System.Windows.Forms.Label();
            commentLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsOrderDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // orderDateLabel
            // 
            orderDateLabel.AutoSize = true;
            orderDateLabel.Location = new System.Drawing.Point(79, 314);
            orderDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            orderDateLabel.Name = "orderDateLabel";
            orderDateLabel.Size = new System.Drawing.Size(76, 16);
            orderDateLabel.TabIndex = 1;
            orderDateLabel.Text = "Order Date:";
            // 
            // requestIDLabel
            // 
            requestIDLabel.AutoSize = true;
            requestIDLabel.Location = new System.Drawing.Point(76, 345);
            requestIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            requestIDLabel.Name = "requestIDLabel";
            requestIDLabel.Size = new System.Drawing.Size(77, 16);
            requestIDLabel.TabIndex = 3;
            requestIDLabel.Text = "Request ID:";
            // 
            // repairSpecialistIDLabel
            // 
            repairSpecialistIDLabel.AutoSize = true;
            repairSpecialistIDLabel.Location = new System.Drawing.Point(24, 378);
            repairSpecialistIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            repairSpecialistIDLabel.Name = "repairSpecialistIDLabel";
            repairSpecialistIDLabel.Size = new System.Drawing.Size(129, 16);
            repairSpecialistIDLabel.TabIndex = 5;
            repairSpecialistIDLabel.Text = "Repair Specialist ID:";
            // 
            // commentLabel
            // 
            commentLabel.AutoSize = true;
            commentLabel.Location = new System.Drawing.Point(89, 411);
            commentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            commentLabel.Name = "commentLabel";
            commentLabel.Size = new System.Drawing.Size(67, 16);
            commentLabel.TabIndex = 7;
            commentLabel.Text = "Comment:";
            // 
            // demEx24DataSet
            // 
            this.demEx24DataSet.DataSetName = "DemEx24DataSet1";
            this.demEx24DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // partsOrderBindingSource
            // 
            this.partsOrderBindingSource.DataMember = "PartsOrder";
            this.partsOrderBindingSource.DataSource = this.demEx24DataSet;
            // 
            // partsOrderTableAdapter
            // 
            this.partsOrderTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ComponentTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.EquipmentComponentTableAdapter = null;
            this.tableAdapterManager.EquipmentTableAdapter = null;
            this.tableAdapterManager.FaultTypeTableAdapter = null;
            this.tableAdapterManager.ManufacturerTableAdapter = null;
            this.tableAdapterManager.ModelTableAdapter = null;
            this.tableAdapterManager.PartsOrderComponentTableAdapter = null;
            this.tableAdapterManager.PartsOrderTableAdapter = this.partsOrderTableAdapter;
            this.tableAdapterManager.PersonTableAdapter = this.personTableAdapter;
            this.tableAdapterManager.RequestTableAdapter = this.requestTableAdapter;
            this.tableAdapterManager.StatusTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // personTableAdapter
            // 
            this.personTableAdapter.ClearBeforeFill = true;
            // 
            // requestTableAdapter
            // 
            this.requestTableAdapter.ClearBeforeFill = true;
            // 
            // partsOrderDataGridView
            // 
            this.partsOrderDataGridView.AutoGenerateColumns = false;
            this.partsOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsOrderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.partsOrderDataGridView.DataSource = this.partsOrderBindingSource;
            this.partsOrderDataGridView.Location = new System.Drawing.Point(3, 2);
            this.partsOrderDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.partsOrderDataGridView.Name = "partsOrderDataGridView";
            this.partsOrderDataGridView.RowHeadersWidth = 51;
            this.partsOrderDataGridView.Size = new System.Drawing.Size(723, 294);
            this.partsOrderDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PartsOrderID";
            this.dataGridViewTextBoxColumn1.HeaderText = "PartsOrderID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OrderDate";
            this.dataGridViewTextBoxColumn2.HeaderText = "OrderDate";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RequestID";
            this.dataGridViewTextBoxColumn3.HeaderText = "RequestID";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RepairSpecialistID";
            this.dataGridViewTextBoxColumn4.HeaderText = "RepairSpecialistID";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn5.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // orderDateDateTimePicker
            // 
            this.orderDateDateTimePicker.CausesValidation = false;
            this.orderDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.partsOrderBindingSource, "OrderDate", true));
            this.orderDateDateTimePicker.Location = new System.Drawing.Point(169, 309);
            this.orderDateDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.orderDateDateTimePicker.MinDate = new System.DateTime(2024, 12, 10, 0, 0, 0, 0);
            this.orderDateDateTimePicker.Name = "orderDateDateTimePicker";
            this.orderDateDateTimePicker.Size = new System.Drawing.Size(265, 22);
            this.orderDateDateTimePicker.TabIndex = 2;
            this.orderDateDateTimePicker.Value = new System.DateTime(2024, 12, 10, 3, 46, 40, 0);
            // 
            // requestIDComboBox
            // 
            this.requestIDComboBox.CausesValidation = false;
            this.requestIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partsOrderBindingSource, "RequestID", true));
            this.requestIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.partsOrderBindingSource, "RequestID", true));
            this.requestIDComboBox.DataSource = this.requestBindingSource;
            this.requestIDComboBox.DisplayMember = "RequestID";
            this.requestIDComboBox.FormattingEnabled = true;
            this.requestIDComboBox.Location = new System.Drawing.Point(169, 341);
            this.requestIDComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.requestIDComboBox.Name = "requestIDComboBox";
            this.requestIDComboBox.Size = new System.Drawing.Size(160, 24);
            this.requestIDComboBox.TabIndex = 4;
            this.requestIDComboBox.ValueMember = "RequestID";
            // 
            // requestBindingSource
            // 
            this.requestBindingSource.DataMember = "Request";
            this.requestBindingSource.DataSource = this.demEx24DataSet;
            // 
            // repairSpecialistIDComboBox
            // 
            this.repairSpecialistIDComboBox.CausesValidation = false;
            this.repairSpecialistIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partsOrderBindingSource, "RepairSpecialistID", true));
            this.repairSpecialistIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.partsOrderBindingSource, "RepairSpecialistID", true));
            this.repairSpecialistIDComboBox.DataSource = this.personBindingSource;
            this.repairSpecialistIDComboBox.DisplayMember = "LastName";
            this.repairSpecialistIDComboBox.FormattingEnabled = true;
            this.repairSpecialistIDComboBox.Location = new System.Drawing.Point(169, 374);
            this.repairSpecialistIDComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.repairSpecialistIDComboBox.Name = "repairSpecialistIDComboBox";
            this.repairSpecialistIDComboBox.Size = new System.Drawing.Size(160, 24);
            this.repairSpecialistIDComboBox.TabIndex = 6;
            this.repairSpecialistIDComboBox.ValueMember = "PersonID";
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataMember = "Person";
            this.personBindingSource.DataSource = this.demEx24DataSet;
            // 
            // commentTextBox
            // 
            this.commentTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.commentTextBox.CausesValidation = false;
            this.commentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partsOrderBindingSource, "Comment", true));
            this.commentTextBox.Location = new System.Drawing.Point(169, 407);
            this.commentTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.commentTextBox.Multiline = true;
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(329, 131);
            this.commentTextBox.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partsOrderBindingSource, "RepairSpecialistID", true));
            this.comboBox1.DataSource = this.personBindingSource;
            this.comboBox1.DisplayMember = "FierstName";
            this.comboBox1.DropDownHeight = 1;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownWidth = 1;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.ItemHeight = 16;
            this.comboBox1.Location = new System.Drawing.Point(339, 374);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.MaxDropDownItems = 1;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.ValueMember = "PersonID";
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.AutoSize = true;
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteBtn.Location = new System.Drawing.Point(520, 502);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(200, 37);
            this.DeleteBtn.TabIndex = 38;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.AutoSize = true;
            this.UpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateBtn.Location = new System.Drawing.Point(520, 458);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(200, 37);
            this.UpdateBtn.TabIndex = 37;
            this.UpdateBtn.Text = "Сохранить";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.AutoSize = true;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.Location = new System.Drawing.Point(520, 414);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(200, 37);
            this.AddBtn.TabIndex = 36;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // requestBindingSource1
            // 
            this.requestBindingSource1.DataMember = "Request";
            this.requestBindingSource1.DataSource = this.demEx24DataSet;
            // 
            // RequestPartsOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 582);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(commentLabel);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(repairSpecialistIDLabel);
            this.Controls.Add(this.repairSpecialistIDComboBox);
            this.Controls.Add(requestIDLabel);
            this.Controls.Add(this.requestIDComboBox);
            this.Controls.Add(orderDateLabel);
            this.Controls.Add(this.orderDateDateTimePicker);
            this.Controls.Add(this.partsOrderDataGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RequestPartsOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RequestPartsOrderForm";
            this.Load += new System.EventHandler(this.RequestPartsOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsOrderDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DemEx24DataSet demEx24DataSet;
        private System.Windows.Forms.BindingSource partsOrderBindingSource;
        private DemEx24DataSetTableAdapters.PartsOrderTableAdapter partsOrderTableAdapter;
        private DemEx24DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView partsOrderDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DateTimePicker orderDateDateTimePicker;
        private DemEx24DataSetTableAdapters.RequestTableAdapter requestTableAdapter;
        private System.Windows.Forms.ComboBox requestIDComboBox;
        private System.Windows.Forms.ComboBox repairSpecialistIDComboBox;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.BindingSource requestBindingSource;
        private DemEx24DataSetTableAdapters.PersonTableAdapter personTableAdapter;
        private System.Windows.Forms.BindingSource personBindingSource;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.BindingSource requestBindingSource1;
    }
}