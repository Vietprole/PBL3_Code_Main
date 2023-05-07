﻿using PBL3CodeDemo.BLL;
using PBL3CodeDemo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PBL3CodeDemo.View
{
    public partial class fAdmin : Form
    {
        public int Old_ID_Table { get; set; }
        public delegate void ReLoadFTableManager();
        public ReLoadFTableManager reloadTable { get; set; }
        public ReLoadFTableManager reloadCBBCategory { get; set; }

        public fAdmin()
        {
            InitializeComponent();
            setCBB_ViTriBan();
            LoadDGV_Table();
            LoadDGV_Account();
            LoadDGV_Product();
            setCBBCategory();
            QLCFBLL bll = new QLCFBLL();
            chart1.Series.Clear();
            int SumPrice = 0;
            chart1.Series.Clear();
            chart1.Series.Add("Doanh Thu");
            foreach (Revenue i in bll.Get_Revenue(Convert.ToDateTime("01/01/2023"), dateEnd.Value.Date))
            {
                chart1.Series["Doanh Thu"].Points.AddXY(i.day, i.price);
                SumPrice += i.price;
            }
            txbRevenue.Text = SumPrice.ToString();
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
            if (isNumber)// check xem tên bàn có chuyển được sang số nguyên hay không
            {
                New_ID_Table = int.Parse(txbNameTable.Text);
                if (bll.UpdateTable(Old_ID_Table, New_ID_Table, Status, Position)) //Update Table thành công
                {
                    MessageBox.Show("Đã cập nhật bàn thành công !");
                }
                else MessageBox.Show("Tên bàn này đã bị trùng, vui lòng chọn tên khác !");
            }
            else
            {
                MessageBox.Show("Tên bàn phải là một số nguyên, vui lòng nhập lại !");
            }
            LoadDGV_Table();
        }

        private void btnDelTable_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dataGridViewTable.SelectedRows)
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
            txbDisplayName.Text = "";
            txbUserName.ReadOnly = false;

            txbPhone.Text = "";
            txbSalary.Text = "";
            txbSearchAccount.Text = "";
            txbAdress.Text = "";
            cbb_role.Text = "";
            txbUserName.Text = "";
        }
        bool CheckForm_Account()
        {
            return (txbUserName.Text == "" || txbDisplayName.Text == "" || txbPhone.Text == "" || txbAdress.Text == "" || txbSalary.Text == "" || cbb_role.Text == "");

        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            string Name_Account = txbDisplayName.Text;
            txbUserName.ReadOnly = true;
            string User_Account = txbUserName.Text;
            string Phone = txbPhone.Text;
            string Salary = txbSalary.Text;
            string Adress = txbAdress.Text;
            string Role = cbb_role.Text;

            if (CheckForm_Account() == false)
            {
                if (bll.Add_Account(User_Account, Name_Account, Salary, Adress, Role))
                    MessageBox.Show("Đã thêm bàn thành công !", "Thông báo!");
                else
                    MessageBox.Show("Thêm Thất Bại", "Thông báo!");
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo!");
            }

            LoadDGV_Account();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            string Name_Account = txbDisplayName.Text;
            txbUserName.ReadOnly = true;
            string User_Account = txbUserName.Text;
            string Phone = txbPhone.Text;
            string Salary = txbSalary.Text;
            string Adress = txbAdress.Text;
            string Role = cbb_role.Text;

            if (CheckForm_Account() == false)
            {
                if (bll.UpdateAccount(User_Account, Name_Account, Salary, Phone, Adress, Role))
                    MessageBox.Show("Đã cập nhật tài khoản " + txbDisplayName.Text + " thành công !", "Thông báo!");
                else
                    MessageBox.Show("Cập Nhật Tài Khoản Thất Bại", "Thông báo!");
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo!");
            }
            LoadDGV_Account();
        }

        private void btnDelAccount_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();


            if (CheckForm_Account() == false)
            {
                if (bll.DeleteAccount(txbUserName.Text))
                    MessageBox.Show("Xóa tài khoản " + txbDisplayName.Text + " thành công !", "Thông báo!");
                else
                    MessageBox.Show("Xóa tài khoản Thất Bại", "Thông báo!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa", "Thông báo!");
            }
            LoadDGV_Account();
        }

        private void dataGridViewAcount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridViewAcount.CurrentRow.Index;
            txbUserName.Text = dataGridViewAcount.Rows[i].Cells[0].Value.ToString();
            txbDisplayName.Text = dataGridViewAcount.Rows[i].Cells[1].Value.ToString();
            txbSalary.Text = dataGridViewAcount.Rows[i].Cells[2].Value.ToString();
            txbAdress.Text = dataGridViewAcount.Rows[i].Cells[3].Value.ToString();
            txbPhone.Text = dataGridViewAcount.Rows[i].Cells[4].Value.ToString();
            cbb_role.Text = dataGridViewAcount.Rows[i].Cells[5].Value.ToString();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            if (dateStar.Value.Date <= dateEnd.Value.Date)
            {
                int SumPrice = 0;
                chart1.Series.Clear();
                chart1.Series.Add("Doanh Thu");
                foreach (Revenue i in bll.Get_Revenue(dateStar.Value.Date, dateEnd.Value.Date))
                {
                    chart1.Series["Doanh Thu"].Points.AddXY(i.day, i.price);
                    SumPrice += i.price;
                }
                txbRevenue.Text = SumPrice.ToString();
            }
            else
            {
                MessageBox.Show("Ngày thống kê bị mâu thuẩn!", "Thông báo");
            }
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            string Account_Name = txbSearchAccount.Text;
            if (Account_Name == "") // ALL 
            {
                LoadDGV_Account();
            }
            else
            {
                dataGridViewAcount.DataSource = bll.GetDGV_Account_Search(Account_Name);
            }
        }
        void LoadDGV_Product()
        {
            QLCFBLL bll = new QLCFBLL();
            dataGridViewProduct.DataSource = bll.GetDGV_Product();
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
        bool CheckForm_Product()
        {
            return (txbNameProduct.Text == "" || txbPriceProduct.Text == "");

        }
        private void btnAddProduct_Click(object sender, EventArgs e)
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
            MessageBox.Show("Đã xóa thành công !");
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            string Product_Name = txbSearchProduct.Text;
            if (Product_Name == "") // ALL 
            {
                LoadDGV_Product();
            }
            else
            {
                dataGridViewTable.DataSource = bll.GetDGV_Product_Search(Product_Name);
            }
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();

            HitTestResult result = chart1.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                string seriesName = result.Series.Name;
                string day = result.Series.Points[result.PointIndex].AxisLabel;
                if (seriesName == "Doanh Thu")
                {                   
                    datagridViewBillThongKe.DataSource = bll.GetDGV_Bill_Revenuve(DateTime.ParseExact(day, "d/M/yyyy", CultureInfo.InvariantCulture));
                }
                label_DateBill.Text =   "Danh sách hóa đơn ngày " + day;
            }
        }

        private void btnCheckBill_Click(object sender, EventArgs e)
        {
            
            if (id_Bill == -1)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn!", "Thông báo");
            } else
            {
                fBill_Detail f = new fBill_Detail(id_Bill);
                this.Hide();
                f.ShowDialog();
            }    
        } 

        private void datagridViewBillThongKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = datagridViewBillThongKe.CurrentRow.Index;
             id_Bill = Convert.ToInt32(datagridViewBillThongKe.Rows[i].Cells[0].Value);
        }
        int id_Bill=-1;

        private void fAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {

            reloadTable();
            reloadCBBCategory();
        }
    }
}
