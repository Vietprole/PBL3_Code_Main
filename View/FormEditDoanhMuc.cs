using PBL3CodeDemo.BLL;
using PBL3CodeDemo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBL3CodeDemo.View
{
    public partial class FormEditDoanhMuc : Form
    {
        public FormEditDoanhMuc()
        {
            InitializeComponent();
            setCBB_DoanhMuc();

        }
        void setCBB_DoanhMuc()
        {
            cbb_DoanhMuc_Edit.Items.Clear();
            using (PBL3Entities db = new PBL3Entities())
            {
                foreach (Category i in db.Categories)
                {
                    if(i.Flag == true)
                    {
                        cbb_DoanhMuc_Edit.Items.Add(new CBB_Item
                        {
                            Value = i.ID_Category,
                            Text = i.Category_Name
                        });
                    }
                }
            }
            cbb_DoanhMuc_Edit.SelectedIndex = 0;
        }

        private void btt_Add_DoanhMuc_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            if (string.IsNullOrEmpty(txtbox_EditDoanhMuc.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
                
            else
            {
                String Category_Name = txtbox_EditDoanhMuc.Text;
                if (bll.Add_Category(Category_Name))
                {
                    MessageBox.Show("Đã thêm doanh mục thành công !", "Thông báo!");
                }
                else
                {
                    MessageBox.Show("Tên doanh mục này đã bị trùng, vui lòng chọn tên khác", "Thông báo!");
                }
            }
            setCBB_DoanhMuc();
        }

        private void btt_Edit_DoanhMuc_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            if (string.IsNullOrEmpty(txtbox_EditDoanhMuc.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                String Old_Category_Name = cbb_DoanhMuc_Edit.Text;
                String New_Category_Name = txtbox_EditDoanhMuc.Text;
                if (bll.Edit_Category(Old_Category_Name, New_Category_Name))
                {
                    MessageBox.Show("Đã sửa doanh mục thành công !", "Thông báo!");
                }
                else
                {
                    MessageBox.Show("Tên doanh mục này đã bị trùng, vui lòng chọn tên khác", "Thông báo!");
                }
            }
            setCBB_DoanhMuc();

        }

        private void btt_Del_DoanhMuc_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            String Category_Name = cbb_DoanhMuc_Edit.Text;
            bll.Delete_Category(Category_Name);
            MessageBox.Show("Xóa doanh mục thành công");
            setCBB_DoanhMuc();
        }
    }
}
