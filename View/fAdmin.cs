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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PBL3CodeDemo.View
{
    public partial class fAdmin : Form
    {
        public int Old_ID_Table { get; set; }
        public fAdmin()
        {
            InitializeComponent();
            setCBB_ViTriBan();
            LoadDGV_Table();
            LoadDGV_Account();
            LoadDGV_Product();
            setCBBCategory();
        }
        void setCBB_ViTriBan()
        {
            QLCFBLL bll = new QLCFBLL();
            cbbPosition.Items.AddRange(bll.GetCBB_TablePosition().ToArray());
            cbbPosition.SelectedIndex = 0;
        }
        void LoadDGV_Table()
        {
            QLCFBLL bll = new QLCFBLL();
            dataGridViewTable.DataSource = bll.GetDGV_Table();
        }
        private void dataGridViewTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure the click was on a row and not on the column header
            {
                DataGridViewRow row = dataGridViewTable.Rows[e.RowIndex];
                txbNameTable.Text = row.Cells[0].Value.ToString();
                checkBoxStatus.Checked = Convert.ToBoolean(row.Cells[1].Value); // Transfer data of second column to TextBox2
                cbbPosition.Text = row.Cells[2].Value.ToString(); // Transfer data of third column to TextBox3
                Old_ID_Table = int.Parse(txbNameTable.Text);
            }
        }

        private void btnSearchTbale_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            string Table_Name = txbSearchTable.Text;
            if (Table_Name == "") // ALL 
            {
                LoadDGV_Table();
            }
            else
            {
                dataGridViewTable.DataSource = bll.GetDGV_Table_Search(Table_Name);
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            int New_ID_Table;
            bool Status = checkBoxStatus.Checked;
            string Position = cbbPosition.Text;
            bool isNumber = int.TryParse(txbNameTable.Text, out New_ID_Table);
            if( isNumber )// check xem tên bàn có chuyển được sang số nguyên hay không
            {
                New_ID_Table = int.Parse(txbNameTable.Text);
                if (bll.UpdateTable(Old_ID_Table, New_ID_Table, Status, Position)) //Update Table thành công
                {
                    MessageBox.Show("Đã cập nhật bàn thành công !");
                }
                else MessageBox.Show("Tên bàn này đã bị trùng, vui lòng chọn tên khác !");
            }else
            {
                MessageBox.Show("Tên bàn phải là một số nguyên, vui lòng nhập lại !");
            }
            LoadDGV_Table();
        }

        private void btnDelTable_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow i in dataGridViewTable.SelectedRows)
            {
                int ID_Table = Convert.ToInt32(i.Cells[0].Value);
                QLCFBLL bll = new QLCFBLL();
                bll.DeleteTable(ID_Table);
            }
            LoadDGV_Table();
            MessageBox.Show("Đã xóa thành công !");
        }
        void LoadDGV_Account()
        {
            QLCFBLL bll = new QLCFBLL();
            dataGridViewAcount.DataSource = bll.GetDGV_Account();
        }

        private void dataGridViewAcount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridViewAcount.CurrentRow.Index;
            txbUserName.Text = dataGridViewAcount.Rows[i].Cells[0].Value.ToString();
            txbDisplayName.Text= dataGridViewAcount.Rows[i].Cells[1].Value.ToString();
            txbSalary.Text = dataGridViewAcount.Rows[i].Cells[2].Value.ToString();
            txbAdress.Text = dataGridViewAcount.Rows[i].Cells[3].Value.ToString();
            txbPhone.Text = dataGridViewAcount.Rows[i].Cells[4].Value.ToString();
            txbPassWord.Text = dataGridViewAcount.Rows[i].Cells[5].Value.ToString();
            cbb_role.Text = dataGridViewAcount.Rows[i].Cells[6].Value.ToString();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {

        }
        private void LoadDGV_Product()
        {
            QLCFBLL bll = new QLCFBLL();
            dataGridViewProduct.DataSource = bll.Return_Product();
        }
        private void btnReadProduct_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            dataGridViewProduct.DataSource = bll.Return_Product();
        }
        private void setCBBCategory()
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                foreach (Category i in db.Categories)
                {
                    cbbCategory.Items.Add(new CBB_Item
                    {
                        Value = i.ID_Category,
                        Text = i.Category_Name
                    });
                }
            }
            cbbCategory.SelectedIndex = 0;
        }
        private void btnAddProduct_Click_1(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            Product product = new Product
            {
                Name = txbNameProduct.Text,
                Price = int.Parse(txbPriceProduct.Text),
                ID_Category = cbbCategory.SelectedIndex + 1
            };
            bll.Add_Product(product);
            LoadDGV_Product();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                ID_Product = int.Parse(dataGridViewProduct.SelectedRows[0].Cells[0].Value.ToString()),
                Name = txbNameProduct.Text,
                Price = int.Parse(txbPriceProduct.Text),
                ID_Category = cbbCategory.SelectedIndex + 1
            };
            QLCFBLL bll = new QLCFBLL();
            bll.Edit_Product(product);
            LoadDGV_Product();
        }

        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(dataGridViewProduct.SelectedRows[0].Cells[0].Value.ToString());
            QLCFBLL bll = new QLCFBLL();
            bll.Delete_Product(ID);
            LoadDGV_Product();
        }
    }
}
