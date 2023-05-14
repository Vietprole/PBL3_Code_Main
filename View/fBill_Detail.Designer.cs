namespace PBL3CodeDemo.View
{
    partial class fBill_Detail
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
            this.dataGridView_BillDetail = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Status_Total = new System.Windows.Forms.Label();
            this.txbTotal_Bill = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnDeleteFood = new System.Windows.Forms.Button();
            this.label_DateBill = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DateOrder = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbTimeOrder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbb_Table = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BillDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_BillDetail
            // 
            this.dataGridView_BillDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_BillDetail.Location = new System.Drawing.Point(16, 15);
            this.dataGridView_BillDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_BillDetail.Name = "dataGridView_BillDetail";
            this.dataGridView_BillDetail.RowHeadersWidth = 51;
            this.dataGridView_BillDetail.Size = new System.Drawing.Size(601, 220);
            this.dataGridView_BillDetail.TabIndex = 0;
            this.dataGridView_BillDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_BillDetail_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_Status_Total);
            this.panel1.Controls.Add(this.txbTotal_Bill);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(16, 242);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 47);
            this.panel1.TabIndex = 17;
            // 
            // label_Status_Total
            // 
            this.label_Status_Total.AutoSize = true;
            this.label_Status_Total.Location = new System.Drawing.Point(501, 18);
            this.label_Status_Total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Status_Total.Name = "label_Status_Total";
            this.label_Status_Total.Size = new System.Drawing.Size(0, 17);
            this.label_Status_Total.TabIndex = 3;
            // 
            // txbTotal_Bill
            // 
            this.txbTotal_Bill.Location = new System.Drawing.Point(164, 15);
            this.txbTotal_Bill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbTotal_Bill.Name = "txbTotal_Bill";
            this.txbTotal_Bill.Size = new System.Drawing.Size(284, 22);
            this.txbTotal_Bill.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tổng tiền:";
            // 
            // btnAddFood
            // 
            this.btnAddFood.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.Location = new System.Drawing.Point(16, 297);
            this.btnAddFood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(96, 59);
            this.btnAddFood.TabIndex = 20;
            this.btnAddFood.Text = "Thêm Món";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cbFood
            // 
            this.cbFood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(180, 332);
            this.cbFood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(284, 24);
            this.cbFood.TabIndex = 19;
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(180, 297);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(284, 24);
            this.cbCategory.TabIndex = 18;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // btnDeleteFood
            // 
            this.btnDeleteFood.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFood.Location = new System.Drawing.Point(521, 297);
            this.btnDeleteFood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteFood.Name = "btnDeleteFood";
            this.btnDeleteFood.Size = new System.Drawing.Size(96, 59);
            this.btnDeleteFood.TabIndex = 21;
            this.btnDeleteFood.Text = "Xóa Món";
            this.btnDeleteFood.UseVisualStyleBackColor = true;
            this.btnDeleteFood.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_DateBill
            // 
            this.label_DateBill.AutoSize = true;
            this.label_DateBill.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DateBill.Location = new System.Drawing.Point(351, 239);
            this.label_DateBill.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_DateBill.Name = "label_DateBill";
            this.label_DateBill.Size = new System.Drawing.Size(0, 24);
            this.label_DateBill.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DateOrder);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(16, 366);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 47);
            this.panel2.TabIndex = 18;
            // 
            // DateOrder
            // 
            this.DateOrder.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOrder.Location = new System.Drawing.Point(164, 15);
            this.DateOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DateOrder.Name = "DateOrder";
            this.DateOrder.Size = new System.Drawing.Size(284, 22);
            this.DateOrder.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbTimeOrder);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(16, 418);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(601, 47);
            this.panel3.TabIndex = 19;
            // 
            // txbTimeOrder
            // 
            this.txbTimeOrder.Location = new System.Drawing.Point(164, 9);
            this.txbTimeOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbTimeOrder.Name = "txbTimeOrder";
            this.txbTimeOrder.Size = new System.Drawing.Size(284, 22);
            this.txbTimeOrder.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giờ :";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbb_Table);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(16, 473);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(601, 47);
            this.panel5.TabIndex = 20;
            // 
            // cbb_Table
            // 
            this.cbb_Table.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Table.FormattingEnabled = true;
            this.cbb_Table.Location = new System.Drawing.Point(168, 7);
            this.cbb_Table.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbb_Table.Name = "cbb_Table";
            this.cbb_Table.Size = new System.Drawing.Size(279, 24);
            this.cbb_Table.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(501, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1, 14);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "Bàn:";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(16, 555);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(223, 31);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "Hoàn Tất";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(395, 555);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(223, 31);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // fBill_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 635);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label_DateBill);
            this.Controls.Add(this.btnDeleteFood);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.cbFood);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView_BillDetail);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fBill_Detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin chi tiết hóa đơn";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BillDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_BillDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbTotal_Bill;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnDeleteFood;
        private System.Windows.Forms.Label label_Status_Total;
        private System.Windows.Forms.Label label_DateBill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker DateOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cbb_Table;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txbTimeOrder;
    }
}