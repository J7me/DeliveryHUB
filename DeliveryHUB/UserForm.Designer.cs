namespace DeliveryHUB
{
    partial class UserForm
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
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.cmbPickupPoints = new System.Windows.Forms.ComboBox();
            this.cmbStatusOrders = new System.Windows.Forms.ComboBox();
            this.FilterLabel = new System.Windows.Forms.Label();
            this.cmbSortTable = new System.Windows.Forms.ComboBox();
            this.SortLabel = new System.Windows.Forms.Label();
            this.ToolbarMenuStrip = new System.Windows.Forms.MenuStrip();
            this.SearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.ToolbarMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(62, 154);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.Size = new System.Drawing.Size(674, 264);
            this.dataGridViewOrders.TabIndex = 0;
            // 
            // cmbPickupPoints
            // 
            this.cmbPickupPoints.FormattingEnabled = true;
            this.cmbPickupPoints.Location = new System.Drawing.Point(101, 106);
            this.cmbPickupPoints.Name = "cmbPickupPoints";
            this.cmbPickupPoints.Size = new System.Drawing.Size(121, 21);
            this.cmbPickupPoints.TabIndex = 5;
            this.cmbPickupPoints.SelectedIndexChanged += new System.EventHandler(this.cmbPickupPoints_SelectedIndexChanged);
            // 
            // cmbStatusOrders
            // 
            this.cmbStatusOrders.FormattingEnabled = true;
            this.cmbStatusOrders.Location = new System.Drawing.Point(262, 106);
            this.cmbStatusOrders.Name = "cmbStatusOrders";
            this.cmbStatusOrders.Size = new System.Drawing.Size(121, 21);
            this.cmbStatusOrders.TabIndex = 6;
            this.cmbStatusOrders.SelectedIndexChanged += new System.EventHandler(this.cmbStatusOrders_SelectedIndexChanged);
            // 
            // FilterLabel
            // 
            this.FilterLabel.AutoSize = true;
            this.FilterLabel.Location = new System.Drawing.Point(202, 60);
            this.FilterLabel.Name = "FilterLabel";
            this.FilterLabel.Size = new System.Drawing.Size(71, 13);
            this.FilterLabel.TabIndex = 8;
            this.FilterLabel.Text = "Фильтрация";
            // 
            // cmbSortTable
            // 
            this.cmbSortTable.FormattingEnabled = true;
            this.cmbSortTable.Location = new System.Drawing.Point(518, 106);
            this.cmbSortTable.Name = "cmbSortTable";
            this.cmbSortTable.Size = new System.Drawing.Size(121, 21);
            this.cmbSortTable.TabIndex = 9;
            this.cmbSortTable.SelectedIndexChanged += new System.EventHandler(this.cmbSortTable_SelectedIndexChanged);
            // 
            // SortLabel
            // 
            this.SortLabel.AutoSize = true;
            this.SortLabel.Location = new System.Drawing.Point(549, 73);
            this.SortLabel.Name = "SortLabel";
            this.SortLabel.Size = new System.Drawing.Size(67, 13);
            this.SortLabel.TabIndex = 10;
            this.SortLabel.Text = "Сортировка";
            // 
            // ToolbarMenuStrip
            // 
            this.ToolbarMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolbarMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchToolStripMenuItem,
            this.UpdToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.ToolbarMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolbarMenuStrip.Name = "ToolbarMenuStrip";
            this.ToolbarMenuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.ToolbarMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.ToolbarMenuStrip.TabIndex = 11;
            this.ToolbarMenuStrip.Text = "menuStrip2";
            // 
            // SearchToolStripMenuItem
            // 
            this.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
            this.SearchToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
            this.SearchToolStripMenuItem.Text = "Поиск";
            this.SearchToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // UpdToolStripMenuItem
            // 
            this.UpdToolStripMenuItem.Name = "UpdToolStripMenuItem";
            this.UpdToolStripMenuItem.Size = new System.Drawing.Size(73, 22);
            this.UpdToolStripMenuItem.Text = "Обновить";
            this.UpdToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ToolbarMenuStrip);
            this.Controls.Add(this.SortLabel);
            this.Controls.Add(this.cmbSortTable);
            this.Controls.Add(this.FilterLabel);
            this.Controls.Add(this.cmbStatusOrders);
            this.Controls.Add(this.cmbPickupPoints);
            this.Controls.Add(this.dataGridViewOrders);
            this.Name = "UserForm";
            this.Text = "Личный кабинет";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrdersForm_FormClosing);
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ToolbarMenuStrip.ResumeLayout(false);
            this.ToolbarMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.ComboBox cmbPickupPoints;
        private System.Windows.Forms.ComboBox cmbStatusOrders;
        private System.Windows.Forms.Label FilterLabel;
        private System.Windows.Forms.ComboBox cmbSortTable;
        private System.Windows.Forms.Label SortLabel;
        private System.Windows.Forms.MenuStrip ToolbarMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}