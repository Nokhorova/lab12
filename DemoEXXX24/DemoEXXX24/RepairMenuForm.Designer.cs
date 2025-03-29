namespace DemoEXXX24
{
    partial class RepairMenuForm
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
            System.Windows.Forms.Label priorityLabel;
            System.Windows.Forms.Label dateAddLabel;
            System.Windows.Forms.Label serialNumberLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label repairSpecialistIDLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label statusIDLabel;
            System.Windows.Forms.Label dateFinishedLabel;
            System.Windows.Forms.Label equipmentIDLabel;
            System.Windows.Forms.Label faultTypeIDLabel;
            System.Windows.Forms.Label commentLabel;
            System.Windows.Forms.Label componentIDLabel;
            System.Windows.Forms.Label partsOrderIDLabel;
            System.Windows.Forms.Label quantityLabel;
            this.demEx24DataSet = new DemoEXXX24.DemEx24DataSet();
            this.requestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requestTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.RequestTableAdapter();
            this.tableAdapterManager = new DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager();
            this.statusTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.StatusTableAdapter();
            this.statusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.faultTypeIDComboBox = new System.Windows.Forms.ComboBox();
            this.faultTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateFinishedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.statusIDComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.manufacturerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.equipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repairSpecialistIDComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            this.serialNumberLabel1 = new System.Windows.Forms.Label();
            this.dateAddLabel1 = new System.Windows.Forms.Label();
            this.priorityLabel1 = new System.Windows.Forms.Label();
            this.requestIDLabel1 = new System.Windows.Forms.Label();
            this.requestDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.partsOrderComponentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partsOrderIDComboBox = new System.Windows.Forms.ComboBox();
            this.partsOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.componentIDComboBox = new System.Windows.Forms.ComboBox();
            this.componentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partsOrderComponentDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.equipmentTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.EquipmentTableAdapter();
            this.personTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.PersonTableAdapter();
            this.fKEmployeePersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.EmployeeTableAdapter();
            this.fKRequestStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.faultTypeTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.FaultTypeTableAdapter();
            this.partsOrderTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.PartsOrderTableAdapter();
            this.partsOrderComponentTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.PartsOrderComponentTableAdapter();
            this.componentTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.ComponentTableAdapter();
            this.fKPartsOrderComponentPartsOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.modelTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.ModelTableAdapter();
            this.manufacturerTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.ManufacturerTableAdapter();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            priorityLabel = new System.Windows.Forms.Label();
            dateAddLabel = new System.Windows.Forms.Label();
            serialNumberLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            repairSpecialistIDLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            statusIDLabel = new System.Windows.Forms.Label();
            dateFinishedLabel = new System.Windows.Forms.Label();
            equipmentIDLabel = new System.Windows.Forms.Label();
            faultTypeIDLabel = new System.Windows.Forms.Label();
            commentLabel = new System.Windows.Forms.Label();
            componentIDLabel = new System.Windows.Forms.Label();
            partsOrderIDLabel = new System.Windows.Forms.Label();
            quantityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.faultTypeBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsOrderComponentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsOrderComponentDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fKEmployeePersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKRequestStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKPartsOrderComponentPartsOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // priorityLabel
            // 
            priorityLabel.AutoSize = true;
            priorityLabel.Location = new System.Drawing.Point(49, 37);
            priorityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            priorityLabel.Name = "priorityLabel";
            priorityLabel.Size = new System.Drawing.Size(51, 16);
            priorityLabel.TabIndex = 1;
            priorityLabel.Text = "Priority:";
            // 
            // dateAddLabel
            // 
            dateAddLabel.AutoSize = true;
            dateAddLabel.Location = new System.Drawing.Point(208, 156);
            dateAddLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dateAddLabel.Name = "dateAddLabel";
            dateAddLabel.Size = new System.Drawing.Size(67, 16);
            dateAddLabel.TabIndex = 3;
            dateAddLabel.Text = "Date Add:";
            // 
            // serialNumberLabel
            // 
            serialNumberLabel.AutoSize = true;
            serialNumberLabel.Location = new System.Drawing.Point(-1, 156);
            serialNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            serialNumberLabel.Name = "serialNumberLabel";
            serialNumberLabel.Size = new System.Drawing.Size(96, 16);
            serialNumberLabel.TabIndex = 5;
            serialNumberLabel.Text = "Serial Number:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(24, 194);
            descriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(78, 16);
            descriptionLabel.TabIndex = 7;
            descriptionLabel.Text = "Description:";
            // 
            // repairSpecialistIDLabel
            // 
            repairSpecialistIDLabel.AutoSize = true;
            repairSpecialistIDLabel.Location = new System.Drawing.Point(171, 37);
            repairSpecialistIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            repairSpecialistIDLabel.Name = "repairSpecialistIDLabel";
            repairSpecialistIDLabel.Size = new System.Drawing.Size(75, 16);
            repairSpecialistIDLabel.TabIndex = 9;
            repairSpecialistIDLabel.Text = " Specialist :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(219, 60);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(67, 16);
            label1.TabIndex = 11;
            label1.Text = "Manager :";
            // 
            // statusIDLabel
            // 
            statusIDLabel.AutoSize = true;
            statusIDLabel.Location = new System.Drawing.Point(464, 374);
            statusIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            statusIDLabel.Name = "statusIDLabel";
            statusIDLabel.Size = new System.Drawing.Size(50, 16);
            statusIDLabel.TabIndex = 3;
            statusIDLabel.Text = "Status :";
            // 
            // dateFinishedLabel
            // 
            dateFinishedLabel.AutoSize = true;
            dateFinishedLabel.Location = new System.Drawing.Point(436, 409);
            dateFinishedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            dateFinishedLabel.Name = "dateFinishedLabel";
            dateFinishedLabel.Size = new System.Drawing.Size(93, 16);
            dateFinishedLabel.TabIndex = 4;
            dateFinishedLabel.Text = "Date Finished:";
            // 
            // equipmentIDLabel
            // 
            equipmentIDLabel.AutoSize = true;
            equipmentIDLabel.Location = new System.Drawing.Point(5, 60);
            equipmentIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            equipmentIDLabel.Name = "equipmentIDLabel";
            equipmentIDLabel.Size = new System.Drawing.Size(77, 16);
            equipmentIDLabel.TabIndex = 13;
            equipmentIDLabel.Text = "Equipment :";
            // 
            // faultTypeIDLabel
            // 
            faultTypeIDLabel.AutoSize = true;
            faultTypeIDLabel.Location = new System.Drawing.Point(437, 439);
            faultTypeIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            faultTypeIDLabel.Name = "faultTypeIDLabel";
            faultTypeIDLabel.Size = new System.Drawing.Size(77, 16);
            faultTypeIDLabel.TabIndex = 6;
            faultTypeIDLabel.Text = "Fault Type :";
            // 
            // commentLabel
            // 
            commentLabel.AutoSize = true;
            commentLabel.Location = new System.Drawing.Point(467, 497);
            commentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            commentLabel.Name = "commentLabel";
            commentLabel.Size = new System.Drawing.Size(67, 16);
            commentLabel.TabIndex = 8;
            commentLabel.Text = "Comment:";
            // 
            // componentIDLabel
            // 
            componentIDLabel.AutoSize = true;
            componentIDLabel.Location = new System.Drawing.Point(24, 314);
            componentIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            componentIDLabel.Name = "componentIDLabel";
            componentIDLabel.Size = new System.Drawing.Size(82, 16);
            componentIDLabel.TabIndex = 1;
            componentIDLabel.Text = "Component :";
            // 
            // partsOrderIDLabel
            // 
            partsOrderIDLabel.AutoSize = true;
            partsOrderIDLabel.Location = new System.Drawing.Point(11, 369);
            partsOrderIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            partsOrderIDLabel.Name = "partsOrderIDLabel";
            partsOrderIDLabel.Size = new System.Drawing.Size(94, 16);
            partsOrderIDLabel.TabIndex = 3;
            partsOrderIDLabel.Text = "Parts Order ID:";
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new System.Drawing.Point(51, 409);
            quantityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new System.Drawing.Size(58, 16);
            quantityLabel.TabIndex = 5;
            quantityLabel.Text = "Quantity:";
            // 
            // demEx24DataSet
            // 
            this.demEx24DataSet.DataSetName = "DemEx24DataSet1";
            this.demEx24DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // requestBindingSource
            // 
            this.requestBindingSource.DataMember = "Request";
            this.requestBindingSource.DataSource = this.demEx24DataSet;
            // 
            // requestTableAdapter
            // 
            this.requestTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.PartsOrderTableAdapter = null;
            this.tableAdapterManager.PersonTableAdapter = null;
            this.tableAdapterManager.RequestTableAdapter = this.requestTableAdapter;
            this.tableAdapterManager.StatusTableAdapter = this.statusTableAdapter;
            this.tableAdapterManager.UpdateOrder = DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // statusTableAdapter
            // 
            this.statusTableAdapter.ClearBeforeFill = true;
            // 
            // statusBindingSource
            // 
            this.statusBindingSource.DataMember = "Status";
            this.statusBindingSource.DataSource = this.demEx24DataSet;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 681);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.UpdateBtn);
            this.tabPage1.Controls.Add(commentLabel);
            this.tabPage1.Controls.Add(this.commentTextBox);
            this.tabPage1.Controls.Add(faultTypeIDLabel);
            this.tabPage1.Controls.Add(this.faultTypeIDComboBox);
            this.tabPage1.Controls.Add(dateFinishedLabel);
            this.tabPage1.Controls.Add(this.dateFinishedDateTimePicker);
            this.tabPage1.Controls.Add(statusIDLabel);
            this.tabPage1.Controls.Add(this.statusIDComboBox);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.requestDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(778, 652);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ремонт";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(543, 335);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "+Заказ компонентов";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(528, 464);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "+ Добавить тип неисправности";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.AutoSize = true;
            this.UpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateBtn.Location = new System.Drawing.Point(547, 590);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(4);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(195, 43);
            this.UpdateBtn.TabIndex = 35;
            this.UpdateBtn.Text = "Сохранить";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateRequestRemontBtn_Click);
            // 
            // commentTextBox
            // 
            this.commentTextBox.CausesValidation = false;
            this.commentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "Comment", true));
            this.commentTextBox.Location = new System.Drawing.Point(547, 494);
            this.commentTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.commentTextBox.Multiline = true;
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(194, 82);
            this.commentTextBox.TabIndex = 9;
            // 
            // faultTypeIDComboBox
            // 
            this.faultTypeIDComboBox.CausesValidation = false;
            this.faultTypeIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "FaultTypeID", true));
            this.faultTypeIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.requestBindingSource, "FaultTypeID", true));
            this.faultTypeIDComboBox.DataSource = this.faultTypeBindingSource;
            this.faultTypeIDComboBox.DisplayMember = "FaultTypeName";
            this.faultTypeIDComboBox.DropDownHeight = 160;
            this.faultTypeIDComboBox.FormattingEnabled = true;
            this.faultTypeIDComboBox.IntegralHeight = false;
            this.faultTypeIDComboBox.Location = new System.Drawing.Point(544, 436);
            this.faultTypeIDComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.faultTypeIDComboBox.Name = "faultTypeIDComboBox";
            this.faultTypeIDComboBox.Size = new System.Drawing.Size(194, 24);
            this.faultTypeIDComboBox.TabIndex = 7;
            this.faultTypeIDComboBox.ValueMember = "FaultTypeID";
            // 
            // faultTypeBindingSource
            // 
            this.faultTypeBindingSource.DataMember = "FaultType";
            this.faultTypeBindingSource.DataSource = this.demEx24DataSet;
            // 
            // dateFinishedDateTimePicker
            // 
            this.dateFinishedDateTimePicker.CausesValidation = false;
            this.dateFinishedDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.requestBindingSource, "DateFinished", true));
            this.dateFinishedDateTimePicker.Location = new System.Drawing.Point(544, 404);
            this.dateFinishedDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dateFinishedDateTimePicker.Name = "dateFinishedDateTimePicker";
            this.dateFinishedDateTimePicker.Size = new System.Drawing.Size(194, 22);
            this.dateFinishedDateTimePicker.TabIndex = 5;
            // 
            // statusIDComboBox
            // 
            this.statusIDComboBox.CausesValidation = false;
            this.statusIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "StatusID", true));
            this.statusIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.requestBindingSource, "StatusID", true));
            this.statusIDComboBox.DataSource = this.statusBindingSource;
            this.statusIDComboBox.DisplayMember = "StatusName";
            this.statusIDComboBox.FormattingEnabled = true;
            this.statusIDComboBox.Location = new System.Drawing.Point(544, 370);
            this.statusIDComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.statusIDComboBox.Name = "statusIDComboBox";
            this.statusIDComboBox.Size = new System.Drawing.Size(194, 24);
            this.statusIDComboBox.TabIndex = 4;
            this.statusIDComboBox.ValueMember = "StatusID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(equipmentIDLabel);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(repairSpecialistIDLabel);
            this.groupBox1.Controls.Add(this.repairSpecialistIDComboBox);
            this.groupBox1.Controls.Add(descriptionLabel);
            this.groupBox1.Controls.Add(this.descriptionLabel1);
            this.groupBox1.Controls.Add(serialNumberLabel);
            this.groupBox1.Controls.Add(this.serialNumberLabel1);
            this.groupBox1.Controls.Add(dateAddLabel);
            this.groupBox1.Controls.Add(this.dateAddLabel1);
            this.groupBox1.Controls.Add(priorityLabel);
            this.groupBox1.Controls.Add(this.priorityLabel1);
            this.groupBox1.Controls.Add(this.requestIDLabel1);
            this.groupBox1.Location = new System.Drawing.Point(11, 335);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(425, 286);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация по заявке : ";
            // 
            // comboBox4
            // 
            this.comboBox4.AccessibleDescription = "Нельзя переназначить специалиста";
            this.comboBox4.CausesValidation = false;
            this.comboBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "RepairSpecialistID", true));
            this.comboBox4.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.modelBindingSource, "ManufacturerID", true));
            this.comboBox4.DataSource = this.manufacturerBindingSource;
            this.comboBox4.DisplayMember = "ManufacturerName";
            this.comboBox4.DropDownHeight = 1;
            this.comboBox4.DropDownWidth = 1;
            this.comboBox4.Enabled = false;
            this.comboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.IntegralHeight = false;
            this.comboBox4.Location = new System.Drawing.Point(112, 121);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(97, 24);
            this.comboBox4.TabIndex = 16;
            this.comboBox4.ValueMember = "ManufacturerID";
            // 
            // modelBindingSource
            // 
            this.modelBindingSource.DataMember = "Model";
            this.modelBindingSource.DataSource = this.demEx24DataSet;
            // 
            // manufacturerBindingSource
            // 
            this.manufacturerBindingSource.DataMember = "Manufacturer";
            this.manufacturerBindingSource.DataSource = this.demEx24DataSet;
            // 
            // comboBox3
            // 
            this.comboBox3.AccessibleDescription = "Нельзя переназначить специалиста";
            this.comboBox3.CausesValidation = false;
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "RepairSpecialistID", true));
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.equipmentBindingSource, "ModelID", true));
            this.comboBox3.DataSource = this.modelBindingSource;
            this.comboBox3.DisplayMember = "ModelName";
            this.comboBox3.DropDownHeight = 1;
            this.comboBox3.DropDownWidth = 1;
            this.comboBox3.Enabled = false;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.IntegralHeight = false;
            this.comboBox3.Location = new System.Drawing.Point(112, 90);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(97, 24);
            this.comboBox3.TabIndex = 15;
            this.comboBox3.ValueMember = "ModelID";
            // 
            // equipmentBindingSource
            // 
            this.equipmentBindingSource.DataMember = "Equipment";
            this.equipmentBindingSource.DataSource = this.demEx24DataSet;
            // 
            // comboBox2
            // 
            this.comboBox2.AccessibleDescription = "Нельзя переназначить специалиста";
            this.comboBox2.CausesValidation = false;
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "RepairSpecialistID", true));
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.requestBindingSource, "EquipmentID", true));
            this.comboBox2.DataSource = this.equipmentBindingSource;
            this.comboBox2.DisplayMember = "EquipmentName";
            this.comboBox2.DropDownHeight = 1;
            this.comboBox2.DropDownWidth = 1;
            this.comboBox2.Enabled = false;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.IntegralHeight = false;
            this.comboBox2.Location = new System.Drawing.Point(112, 57);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(97, 24);
            this.comboBox2.TabIndex = 14;
            this.comboBox2.ValueMember = "EquipmentID";
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleDescription = "Нельзя переназначить специалиста";
            this.comboBox1.CausesValidation = false;
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "RepairSpecialistID", true));
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.requestBindingSource, "ManagerID", true));
            this.comboBox1.DataSource = this.personBindingSource;
            this.comboBox1.DisplayMember = "LastName";
            this.comboBox1.DropDownHeight = 1;
            this.comboBox1.DropDownWidth = 1;
            this.comboBox1.Enabled = false;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(300, 57);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(112, 24);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.ValueMember = "PersonID";
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataMember = "Person";
            this.personBindingSource.DataSource = this.demEx24DataSet;
            // 
            // repairSpecialistIDComboBox
            // 
            this.repairSpecialistIDComboBox.AccessibleDescription = "Нельзя переназначить специалиста";
            this.repairSpecialistIDComboBox.CausesValidation = false;
            this.repairSpecialistIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "RepairSpecialistID", true));
            this.repairSpecialistIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.requestBindingSource, "RepairSpecialistID", true));
            this.repairSpecialistIDComboBox.DataSource = this.personBindingSource;
            this.repairSpecialistIDComboBox.DisplayMember = "LastName";
            this.repairSpecialistIDComboBox.DropDownHeight = 1;
            this.repairSpecialistIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repairSpecialistIDComboBox.DropDownWidth = 1;
            this.repairSpecialistIDComboBox.Enabled = false;
            this.repairSpecialistIDComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.repairSpecialistIDComboBox.FormattingEnabled = true;
            this.repairSpecialistIDComboBox.IntegralHeight = false;
            this.repairSpecialistIDComboBox.Location = new System.Drawing.Point(252, 28);
            this.repairSpecialistIDComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.repairSpecialistIDComboBox.Name = "repairSpecialistIDComboBox";
            this.repairSpecialistIDComboBox.Size = new System.Drawing.Size(160, 24);
            this.repairSpecialistIDComboBox.TabIndex = 10;
            this.repairSpecialistIDComboBox.ValueMember = "PersonID";
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.descriptionLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.descriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "Description", true));
            this.descriptionLabel1.Location = new System.Drawing.Point(120, 194);
            this.descriptionLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(297, 87);
            this.descriptionLabel1.TabIndex = 8;
            this.descriptionLabel1.Text = "label1";
            // 
            // serialNumberLabel1
            // 
            this.serialNumberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "SerialNumber", true));
            this.serialNumberLabel1.Location = new System.Drawing.Point(108, 156);
            this.serialNumberLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serialNumberLabel1.Name = "serialNumberLabel1";
            this.serialNumberLabel1.Size = new System.Drawing.Size(51, 28);
            this.serialNumberLabel1.TabIndex = 6;
            this.serialNumberLabel1.Text = "label1";
            // 
            // dateAddLabel1
            // 
            this.dateAddLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "DateAdd", true));
            this.dateAddLabel1.Location = new System.Drawing.Point(289, 156);
            this.dateAddLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateAddLabel1.Name = "dateAddLabel1";
            this.dateAddLabel1.Size = new System.Drawing.Size(124, 22);
            this.dateAddLabel1.TabIndex = 4;
            this.dateAddLabel1.Text = "label1";
            // 
            // priorityLabel1
            // 
            this.priorityLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "Priority", true));
            this.priorityLabel1.Location = new System.Drawing.Point(112, 37);
            this.priorityLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.priorityLabel1.Name = "priorityLabel1";
            this.priorityLabel1.Size = new System.Drawing.Size(79, 28);
            this.priorityLabel1.TabIndex = 2;
            this.priorityLabel1.Text = "label1";
            // 
            // requestIDLabel1
            // 
            this.requestIDLabel1.BackColor = System.Drawing.Color.White;
            this.requestIDLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestBindingSource, "RequestID", true));
            this.requestIDLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.requestIDLabel1.Location = new System.Drawing.Point(191, 0);
            this.requestIDLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.requestIDLabel1.Name = "requestIDLabel1";
            this.requestIDLabel1.Size = new System.Drawing.Size(89, 25);
            this.requestIDLabel1.TabIndex = 1;
            this.requestIDLabel1.Text = "label1";
            this.requestIDLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // requestDataGridView
            // 
            this.requestDataGridView.AutoGenerateColumns = false;
            this.requestDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn13});
            this.requestDataGridView.DataSource = this.requestBindingSource;
            this.requestDataGridView.Location = new System.Drawing.Point(9, 18);
            this.requestDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.requestDataGridView.Name = "requestDataGridView";
            this.requestDataGridView.RowHeadersWidth = 51;
            this.requestDataGridView.Size = new System.Drawing.Size(729, 309);
            this.requestDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RequestID";
            this.dataGridViewTextBoxColumn1.HeaderText = "RequestID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn2.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "StatusID";
            this.dataGridViewTextBoxColumn3.DataSource = this.statusBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "StatusName";
            this.dataGridViewTextBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn3.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "StatusID";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "StatusID";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DateAdd";
            this.dataGridViewTextBoxColumn4.HeaderText = "DateAdd";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DateFinished";
            this.dataGridViewTextBoxColumn5.HeaderText = "DateFinished";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "RepairSpecialistID";
            this.dataGridViewTextBoxColumn13.DataSource = this.personBindingSource;
            this.dataGridViewTextBoxColumn13.DisplayMember = "LastName";
            this.dataGridViewTextBoxColumn13.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn13.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewTextBoxColumn13.HeaderText = "RepairSpecialistID";
            this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn13.ValueMember = "PersonID";
            this.dataGridViewTextBoxColumn13.Width = 125;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.DeleteBtn);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.AddBtn);
            this.tabPage2.Controls.Add(quantityLabel);
            this.tabPage2.Controls.Add(this.quantityNumericUpDown);
            this.tabPage2.Controls.Add(partsOrderIDLabel);
            this.tabPage2.Controls.Add(this.partsOrderIDComboBox);
            this.tabPage2.Controls.Add(componentIDLabel);
            this.tabPage2.Controls.Add(this.componentIDComboBox);
            this.tabPage2.Controls.Add(this.partsOrderComponentDataGridView);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(778, 652);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Компоненты";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(348, 340);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "+ Добавить компонент";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.AutoSize = true;
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteBtn.Location = new System.Drawing.Point(524, 412);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(200, 43);
            this.DeleteBtn.TabIndex = 41;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteZakazComponentBtn_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(524, 361);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 43);
            this.button2.TabIndex = 40;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.UpdateZakazComponentBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.AutoSize = true;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.Location = new System.Drawing.Point(524, 310);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(200, 43);
            this.AddBtn.TabIndex = 39;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddZakazComponentBtn_Click);
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.CausesValidation = false;
            this.quantityNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.partsOrderComponentBindingSource, "Quantity", true));
            this.quantityNumericUpDown.Location = new System.Drawing.Point(124, 409);
            this.quantityNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(392, 22);
            this.quantityNumericUpDown.TabIndex = 6;
            // 
            // partsOrderComponentBindingSource
            // 
            this.partsOrderComponentBindingSource.DataMember = "PartsOrderComponent";
            this.partsOrderComponentBindingSource.DataSource = this.demEx24DataSet;
            // 
            // partsOrderIDComboBox
            // 
            this.partsOrderIDComboBox.CausesValidation = false;
            this.partsOrderIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partsOrderComponentBindingSource, "PartsOrderID", true));
            this.partsOrderIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.partsOrderComponentBindingSource, "PartsOrderID", true));
            this.partsOrderIDComboBox.DataSource = this.partsOrderBindingSource;
            this.partsOrderIDComboBox.DisplayMember = "PartsOrderID";
            this.partsOrderIDComboBox.FormattingEnabled = true;
            this.partsOrderIDComboBox.Location = new System.Drawing.Point(121, 366);
            this.partsOrderIDComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.partsOrderIDComboBox.Name = "partsOrderIDComboBox";
            this.partsOrderIDComboBox.Size = new System.Drawing.Size(392, 24);
            this.partsOrderIDComboBox.TabIndex = 4;
            this.partsOrderIDComboBox.ValueMember = "PartsOrderID";
            // 
            // partsOrderBindingSource
            // 
            this.partsOrderBindingSource.DataMember = "PartsOrder";
            this.partsOrderBindingSource.DataSource = this.demEx24DataSet;
            // 
            // componentIDComboBox
            // 
            this.componentIDComboBox.CausesValidation = false;
            this.componentIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partsOrderComponentBindingSource, "ComponentID", true));
            this.componentIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.partsOrderComponentBindingSource, "ComponentID", true));
            this.componentIDComboBox.DataSource = this.componentBindingSource;
            this.componentIDComboBox.DisplayMember = "ComponentName";
            this.componentIDComboBox.FormattingEnabled = true;
            this.componentIDComboBox.Location = new System.Drawing.Point(121, 310);
            this.componentIDComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.componentIDComboBox.Name = "componentIDComboBox";
            this.componentIDComboBox.Size = new System.Drawing.Size(391, 24);
            this.componentIDComboBox.TabIndex = 2;
            this.componentIDComboBox.ValueMember = "ComponentID";
            // 
            // componentBindingSource
            // 
            this.componentBindingSource.DataMember = "Component";
            this.componentBindingSource.DataSource = this.demEx24DataSet;
            // 
            // partsOrderComponentDataGridView
            // 
            this.partsOrderComponentDataGridView.AutoGenerateColumns = false;
            this.partsOrderComponentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsOrderComponentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.partsOrderComponentDataGridView.DataSource = this.partsOrderComponentBindingSource;
            this.partsOrderComponentDataGridView.Location = new System.Drawing.Point(9, 4);
            this.partsOrderComponentDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.partsOrderComponentDataGridView.Name = "partsOrderComponentDataGridView";
            this.partsOrderComponentDataGridView.RowHeadersWidth = 51;
            this.partsOrderComponentDataGridView.Size = new System.Drawing.Size(715, 303);
            this.partsOrderComponentDataGridView.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(9, 439);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(507, 188);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация по заявке запчастей : ";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.CausesValidation = false;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partsOrderBindingSource, "Comment", true));
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(491, 165);
            this.label2.TabIndex = 42;
            // 
            // equipmentTableAdapter
            // 
            this.equipmentTableAdapter.ClearBeforeFill = true;
            // 
            // personTableAdapter
            // 
            this.personTableAdapter.ClearBeforeFill = true;
            // 
            // fKEmployeePersonBindingSource
            // 
            this.fKEmployeePersonBindingSource.DataMember = "FK_Employee_Person";
            this.fKEmployeePersonBindingSource.DataSource = this.personBindingSource;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // fKRequestStatusBindingSource
            // 
            this.fKRequestStatusBindingSource.DataMember = "FK_Request_Status";
            this.fKRequestStatusBindingSource.DataSource = this.statusBindingSource;
            // 
            // faultTypeTableAdapter
            // 
            this.faultTypeTableAdapter.ClearBeforeFill = true;
            // 
            // partsOrderTableAdapter
            // 
            this.partsOrderTableAdapter.ClearBeforeFill = true;
            // 
            // partsOrderComponentTableAdapter
            // 
            this.partsOrderComponentTableAdapter.ClearBeforeFill = true;
            // 
            // componentTableAdapter
            // 
            this.componentTableAdapter.ClearBeforeFill = true;
            // 
            // fKPartsOrderComponentPartsOrderBindingSource
            // 
            this.fKPartsOrderComponentPartsOrderBindingSource.DataMember = "FK_PartsOrderComponent_PartsOrder";
            this.fKPartsOrderComponentPartsOrderBindingSource.DataSource = this.partsOrderBindingSource;
            // 
            // equipmentBindingSource1
            // 
            this.equipmentBindingSource1.DataMember = "Equipment";
            this.equipmentBindingSource1.DataSource = this.demEx24DataSet;
            // 
            // modelTableAdapter
            // 
            this.modelTableAdapter.ClearBeforeFill = true;
            // 
            // manufacturerTableAdapter
            // 
            this.manufacturerTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PartsOrderComponentID";
            this.dataGridViewTextBoxColumn6.HeaderText = "PartsOrderComponentID";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 130;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ComponentID";
            this.dataGridViewTextBoxColumn7.DataSource = this.componentBindingSource;
            this.dataGridViewTextBoxColumn7.DisplayMember = "ComponentName";
            this.dataGridViewTextBoxColumn7.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewTextBoxColumn7.HeaderText = "ComponentID";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn7.ValueMember = "ComponentID";
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PartsOrderID";
            this.dataGridViewTextBoxColumn8.HeaderText = "PartsOrderID";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn9.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // RepairMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 687);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RepairMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RepairMenuForm";
            this.Load += new System.EventHandler(this.RepairMenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.faultTypeBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsOrderComponentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsOrderComponentDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fKEmployeePersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKRequestStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKPartsOrderComponentPartsOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DemEx24DataSet demEx24DataSet;
        private System.Windows.Forms.BindingSource requestBindingSource;
        private DemEx24DataSetTableAdapters.RequestTableAdapter requestTableAdapter;
        private DemEx24DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DemEx24DataSetTableAdapters.StatusTableAdapter statusTableAdapter;
        private System.Windows.Forms.BindingSource statusBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView requestDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label requestIDLabel1;
        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.Label serialNumberLabel1;
        private System.Windows.Forms.Label dateAddLabel1;
        private System.Windows.Forms.Label priorityLabel1;
        private System.Windows.Forms.BindingSource equipmentBindingSource;
        private DemEx24DataSetTableAdapters.EquipmentTableAdapter equipmentTableAdapter;
        private System.Windows.Forms.BindingSource personBindingSource;
        private DemEx24DataSetTableAdapters.PersonTableAdapter personTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.ComboBox repairSpecialistIDComboBox;
        private System.Windows.Forms.BindingSource fKEmployeePersonBindingSource;
        private DemEx24DataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateFinishedDateTimePicker;
        private System.Windows.Forms.ComboBox statusIDComboBox;
        private System.Windows.Forms.ComboBox faultTypeIDComboBox;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.BindingSource fKRequestStatusBindingSource;
        private System.Windows.Forms.BindingSource faultTypeBindingSource;
        private DemEx24DataSetTableAdapters.FaultTypeTableAdapter faultTypeTableAdapter;
        private System.Windows.Forms.BindingSource partsOrderBindingSource;
        private DemEx24DataSetTableAdapters.PartsOrderTableAdapter partsOrderTableAdapter;
        private System.Windows.Forms.BindingSource partsOrderComponentBindingSource;
        private DemEx24DataSetTableAdapters.PartsOrderComponentTableAdapter partsOrderComponentTableAdapter;
        private System.Windows.Forms.ComboBox partsOrderIDComboBox;
        private System.Windows.Forms.ComboBox componentIDComboBox;
        private System.Windows.Forms.DataGridView partsOrderComponentDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown;
        private System.Windows.Forms.BindingSource componentBindingSource;
        private DemEx24DataSetTableAdapters.ComponentTableAdapter componentTableAdapter;
        private System.Windows.Forms.BindingSource fKPartsOrderComponentPartsOrderBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource equipmentBindingSource1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.BindingSource modelBindingSource;
        private DemEx24DataSetTableAdapters.ModelTableAdapter modelTableAdapter;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.BindingSource manufacturerBindingSource;
        private DemEx24DataSetTableAdapters.ManufacturerTableAdapter manufacturerTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}