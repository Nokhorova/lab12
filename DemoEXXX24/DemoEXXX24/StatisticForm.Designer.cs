namespace DemoEXXX24
{
    partial class StatisticForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticForm));
            this.demEx24DataSet = new DemoEXXX24.DemEx24DataSet();
            this.statisticAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statisticAllTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.StatisticAllTableAdapter();
            this.tableAdapterManager = new DemoEXXX24.DemEx24DataSetTableAdapters.TableAdapterManager();
            this.statisticAllBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.statisticAllBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.statisticAllDataGridView = new System.Windows.Forms.DataGridView();
            this.demEx24DataSet1 = new DemoEXXX24.DemEx24DataSet();
            this.faultTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.faultTypeTableAdapter = new DemoEXXX24.DemEx24DataSetTableAdapters.FaultTypeTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticAllBindingNavigator)).BeginInit();
            this.statisticAllBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statisticAllDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faultTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // demEx24DataSet
            // 
            this.demEx24DataSet.DataSetName = "DemEx24DataSet";
            this.demEx24DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // statisticAllBindingSource
            // 
            this.statisticAllBindingSource.DataMember = "StatisticAll";
            this.statisticAllBindingSource.DataSource = this.demEx24DataSet;
            // 
            // statisticAllTableAdapter
            // 
            this.statisticAllTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ComponentTableAdapter = null;
            this.tableAdapterManager.Connection = null;
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
            // statisticAllBindingNavigator
            // 
            this.statisticAllBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.statisticAllBindingNavigator.BindingSource = this.statisticAllBindingSource;
            this.statisticAllBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.statisticAllBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.statisticAllBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statisticAllBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.statisticAllBindingNavigatorSaveItem});
            this.statisticAllBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.statisticAllBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.statisticAllBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.statisticAllBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.statisticAllBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.statisticAllBindingNavigator.Name = "statisticAllBindingNavigator";
            this.statisticAllBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.statisticAllBindingNavigator.Size = new System.Drawing.Size(627, 27);
            this.statisticAllBindingNavigator.TabIndex = 1;
            this.statisticAllBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 24);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // statisticAllBindingNavigatorSaveItem
            // 
            this.statisticAllBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.statisticAllBindingNavigatorSaveItem.Enabled = false;
            this.statisticAllBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("statisticAllBindingNavigatorSaveItem.Image")));
            this.statisticAllBindingNavigatorSaveItem.Name = "statisticAllBindingNavigatorSaveItem";
            this.statisticAllBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.statisticAllBindingNavigatorSaveItem.Text = "Сохранить данные";
            // 
            // statisticAllDataGridView
            // 
            this.statisticAllDataGridView.AutoGenerateColumns = false;
            this.statisticAllDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statisticAllDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.statisticAllDataGridView.DataSource = this.statisticAllBindingSource;
            this.statisticAllDataGridView.Location = new System.Drawing.Point(12, 25);
            this.statisticAllDataGridView.Name = "statisticAllDataGridView";
            this.statisticAllDataGridView.RowHeadersWidth = 51;
            this.statisticAllDataGridView.RowTemplate.Height = 24;
            this.statisticAllDataGridView.Size = new System.Drawing.Size(609, 187);
            this.statisticAllDataGridView.TabIndex = 2;
            // 
            // demEx24DataSet1
            // 
            this.demEx24DataSet1.DataSetName = "DemEx24DataSet";
            this.demEx24DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // faultTypeBindingSource
            // 
            this.faultTypeBindingSource.DataMember = "FaultType";
            this.faultTypeBindingSource.DataSource = this.demEx24DataSet1;
            // 
            // faultTypeTableAdapter
            // 
            this.faultTypeTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Общее количество заявок";
            this.dataGridViewTextBoxColumn1.HeaderText = "Общее количество заявок";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Среднее время выполнения заявки (в днях)";
            this.dataGridViewTextBoxColumn2.HeaderText = "Среднее время выполнения заявки (в днях)";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Самый популярный тип неисправности";
            this.dataGridViewTextBoxColumn3.DataSource = this.faultTypeBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "FaultTypeName";
            this.dataGridViewTextBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewTextBoxColumn3.HeaderText = "Самый популярный тип неисправности";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "FaultTypeID";
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 450);
            this.Controls.Add(this.statisticAllDataGridView);
            this.Controls.Add(this.statisticAllBindingNavigator);
            this.Name = "StatisticForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StatisticForm";
            this.Load += new System.EventHandler(this.StatisticForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticAllBindingNavigator)).EndInit();
            this.statisticAllBindingNavigator.ResumeLayout(false);
            this.statisticAllBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statisticAllDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.demEx24DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faultTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DemEx24DataSet demEx24DataSet;
        private System.Windows.Forms.BindingSource statisticAllBindingSource;
        private DemEx24DataSetTableAdapters.StatisticAllTableAdapter statisticAllTableAdapter;
        private DemEx24DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator statisticAllBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton statisticAllBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView statisticAllDataGridView;
        private DemEx24DataSet demEx24DataSet1;
        private System.Windows.Forms.BindingSource faultTypeBindingSource;
        private DemEx24DataSetTableAdapters.FaultTypeTableAdapter faultTypeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
    }
}