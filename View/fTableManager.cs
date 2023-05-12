using PBL3CodeDemo.BLL;
using PBL3CodeDemo.DTO;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3CodeDemo.View
{
    public partial class fTableManager : Form
    {
        public fTableManager(string use, string pass)
        {
            InitializeComponent();
            useName = use;
            passWord = pass;
            setNameForm(useName);
            LoadTable();
            setCBBCategory();
            textBoxPrice.Text = "0";
        }
        void setCBBCategory()
        {
            QLCFBLL bll = new QLCFBLL();

            cbCategory.DataSource = bll.GetCBB_Category().ToArray();
        }
        void setCBBFood(int ID_Category)
        {
            QLCFBLL bll = new QLCFBLL();
            cbFood.DataSource = bll.GetCBB_Food(ID_Category).ToArray();

        }


        string useName;
        string passWord;

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Thoát Ứng Dụng?", "Thông báo!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.fAccountProfile a = new View.fAccountProfile(useName, passWord);

            a.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.ChangePassWord a = new ChangePassWord(useName, passWord);

            a.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Đăng Xuất Ứng Dụng?", "Thông báo!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Hide();
            }

            fLogin a = new fLogin();
            a.ShowDialog();
            this.Close();
        }
        QLCFBLL bll = new QLCFBLL();
        void setNameForm(string user)
        {
            this.Text = bll.SetNameAcount(user);
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bll.CheckAcount_Role(useName) == 1)
            {
                View.fAdmin a = new View.fAdmin();
                a.reloadTable += new fAdmin.ReLoadFTableManager(LoadTable);
                a.reloadCBBCategory += new fAdmin.ReLoadFTableManager(setCBBCategory);
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tài khoản này không có chức năng quản lý!", "Thông báo");
            }

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (BillTable_DGV.DataSource == null)
            {
                MessageBox.Show("Hóa đơn chưa có sản phẩm, vui lòng thêm ít nhất 1 sản phẩm để thanh toán", "Thông báo");
            }
            else
            {

                int Price = Convert.ToInt32(textBoxPrice.Text);
                int idTable = Convert.ToInt32(id_Table_Last_Pressed.Text);
                if (bll.CheckAcount_Role(useName) == 1 || bll.CheckAcount_Role(useName) == 2)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc là muốn thanh toán không ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        bll.CheckOut_Bill(idTable, Price);
                        ShowBill(idTable);
                        bll.SetTableStatus(idTable, 0);
                        LoadTable();
                        nmDisCount.Value = 0;
                    }
                    else if (result == DialogResult.No)
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản nhân viên không có chức năng thanh toán!", "Thông báo");
                }

            }

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            setCBBFood(Convert.ToInt32(cbCategory.SelectedIndex) + 1);

        }

        private void LoadTable()
        {
            flbTable.Controls.Clear();
            string s;
            List<TableDataGridView> list_table = bll.LoadTable_Button();
            foreach (TableDataGridView table in list_table)
            {
                Button btn = new Button()
                {
                    Width = 100,
                    Height = 100
                };
                if (table.Status == true)
                {
                    s = "Có người";
                }
                else s = "Trống";
                btn.Text = table.Name.ToString() + Environment.NewLine + Environment.NewLine + s;
                btn.Click += btn_Click;
                btn.Tag = table;
                switch (table.Status.ToString())
                {
                    case "False":
                        btn.BackColor = Color.Aqua; break;
                    default:
                        btn.BackColor = Color.LightPink; break;
                }
                flbTable.Controls.Add(btn);
            }

        }
        private void ShowBill(int id_Table)
        {
            int Price = 0;
            List<Bill_DetailDatagridview> list_Bill = new List<Bill_DetailDatagridview>();
            list_Bill = bll.Get_Bill_Detail(id_Table);
            if (list_Bill.Count > 0)
            {
                BillTable_DGV.DataSource = list_Bill;
                foreach (Bill_DetailDatagridview bill_details in list_Bill)
                {
                    Price += bill_details.unit_price;
                }
                textBoxPrice.Text = Price.ToString();
            }
            else
            {
                BillTable_DGV.DataSource = null;
                bll.SetTableStatus(id_Table, 0);
                textBoxPrice.Text = "0";
            }

        }
        void btn_Click(object sender, EventArgs e)
        {
            int table_ID = ((sender as Button).Tag as TableDataGridView).ID_Table;
            id_Table_Last_Pressed.Text = table_ID.ToString();
            ShowBill(table_ID);
            setCBBSwitchTable(table_ID);
        }

        private void setCBBSwitchTable(int table_ID)
        {
            QLCFBLL bll = new QLCFBLL();
            cbSwithTable.DataSource = bll.GetCBB_Table(table_ID).ToArray();
        }


        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string foodName = cbFood.Text;
            int Quantity = Convert.ToInt32(nmFoodCount.Value);
            int idTable = Convert.ToInt32(id_Table_Last_Pressed.Text);
            bll.Add_Food_ToTable(idTable, foodName, Quantity);
            bll.SetTableStatus(idTable, 1);
            ShowBill(idTable);
            LoadTable();
        }

        private void bttDeleteFood_Click(object sender, EventArgs e)
        {
            string foodName = "";
            int Quantity = 0;
            int idTable = Convert.ToInt32(id_Table_Last_Pressed.Text);
            if (BillTable_DGV.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc là muốn xóa món này không ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in BillTable_DGV.SelectedRows)
                    {
                        foodName = row.Cells["NameSP"].Value.ToString();
                        Quantity = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                        bll.Delete_BillDetails(idTable, foodName, Quantity);
                    }
                    ShowBill(idTable);
                    LoadTable();
                }
                else if (result == DialogResult.No)
                {
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 món để xóa", "Thông báo");
            }

        }
        private void ResetPrice(int id_Table)
        {
            int Price = 0;
            List<Bill_DetailDatagridview> list_Bill = new List<Bill_DetailDatagridview>();
            list_Bill = bll.Get_Bill_Detail(id_Table);
            if (list_Bill.Count > 0)
            {
                BillTable_DGV.DataSource = list_Bill;
                foreach (Bill_DetailDatagridview bill_details in list_Bill)
                {
                    Price += bill_details.unit_price;
                }
                textBoxPrice.Text = Price.ToString();
            }

        }
        private void DisCount()
        {
            int idTable = Convert.ToInt32(id_Table_Last_Pressed.Text);
            int discount = Convert.ToInt32(nmDisCount.Value);
            ResetPrice(idTable);
            int Price = Convert.ToInt32(textBoxPrice.Text);
            Price = Price - Price * discount / 100;
            textBoxPrice.Text = Price.ToString();
        }
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            DisCount();
        }

        private void btnSwithTable_Click(object sender, EventArgs e)
        {
            string newTableName = cbSwithTable.Text;
            int idTable = Convert.ToInt32(id_Table_Last_Pressed.Text);
            bll.SwitchTable(idTable, newTableName);
            //Gán NewIDTable = newIDTable
            //Chuyển tất cả các món sang bàn đã chọn
            ShowBill(idTable);//Bill của bàn cũ lúc này sẽ trống
            bll.SetTableStatus(idTable, 0);
            LoadTable();

        }
    }
}
