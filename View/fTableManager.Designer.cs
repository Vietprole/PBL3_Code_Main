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
            this.flbTable = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.DataGridView();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btnSwithTable = new System.Windows.Forms.Button();
            this.cbSwithTable = new System.Windows.Forms.ComboBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.nmDisCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.đăngKýCaLàmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngKýCaLàmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xemCaLàmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lsvBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doanhMụcToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem,
            this.đăngKýCaLàmToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(906, 24);
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
            this.doanhMụcToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.doanhMụcToolStripMenuItem.Text = "Chức Năng";
            // 
            // thanhToánCtrlShiftTToolStripMenuItem
            // 
            this.thanhToánCtrlShiftTToolStripMenuItem.Name = "thanhToánCtrlShiftTToolStripMenuItem";
            this.thanhToánCtrlShiftTToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.thanhToánCtrlShiftTToolStripMenuItem.ShowShortcutKeys = false;
            this.thanhToánCtrlShiftTToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.thanhToánCtrlShiftTToolStripMenuItem.Text = "Thanh Toán      Ctrl + Shift + T";
            this.thanhToánCtrlShiftTToolStripMenuItem.Click += new System.EventHandler(this.thanhToánCtrlShiftTToolStripMenuItem_Click);
            // 
            // chuyểnBànCtrlShiftTToolStripMenuItem
            // 
            this.chuyểnBànCtrlShiftTToolStripMenuItem.Name = "chuyểnBànCtrlShiftTToolStripMenuItem";
            this.chuyểnBànCtrlShiftTToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.chuyểnBànCtrlShiftTToolStripMenuItem.ShowShortcutKeys = false;
            this.chuyểnBànCtrlShiftTToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.chuyểnBànCtrlShiftTToolStripMenuItem.Text = "Chuyển Bàn     Ctrl + Shift + C";
            this.chuyểnBànCtrlShiftTToolStripMenuItem.Click += new System.EventHandler(this.chuyểnBànCtrlShiftTToolStripMenuItem_Click);
            // 
            // ctrlShiftTToolStripMenuItem
            // 
            this.ctrlShiftTToolStripMenuItem.Name = "ctrlShiftTToolStripMenuItem";
            this.ctrlShiftTToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.ctrlShiftTToolStripMenuItem.ShowShortcutKeys = false;
            this.ctrlShiftTToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.ctrlShiftTToolStripMenuItem.Text = "Thêm món        Ctrl + Shift + A";
            this.ctrlShiftTToolStripMenuItem.Click += new System.EventHandler(this.ctrlShiftTToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.thoátToolStripMenuItem.ShowShortcutKeys = false;
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.thoátToolStripMenuItem.Text = "Thoát               Ctrl + Shift + E";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.đổiMậtKhẩuToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài Khoản";
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Y)));
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // flbTable
            // 
            this.flbTable.Location = new System.Drawing.Point(12, 29);
            this.flbTable.Name = "flbTable";
            this.flbTable.Size = new System.Drawing.Size(423, 381);
            this.flbTable.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(441, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 323);
            this.panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lsvBill.Location = new System.Drawing.Point(1, 1);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(333, 320);
            this.lsvBill.TabIndex = 0;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(441, 29);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(214, 21);
            this.cbCategory.TabIndex = 3;
            this.cbCategory.Text = "Chọn loại nước";
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(441, 56);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(214, 21);
            this.cbFood.TabIndex = 4;
            this.cbFood.Text = "Chọn nước";
            // 
            // btnAddFood
            // 
            this.btnAddFood.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.Location = new System.Drawing.Point(661, 29);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(72, 48);
            this.btnAddFood.TabIndex = 6;
            this.btnAddFood.Text = "Thêm Món";
            this.btnAddFood.UseVisualStyleBackColor = true;
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.Location = new System.Drawing.Point(739, 47);
            this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(35, 20);
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
            this.btnSwithTable.Location = new System.Drawing.Point(781, 90);
            this.btnSwithTable.Name = "btnSwithTable";
            this.btnSwithTable.Size = new System.Drawing.Size(117, 48);
            this.btnSwithTable.TabIndex = 8;
            this.btnSwithTable.Text = "Chuyển Bàn";
            this.btnSwithTable.UseVisualStyleBackColor = true;
            // 
            // cbSwithTable
            // 
            this.cbSwithTable.FormattingEnabled = true;
            this.cbSwithTable.Location = new System.Drawing.Point(781, 144);
            this.cbSwithTable.Name = "cbSwithTable";
            this.cbSwithTable.Size = new System.Drawing.Size(118, 21);
            this.cbSwithTable.TabIndex = 9;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.Location = new System.Drawing.Point(783, 360);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(118, 48);
            this.btnCheckOut.TabIndex = 10;
            this.btnCheckOut.Text = "Thanh Toán";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // nmDisCount
            // 
            this.nmDisCount.Location = new System.Drawing.Point(782, 242);
            this.nmDisCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmDisCount.Name = "nmDisCount";
            this.nmDisCount.Size = new System.Drawing.Size(117, 20);
            this.nmDisCount.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(783, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tổng tiền";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(781, 316);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(117, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.Location = new System.Drawing.Point(781, 190);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(117, 48);
            this.btnDiscount.TabIndex = 15;
            this.btnDiscount.Text = "Giảm Giá";
            this.btnDiscount.UseVisualStyleBackColor = true;
            // 
            // đăngKýCaLàmToolStripMenuItem
            // 
            this.đăngKýCaLàmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngKýCaLàmToolStripMenuItem1,
            this.xemCaLàmToolStripMenuItem});
            this.đăngKýCaLàmToolStripMenuItem.Name = "đăngKýCaLàmToolStripMenuItem";
            this.đăngKýCaLàmToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.đăngKýCaLàmToolStripMenuItem.Text = "Ca Làm";
            // 
            // đăngKýCaLàmToolStripMenuItem1
            // 
            this.đăngKýCaLàmToolStripMenuItem1.Name = "đăngKýCaLàmToolStripMenuItem1";
            this.đăngKýCaLàmToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.đăngKýCaLàmToolStripMenuItem1.Text = "Đăng Ký  Ca Làm";
            this.đăngKýCaLàmToolStripMenuItem1.Click += new System.EventHandler(this.đăngKýCaLàmToolStripMenuItem1_Click);
            // 
            // xemCaLàmToolStripMenuItem
            // 
            this.xemCaLàmToolStripMenuItem.Name = "xemCaLàmToolStripMenuItem";
            this.xemCaLàmToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.xemCaLàmToolStripMenuItem.Text = "Xem Ca Làm";
            this.xemCaLàmToolStripMenuItem.Click += new System.EventHandler(this.xemCaLàmToolStripMenuItem_Click);
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 422);
            this.Controls.Add(this.btnDiscount);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmDisCount);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.cbSwithTable);
            this.Controls.Add(this.btnSwithTable);
            this.Controls.Add(this.nmFoodCount);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.cbFood);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flbTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bàn ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lsvBill)).EndInit();
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
        private System.Windows.Forms.Panel flbTable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.DataGridView lsvBill;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.Button btnSwithTable;
        private System.Windows.Forms.ComboBox cbSwithTable;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.NumericUpDown nmDisCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngKýCaLàmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngKýCaLàmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xemCaLàmToolStripMenuItem;
    }
}