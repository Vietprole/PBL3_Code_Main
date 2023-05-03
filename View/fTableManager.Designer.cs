namespace PBL3CodeDemo.View
{
    partial class fTableManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.doanhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToánCtrlShiftTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnBànCtrlShiftTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlShiftTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BillTable_DGV = new System.Windows.Forms.DataGridView();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btnSwithTable = new System.Windows.Forms.Button();
            this.cbSwithTable = new System.Windows.Forms.ComboBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.nmDisCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.flbTable = new System.Windows.Forms.FlowLayoutPanel();
            this.id_Table_Last_Pressed = new System.Windows.Forms.Label();
            this.bttDeleteFood = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BillTable_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doanhMụcToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1208, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // doanhMụcToolStripMenuItem
            // 
            this.doanhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thanhToánCtrlShiftTToolStripMenuItem,
            this.chuyểnBànCtrlShiftTToolStripMenuItem,
            this.ctrlShiftTToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.doanhMụcToolStripMenuItem.Name = "doanhMụcToolStripMenuItem";
            this.doanhMụcToolStripMenuItem.Size = new System.Drawing.Size(120, 25);
            this.doanhMụcToolStripMenuItem.Text = "Doanh Mục";
            // 
            // thanhToánCtrlShiftTToolStripMenuItem
            // 
            this.thanhToánCtrlShiftTToolStripMenuItem.Name = "thanhToánCtrlShiftTToolStripMenuItem";
            this.thanhToánCtrlShiftTToolStripMenuItem.Size = new System.Drawing.Size(355, 26);
            this.thanhToánCtrlShiftTToolStripMenuItem.Text = "Thanh Toán      Ctrl + Shift + T";
            // 
            // chuyểnBànCtrlShiftTToolStripMenuItem
            // 
            this.chuyểnBànCtrlShiftTToolStripMenuItem.Name = "chuyểnBànCtrlShiftTToolStripMenuItem";
            this.chuyểnBànCtrlShiftTToolStripMenuItem.Size = new System.Drawing.Size(355, 26);
            this.chuyểnBànCtrlShiftTToolStripMenuItem.Text = "Chuyển Bàn     Ctrl + Shift + C";
            // 
            // ctrlShiftTToolStripMenuItem
            // 
            this.ctrlShiftTToolStripMenuItem.Name = "ctrlShiftTToolStripMenuItem";
            this.ctrlShiftTToolStripMenuItem.Size = new System.Drawing.Size(355, 26);
            this.ctrlShiftTToolStripMenuItem.Text = "Thêm món        Ctrl + Shift + A";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(355, 26);
            this.thoátToolStripMenuItem.Text = "Thoát               Ctrl + Shift + Q";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.đổiMậtKhẩuToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(109, 25);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài Khoản";
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(79, 25);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BillTable_DGV);
            this.panel2.Location = new System.Drawing.Point(588, 107);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 398);
            this.panel2.TabIndex = 2;
            // 
            // BillTable_DGV
            // 
            this.BillTable_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BillTable_DGV.Location = new System.Drawing.Point(0, 0);
            this.BillTable_DGV.Name = "BillTable_DGV";
            this.BillTable_DGV.RowHeadersWidth = 51;
            this.BillTable_DGV.RowTemplate.Height = 24;
            this.BillTable_DGV.Size = new System.Drawing.Size(449, 395);
            this.BillTable_DGV.TabIndex = 0;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(588, 36);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(284, 24);
            this.cbCategory.TabIndex = 3;
            this.cbCategory.Text = "Chọn loại nước";
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(588, 69);
            this.cbFood.Margin = new System.Windows.Forms.Padding(4);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(284, 24);
            this.cbFood.TabIndex = 4;
            this.cbFood.Text = "Chọn nước";
            // 
            // btnAddFood
            // 
            this.btnAddFood.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.Location = new System.Drawing.Point(945, 33);
            this.btnAddFood.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(96, 59);
            this.btnAddFood.TabIndex = 6;
            this.btnAddFood.Text = "Thêm Món";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.Location = new System.Drawing.Point(890, 48);
            this.nmFoodCount.Margin = new System.Windows.Forms.Padding(4);
            this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(47, 22);
            this.nmFoodCount.TabIndex = 6;
            this.nmFoodCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmFoodCount.UseWaitCursor = true;
            this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSwithTable
            // 
            this.btnSwithTable.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwithTable.Location = new System.Drawing.Point(1041, 111);
            this.btnSwithTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnSwithTable.Name = "btnSwithTable";
            this.btnSwithTable.Size = new System.Drawing.Size(156, 59);
            this.btnSwithTable.TabIndex = 8;
            this.btnSwithTable.Text = "Chuyển Bàn";
            this.btnSwithTable.UseVisualStyleBackColor = true;
            // 
            // cbSwithTable
            // 
            this.cbSwithTable.FormattingEnabled = true;
            this.cbSwithTable.Location = new System.Drawing.Point(1041, 177);
            this.cbSwithTable.Margin = new System.Windows.Forms.Padding(4);
            this.cbSwithTable.Name = "cbSwithTable";
            this.cbSwithTable.Size = new System.Drawing.Size(156, 24);
            this.cbSwithTable.TabIndex = 9;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.Location = new System.Drawing.Point(1044, 443);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(157, 59);
            this.btnCheckOut.TabIndex = 10;
            this.btnCheckOut.Text = "Thanh Toán";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // nmDisCount
            // 
            this.nmDisCount.Location = new System.Drawing.Point(1043, 298);
            this.nmDisCount.Margin = new System.Windows.Forms.Padding(4);
            this.nmDisCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmDisCount.Name = "nmDisCount";
            this.nmDisCount.Size = new System.Drawing.Size(156, 22);
            this.nmDisCount.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1044, 353);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tổng tiền";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(1041, 389);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.ReadOnly = true;
            this.textBoxPrice.Size = new System.Drawing.Size(155, 22);
            this.textBoxPrice.TabIndex = 14;
            this.textBoxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.Location = new System.Drawing.Point(1041, 234);
            this.btnDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(156, 59);
            this.btnDiscount.TabIndex = 15;
            this.btnDiscount.Text = "Giảm Giá";
            this.btnDiscount.UseVisualStyleBackColor = true;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // flbTable
            // 
            this.flbTable.Location = new System.Drawing.Point(13, 33);
            this.flbTable.Name = "flbTable";
            this.flbTable.Size = new System.Drawing.Size(568, 469);
            this.flbTable.TabIndex = 16;
            // 
            // id_Table_Last_Pressed
            // 
            this.id_Table_Last_Pressed.AutoSize = true;
            this.id_Table_Last_Pressed.Location = new System.Drawing.Point(669, 9);
            this.id_Table_Last_Pressed.Name = "id_Table_Last_Pressed";
            this.id_Table_Last_Pressed.Size = new System.Drawing.Size(44, 16);
            this.id_Table_Last_Pressed.TabIndex = 17;
            this.id_Table_Last_Pressed.Text = "label2";
            this.id_Table_Last_Pressed.Visible = false;
            // 
            // bttDeleteFood
            // 
            this.bttDeleteFood.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttDeleteFood.Location = new System.Drawing.Point(1074, 33);
            this.bttDeleteFood.Margin = new System.Windows.Forms.Padding(4);
            this.bttDeleteFood.Name = "bttDeleteFood";
            this.bttDeleteFood.Size = new System.Drawing.Size(96, 59);
            this.bttDeleteFood.TabIndex = 6;
            this.bttDeleteFood.Text = "Xóa Món";
            this.bttDeleteFood.UseVisualStyleBackColor = true;
            this.bttDeleteFood.Click += new System.EventHandler(this.bttDeleteFood_Click);
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 519);
            this.Controls.Add(this.id_Table_Last_Pressed);
            this.Controls.Add(this.flbTable);
            this.Controls.Add(this.btnDiscount);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmDisCount);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.cbSwithTable);
            this.Controls.Add(this.btnSwithTable);
            this.Controls.Add(this.nmFoodCount);
            this.Controls.Add(this.bttDeleteFood);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.cbFood);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bàn ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BillTable_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem doanhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thanhToánCtrlShiftTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chuyểnBànCtrlShiftTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctrlShiftTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.Button btnSwithTable;
        private System.Windows.Forms.ComboBox cbSwithTable;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.NumericUpDown nmDisCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flbTable;
        private System.Windows.Forms.DataGridView BillTable_DGV;
        private System.Windows.Forms.Label id_Table_Last_Pressed;
        private System.Windows.Forms.Button bttDeleteFood;
    }
}