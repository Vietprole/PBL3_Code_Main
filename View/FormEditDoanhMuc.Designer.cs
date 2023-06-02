namespace PBL3CodeDemo.View
{
    partial class FormEditDoanhMuc
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
            this.btt_Add_DoanhMuc = new System.Windows.Forms.Button();
            this.cbb_DoanhMuc_Edit = new System.Windows.Forms.ComboBox();
            this.txtbox_EditDoanhMuc = new System.Windows.Forms.TextBox();
            this.btt_Del_DoanhMuc = new System.Windows.Forms.Button();
            this.btt_Edit_DoanhMuc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btt_Add_DoanhMuc
            // 
            this.btt_Add_DoanhMuc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_Add_DoanhMuc.Location = new System.Drawing.Point(96, 173);
            this.btt_Add_DoanhMuc.Name = "btt_Add_DoanhMuc";
            this.btt_Add_DoanhMuc.Size = new System.Drawing.Size(100, 49);
            this.btt_Add_DoanhMuc.TabIndex = 1;
            this.btt_Add_DoanhMuc.Text = "Thêm";
            this.btt_Add_DoanhMuc.UseVisualStyleBackColor = true;
            this.btt_Add_DoanhMuc.Click += new System.EventHandler(this.btt_Add_DoanhMuc_Click);
            // 
            // cbb_DoanhMuc_Edit
            // 
            this.cbb_DoanhMuc_Edit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_DoanhMuc_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_DoanhMuc_Edit.FormattingEnabled = true;
            this.cbb_DoanhMuc_Edit.Location = new System.Drawing.Point(152, 59);
            this.cbb_DoanhMuc_Edit.Name = "cbb_DoanhMuc_Edit";
            this.cbb_DoanhMuc_Edit.Size = new System.Drawing.Size(236, 33);
            this.cbb_DoanhMuc_Edit.TabIndex = 2;
            // 
            // txtbox_EditDoanhMuc
            // 
            this.txtbox_EditDoanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_EditDoanhMuc.Location = new System.Drawing.Point(152, 122);
            this.txtbox_EditDoanhMuc.Name = "txtbox_EditDoanhMuc";
            this.txtbox_EditDoanhMuc.Size = new System.Drawing.Size(236, 30);
            this.txtbox_EditDoanhMuc.TabIndex = 3;
            // 
            // btt_Del_DoanhMuc
            // 
            this.btt_Del_DoanhMuc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_Del_DoanhMuc.Location = new System.Drawing.Point(353, 173);
            this.btt_Del_DoanhMuc.Name = "btt_Del_DoanhMuc";
            this.btt_Del_DoanhMuc.Size = new System.Drawing.Size(100, 49);
            this.btt_Del_DoanhMuc.TabIndex = 1;
            this.btt_Del_DoanhMuc.Text = "Xóa";
            this.btt_Del_DoanhMuc.UseVisualStyleBackColor = true;
            this.btt_Del_DoanhMuc.Click += new System.EventHandler(this.btt_Del_DoanhMuc_Click);
            // 
            // btt_Edit_DoanhMuc
            // 
            this.btt_Edit_DoanhMuc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_Edit_DoanhMuc.Location = new System.Drawing.Point(227, 173);
            this.btt_Edit_DoanhMuc.Name = "btt_Edit_DoanhMuc";
            this.btt_Edit_DoanhMuc.Size = new System.Drawing.Size(100, 49);
            this.btt_Edit_DoanhMuc.TabIndex = 1;
            this.btt_Edit_DoanhMuc.Text = "Sửa";
            this.btt_Edit_DoanhMuc.UseVisualStyleBackColor = true;
            this.btt_Edit_DoanhMuc.Click += new System.EventHandler(this.btt_Edit_DoanhMuc_Click);
            // 
            // FormEditDoanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 334);
            this.Controls.Add(this.txtbox_EditDoanhMuc);
            this.Controls.Add(this.cbb_DoanhMuc_Edit);
            this.Controls.Add(this.btt_Edit_DoanhMuc);
            this.Controls.Add(this.btt_Del_DoanhMuc);
            this.Controls.Add(this.btt_Add_DoanhMuc);
            this.Name = "FormEditDoanhMuc";
            this.Text = "FormEditDoanhMuc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btt_Add_DoanhMuc;
        private System.Windows.Forms.ComboBox cbb_DoanhMuc_Edit;
        private System.Windows.Forms.TextBox txtbox_EditDoanhMuc;
        private System.Windows.Forms.Button btt_Del_DoanhMuc;
        private System.Windows.Forms.Button btt_Edit_DoanhMuc;
    }
}