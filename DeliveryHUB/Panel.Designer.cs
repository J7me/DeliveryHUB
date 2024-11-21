namespace DeliveryHUB
{
    partial class MainForm
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
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.SwitchingTablesBox = new System.Windows.Forms.ComboBox();
            this.RecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolbarMenuStrip = new System.Windows.Forms.MenuStrip();
            this.UpdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolMenuStrip = new System.Windows.Forms.MenuStrip();
            this.cmbPickupPoints = new System.Windows.Forms.ComboBox();
            this.cmbStatusOrders = new System.Windows.Forms.ComboBox();
            this.cmbSortTable = new System.Windows.Forms.ComboBox();
            this.FilterLabel = new System.Windows.Forms.Label();
            this.SortLabel = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.ToolbarMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewMain.Location = new System.Drawing.Point(68, 196);
            this.dataGridViewMain.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowHeadersWidth = 62;
            this.dataGridViewMain.RowTemplate.Height = 28;
            this.dataGridViewMain.Size = new System.Drawing.Size(661, 241);
            this.dataGridViewMain.TabIndex = 2;
            this.dataGridViewMain.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMain_CellEndEdit);
            this.dataGridViewMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMain_CellValueChanged);
            // 
            // SwitchingTablesBox
            // 
            this.SwitchingTablesBox.FormattingEnabled = true;
            this.SwitchingTablesBox.Location = new System.Drawing.Point(37, 159);
            this.SwitchingTablesBox.Name = "SwitchingTablesBox";
            this.SwitchingTablesBox.Size = new System.Drawing.Size(121, 21);
            this.SwitchingTablesBox.TabIndex = 3;
            this.SwitchingTablesBox.SelectedIndexChanged += new System.EventHandler(this.SwitchingTablesBox_SelectedIndexChanged);
            // 
            // RecToolStripMenuItem
            // 
            this.RecToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.RecToolStripMenuItem.Name = "RecToolStripMenuItem";
            this.RecToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.RecToolStripMenuItem.Text = "Записи";
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.AutoSize = false;
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(290, 27);
            this.AddToolStripMenuItem.Text = "Добавить";
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.EditToolStripMenuItem.Text = "Редактировать";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteToolStripMenuItem.Text = "Удалить";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // SearchToolStripMenuItem
            // 
            this.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
            this.SearchToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
            this.SearchToolStripMenuItem.Text = "Поиск";
            this.SearchToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // ToolbarMenuStrip
            // 
            this.ToolbarMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolbarMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RecToolStripMenuItem,
            this.SearchToolStripMenuItem,
            this.UpdToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.ToolbarMenuStrip.Location = new System.Drawing.Point(3, 64);
            this.ToolbarMenuStrip.Name = "ToolbarMenuStrip";
            this.ToolbarMenuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.ToolbarMenuStrip.Size = new System.Drawing.Size(767, 24);
            this.ToolbarMenuStrip.TabIndex = 1;
            this.ToolbarMenuStrip.Text = "menuStrip2";
            // 
            // UpdToolStripMenuItem
            // 
            this.UpdToolStripMenuItem.Name = "UpdToolStripMenuItem";
            this.UpdToolStripMenuItem.Size = new System.Drawing.Size(73, 22);
            this.UpdToolStripMenuItem.Text = "Обновить";
            this.UpdToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // ToolMenuStrip
            // 
            this.ToolMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolMenuStrip.Location = new System.Drawing.Point(3, 88);
            this.ToolMenuStrip.Name = "ToolMenuStrip";
            this.ToolMenuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.ToolMenuStrip.Size = new System.Drawing.Size(767, 24);
            this.ToolMenuStrip.TabIndex = 0;
            this.ToolMenuStrip.Text = "ToolMenuStrip";
            // 
            // cmbPickupPoints
            // 
            this.cmbPickupPoints.FormattingEnabled = true;
            this.cmbPickupPoints.Location = new System.Drawing.Point(200, 159);
            this.cmbPickupPoints.Name = "cmbPickupPoints";
            this.cmbPickupPoints.Size = new System.Drawing.Size(121, 21);
            this.cmbPickupPoints.TabIndex = 4;
            this.cmbPickupPoints.SelectedIndexChanged += new System.EventHandler(this.cmbPickupPoints_SelectedIndexChanged);
            // 
            // cmbStatusOrders
            // 
            this.cmbStatusOrders.FormattingEnabled = true;
            this.cmbStatusOrders.Location = new System.Drawing.Point(345, 159);
            this.cmbStatusOrders.Name = "cmbStatusOrders";
            this.cmbStatusOrders.Size = new System.Drawing.Size(121, 21);
            this.cmbStatusOrders.TabIndex = 5;
            this.cmbStatusOrders.SelectedIndexChanged += new System.EventHandler(this.cmbStatusOrders_SelectedIndexChanged);
            // 
            // cmbSortTable
            // 
            this.cmbSortTable.FormattingEnabled = true;
            this.cmbSortTable.Location = new System.Drawing.Point(572, 159);
            this.cmbSortTable.Name = "cmbSortTable";
            this.cmbSortTable.Size = new System.Drawing.Size(121, 21);
            this.cmbSortTable.TabIndex = 6;
            this.cmbSortTable.SelectedIndexChanged += new System.EventHandler(this.cmbSortTable_SelectedIndexChanged);
            // 
            // FilterLabel
            // 
            this.FilterLabel.AutoSize = true;
            this.FilterLabel.Location = new System.Drawing.Point(250, 123);
            this.FilterLabel.Name = "FilterLabel";
            this.FilterLabel.Size = new System.Drawing.Size(71, 13);
            this.FilterLabel.TabIndex = 7;
            this.FilterLabel.Text = "Фильтрация";
            this.FilterLabel.Click += new System.EventHandler(this.FilterLabel_Click);
            // 
            // SortLabel
            // 
            this.SortLabel.AutoSize = true;
            this.SortLabel.Location = new System.Drawing.Point(597, 123);
            this.SortLabel.Name = "SortLabel";
            this.SortLabel.Size = new System.Drawing.Size(67, 13);
            this.SortLabel.TabIndex = 8;
            this.SortLabel.Text = "Сортировка";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 448);
            this.Controls.Add(this.SortLabel);
            this.Controls.Add(this.FilterLabel);
            this.Controls.Add(this.cmbSortTable);
            this.Controls.Add(this.cmbStatusOrders);
            this.Controls.Add(this.cmbPickupPoints);
            this.Controls.Add(this.SwitchingTablesBox);
            this.Controls.Add(this.dataGridViewMain);
            this.Controls.Add(this.ToolMenuStrip);
            this.Controls.Add(this.ToolbarMenuStrip);
            this.MainMenuStrip = this.ToolMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliveryHUB - Панель управления";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ToolbarMenuStrip.ResumeLayout(false);
            this.ToolbarMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.ComboBox SwitchingTablesBox;
        private System.Windows.Forms.ToolStripMenuItem RecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip ToolbarMenuStrip;
        private System.Windows.Forms.MenuStrip ToolMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem UpdToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbPickupPoints;
        private System.Windows.Forms.ComboBox cmbStatusOrders;
        private System.Windows.Forms.ComboBox cmbSortTable;
        private System.Windows.Forms.Label FilterLabel;
        private System.Windows.Forms.Label SortLabel;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}