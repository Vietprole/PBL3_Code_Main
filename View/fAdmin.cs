using PBL3CodeDemo.BLL;
using PBL3CodeDemo.DTO;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Status;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PBL3CodeDemo.View
{
    public partial class fAdmin : Form
    {
        CultureInfo culture = new CultureInfo("vi-VN");
        int id_Bill = -1;
        void LoadRevenue(DateTime dateStar, DateTime dateEnd)
        {
            QLCFBLL bll = new QLCFBLL();
            int SumPrice = 0;
            chart1.Series.Clear();
            chart1.Series.Add("Doanh Thu");
            foreach (Revenue i in bll.Get_Revenue(dateStar, dateEnd))
            {
                chart1.Series["Doanh Thu"].Points.AddXY(i.day, i.price);
                SumPrice += i.price;
            }
            txbRevenue.Text = SumPrice + " VND";
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
            dataGridViewTable.Columns[0].HeaderText = "Mã Bàn";
            dataGridViewTable.Columns[1].HeaderText = "Tên Bàn";
            dataGridViewTable.Columns[2].HeaderText = "Trạng Thái";
            dataGridViewTable.Columns[3].HeaderText = "Vị Trí";

            txbNameTable.Text = "";
            checkBoxStatus.Checked = false;
            int newWidth = 144; // Replace 200 with the desired width in pixels

            dataGridViewTable.Columns[0].Width = newWidth;
            dataGridViewTable.Columns[1].Width = newWidth;
            dataGridViewTable.Columns[2].Width = newWidth;
            dataGridViewTable.Columns[3].Width = 195;
        }
        void LoadDGV_Account()
        {
            QLCFBLL bll = new QLCFBLL();

            dataGridViewAcount.DataSource = bll.GetDGV_Account();
            dataGridViewAcount.Columns[0].HeaderText = "Tên Đăng Nhập";
            dataGridViewAcount.Columns[1].HeaderText = "Tên Hiển Thị";
            dataGridViewAcount.Columns[2].HeaderText = "Lương";
            dataGridViewAcount.Columns[3].HeaderText = "Địa Chỉ";
            dataGridViewAcount.Columns[4].HeaderText = "Số Điện Thoại";
            dataGridViewAcount.Columns[5].HeaderText = "Loại Tài Khoản";
            txbDisplayName.Text = "";
            txbUserName.ReadOnly = false;

            txbPhone.Text = "";
            txbSalary.Text = "";
            txbSearchAccount.Text = "";
            txbAdress.Text = "";
            cbb_role.Text = "";
            txbUserName.Text = "";
            int newWidth = 140; // Replace 200 with the desired width in pixels

            dataGridViewAcount.Columns[0].Width = newWidth;
            dataGridViewAcount.Columns[1].Width = newWidth;
            dataGridViewAcount.Columns[2].Width = newWidth;
            dataGridViewAcount.Columns[4].Width = newWidth;
            dataGridViewAcount.Columns[5].Width = newWidth;
        }



        bool CheckForm_Account()
        {
            return (txbUserName.Text == "" || txbDisplayName.Text == "" || txbPhone.Text == "" || txbAdress.Text == "" || txbSalary.Text == "" || cbb_role.Text == "");

        }

        public int Old_ID_Table { get; set; }
        string user;

        public fAdmin(string userName)
        {
            user = userName;

            InitializeComponent();
            setCBB_ViTriBan();
            LoadDGV_Table();
            LoadDGV_Account();
            LoadDGV_Product();
            setCBBCategory();
            LoadDGV_Item();
            QLCFBLL bll = new QLCFBLL();
            
            LoadRevenue(Convert.ToDateTime(" 01/01/2023"), dateEnd.Value.Date);
            LoadDGV_Shift("");
        }

        private void dataGridViewTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure the click was on a row and not on the column header
            {
                DataGridViewRow row = dataGridViewTable.Rows[e.RowIndex];
                txbNameTable.Text = row.Cells[1].Value.ToString();
                checkBoxStatus.Checked = Convert.ToBoolean(row.Cells[2].Value); // Transfer data of second column to TextBox2
                cbbPosition.Text = row.Cells[3].Value.ToString(); // Transfer data of third column to TextBox3
                Old_ID_Table = Convert.ToInt32(row.Cells[0].Value);
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
            string Table_Name = txbNameTable.Text;
            bool Status = checkBoxStatus.Checked;
            string Position = cbbPosition.Text;
            if (bll.UpdateTable(Old_ID_Table, Table_Name, Status, Position)) //Update Table thành công
            {
                MessageBox.Show("Đã cập nhật bàn thành công !");
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
                    MessageBox.Show("Đã thêm tài khoản thành công !", "Thông báo!");
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
            //txbUserName.ReadOnly = true;
            string User_Account = txbUserName.Text;
            string Phone = txbPhone.Text;
            string Salary = txbSalary.Text;
            string Adress = txbAdress.Text;
            string Role = cbb_role.Text;

            string SelectedUser_Account = dataGridViewAcount.SelectedRows[0].Cells[0].Value.ToString();
            if (CheckForm_Account() == false)
            {

                if (bll.UpdateAccount(SelectedUser_Account, User_Account, Name_Account, Salary, Phone, Adress, Role))
                  
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
                if (user == txbUserName.Text)
                {
                    MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Thông báo");
                }
                else if (bll.DeleteAccount(txbUserName.Text))
                {
                    MessageBox.Show("Xóa tài khoản " + txbDisplayName.Text + " thành công !", "Thông báo!");
                }

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
            //txbUserName.ReadOnly = true;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

            if (dateStar.Value.Date <= dateEnd.Value.Date)
            {
                LoadRevenue(dateStar.Value.Date, dateEnd.Value.Date);
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
            dataGridViewProduct.Columns[0].HeaderText = "Mã Món ăn";
            dataGridViewProduct.Columns[1].HeaderText = "Tên Món";
            dataGridViewProduct.Columns[2].HeaderText = "Giá";
            dataGridViewProduct.Columns[3].HeaderText = "Doanh mục";
            
            txbNameProduct.Text = "";
            txbPriceProduct.Text = "";

            int newWidth = 144; // Replace 200 with the desired width in pixels

            dataGridViewProduct.Columns[0].Width = newWidth;
            dataGridViewProduct.Columns[1].Width = newWidth;
            dataGridViewProduct.Columns[2].Width = newWidth;
            dataGridViewProduct.Columns[3].Width = newWidth;
        }
        private void setCBBCategory()
        {
            cbbCategory.Items.Clear();
            using (PBL3Entities db = new PBL3Entities())
            {
                foreach (Category i in db.Categories)
                {
                    if (i.Flag == true)
                    {
                        cbbCategory.Items.Add(new CBB_Item
                        {
                            Value = i.ID_Category,
                            Text = i.Category_Name
                        });
                    }
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

            if (CheckForm_Product() == false)
            {
                Product product = new Product
                {
                    Name = txbNameProduct.Text,
                    Price = int.Parse(txbPriceProduct.Text),
                    ID_Category = cbbCategory.SelectedIndex + 1,
                    Flag = true
                };
                if (bll.Add_Product(product))
                    MessageBox.Show("Đã thêm món ăn thành công !", "Thông báo!");
                else
                    MessageBox.Show("Thêm Thất Bại", "Thông báo!");
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo!");
            }
            LoadDGV_Product();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();

            if (CheckForm_Product() == false)
            {
                Product product = new Product
                {
                    ID_Product = int.Parse(dataGridViewProduct.SelectedRows[0].Cells[0].Value.ToString()),
                    Name = txbNameProduct.Text,
                    Price = int.Parse(txbPriceProduct.Text),
                    ID_Category = cbbCategory.SelectedIndex + 1,
                    Flag = true
                };
                if (bll.Edit_Product(product))
                    MessageBox.Show("Đã cập nhật món ăn thành công !", "Thông báo!");
                else
                    MessageBox.Show("Cập nhật Thất Bại", "Thông báo!");
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo!");
            }
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
                dataGridViewProduct.DataSource = bll.GetDGV_Product_Search(Product_Name);
            }
        }
        void LoadDGV_Item()
        {
            QLCFBLL bll = new QLCFBLL();
            dataGridViewAccount.DataSource = bll.GetDGV_Item();
            dataGridViewAccount.Columns[0].HeaderText = "Mã Mặt Hàng";
            dataGridViewAccount.Columns[1].HeaderText = "Tên Mặt Hàng";
            dataGridViewAccount.Columns[2].HeaderText = "Doanh mục";
            dataGridViewAccount.Columns[3].HeaderText = "Số Lượng";
            dataGridViewAccount.Columns[4].HeaderText = "Đơn vị";
            
            txbNameItem.Text = "";
            txbCategoryItem.Text = "";
            txbQuantityItem.Text = "";
            txbUnitItem.Text = "";

            int newWidth = 125; // Replace 200 with the desired width in pixels

            dataGridViewAccount.Columns[0].Width = newWidth;
            dataGridViewAccount.Columns[1].Width = newWidth;
            dataGridViewAccount.Columns[2].Width = newWidth;
            dataGridViewAccount.Columns[3].Width = newWidth;
            dataGridViewAccount.Columns[4].Width = newWidth;
        }
        bool CheckForm_Item()
        {
            return (txbNameItem.Text == "" || txbCategoryItem.Text == "" || txbQuantityItem.Text == "" || txbUnitItem.Text == "");
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();

            if (CheckForm_Item() == false)
            {
                Item item = new Item
                {
                    Name = txbNameItem.Text,
                    Category = txbCategoryItem.Text,
                    Quantity = double.Parse(txbQuantityItem.Text),
                    Unit = txbUnitItem.Text,
                    Flag = true
                };
                if (bll.Add_Item(item))
                    MessageBox.Show("Đã thêm hàng hóa thành công !", "Thông báo!");
                else
                    MessageBox.Show("Thêm Thất Bại", "Thông báo!");
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo!");
            }
            LoadDGV_Item();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();

            if (CheckForm_Item() == false)
            {
                Item item = new Item
                {
                    ID_Item = int.Parse(dataGridViewAccount.SelectedRows[0].Cells[0].Value.ToString()),
                    Name = txbNameItem.Text,
                    Category = txbCategoryItem.Text,
                    Quantity = double.Parse(txbQuantityItem.Text),
                    Unit = txbUnitItem.Text,
                    Flag = true
                };
                if (bll.Edit_Item(item))
                    MessageBox.Show("Đã cập nhật hàng hóa thành công !", "Thông báo!");
                else
                    MessageBox.Show("Cập nhật Thất Bại", "Thông báo!");
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo!");
            }
            LoadDGV_Item();
        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(dataGridViewAccount.SelectedRows[0].Cells[0].Value.ToString());
            QLCFBLL bll = new QLCFBLL();
            bll.Delete_Item(ID);
            LoadDGV_Item();
            MessageBox.Show("Đã xóa thành công !");
        }

        private void btnSearchItem_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            string Item_Name = txbSearchItem.Text;
            if (Item_Name == "") // ALL 
            {
                LoadDGV_Item();
            }
            else
            {
                dataGridViewAccount.DataSource = bll.GetDGV_Item_Search(Item_Name);
            }
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();

            HitTestResult result = chart1.HitTest(e.X, e.Y);

            string day = result.Series.Points[result.PointIndex].AxisLabel;
            datagridViewBillThongKe.DataSource = bll.GetDGV_Bill_Revenuve(DateTime.ParseExact(day, "d/M/yyyy", CultureInfo.InvariantCulture));
            datagridViewBillThongKe.Columns[0].HeaderText = "Mã Hóa Đơn";
            datagridViewBillThongKe.Columns[1].HeaderText = "Giờ Thanh Toán";
            datagridViewBillThongKe.Columns[2].HeaderText = "Tổng Giá";
            datagridViewBillThongKe.Columns[3].HeaderText = "Tên Bàn";
            label_DateBill.Text = "Danh sách hóa đơn ngày " + day;

        }

        private void btnCheckBill_Click(object sender, EventArgs e)
        {

            if (id_Bill == -1)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn!", "Thông báo");
            }
            else
            {
                fBill_Detail f = new fBill_Detail(id_Bill, user);
                this.Hide();
                f.ShowDialog();
            }
        }

        private void datagridViewBillThongKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = datagridViewBillThongKe.CurrentRow.Index;
            id_Bill = Convert.ToInt32(datagridViewBillThongKe.Rows[i].Cells[0].Value);
        }
        private void fAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {

            //reloadTable();
            //reloadCBBCategory();
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    _fTableManager.Refresh(); // or any other method to reload Form1
            //}
        }
        private void btnAddTable_Click_1(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            string Table_Name = txbNameTable.Text;
            bool Status = checkBoxStatus.Checked;
            string Position = cbbPosition.Text;
            LoadDGV_Table();
            if (Table_Name != "")
            {
                if (bll.Add_Table(Table_Name, Status, Position)) //Update Table thành công
                {
                    MessageBox.Show("Đã cập nhật bàn thành công !");
                }
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin", "Thông báo!");
            }
            LoadDGV_Table();
        }
        private void txbPriceProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbQuantityItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridViewProduct.CurrentRow.Index;
            txbNameProduct.Text = dataGridViewProduct.Rows[i].Cells[1].Value.ToString();
            txbPriceProduct.Text = dataGridViewProduct.Rows[i].Cells[2].Value.ToString();
            cbbCategory.Text = dataGridViewProduct.Rows[i].Cells[3].Value.ToString();
            //txbNameProduct.ReadOnly = true;
        }

        private void dataGridViewItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridViewAccount.CurrentRow.Index;
            txbNameItem.Text = dataGridViewAccount.Rows[i].Cells[1].Value.ToString();
            txbCategoryItem.Text = dataGridViewAccount.Rows[i].Cells[2].Value.ToString();
            txbQuantityItem.Text = dataGridViewAccount.Rows[i].Cells[3].Value.ToString();
            txbUnitItem.Text = dataGridViewAccount.Rows[i].Cells[4].Value.ToString();
            //txbNameItem.ReadOnly = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            QLCFBLL bll = new QLCFBLL();
            if (CheckForm_Account() == false)
            {

                if (bll.UpdateAccount_PassWord(user, "123"))
                {
                    MessageBox.Show("Đặt lại mật khẩu mặt định cho tài khoản " + bll.SetAcountName(user) + " thành công !", "Thông báo!");

                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Chọn 1 Tài Khoản", "Thông báo!");
            }
            LoadDGV_Account();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            if (CheckForm_Account() == false)
            {
                View.fShiftAssignment f = new fShiftAssignment(txbUserName.Text);
                f.d += LoadDGV_Shift;
                f.ShowDialog();

            }
            else
            {
                MessageBox.Show("Chọn 1 Tài Khoản", "Thông báo!");
            }

        }
        private void LoadDGV_Shift(string txt)
        {
            QLCFBLL bll = new QLCFBLL();
            foreach(DataGridView i in tabPage6.Controls.OfType<DataGridView>())
            {
                i.DataSource = bll.GetDGV_AssignedShift(int.Parse(i.Name[8].ToString()), int.Parse(i.Name[4].ToString()));//dgvT2_Ca1
                i.RowHeadersVisible = false;
                i.ColumnHeadersVisible = false;
                i.ScrollBars = ScrollBars.None;
                i.Columns[0].Width = 130;
            }
        }

        private void btt_Edit_DoanhMuc_Click(object sender, EventArgs e)
        {
            View.FormEditDoanhMuc a = new View.FormEditDoanhMuc();
            a.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxDisplayUnassigned.Checked == true)
            {
                LoadDGV_ShiftWithUnassigned();
            }
            if (checkboxDisplayUnassigned.Checked == false)
            {
                LoadDGV_Shift("");
            }
        }

        private void LoadDGV_ShiftWithUnassigned()
        {
            QLCFBLL bll = new QLCFBLL();
            foreach (DataGridView i in tabPage6.Controls.OfType<DataGridView>())
            {
                i.DataSource = bll.GetDGV_Shift(int.Parse(i.Name[8].ToString()), int.Parse(i.Name[4].ToString()));//dgvT2_Ca1
                foreach(DataGridViewRow j in i.Rows)
                {
                    if ((bool)j.Cells[1].Value == false)
                    {
                        j.Cells[0].Style.BackColor = Color.Red;
                        j.Cells[0].Style.SelectionBackColor = Color.Red;
                    }
                }
                i.RowHeadersVisible = false;
                i.ColumnHeadersVisible = false;
                i.ScrollBars = ScrollBars.None;
                i.Columns[0].Width = 130;
            }
        }
    }
}