using PBL3CodeDemo.BLL;
using PBL3CodeDemo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3CodeDemo.View
{
    public partial class fBill_Detail : Form
    {
        int ID;
        string nameSP = "";
        QLCFBLL bll = new QLCFBLL();
        string useName;
        public fBill_Detail(int id_bill, string use)
        {   
            useName = use;
            InitializeComponent();
            loadDatagridviewBillDetail(id_bill);
            
            setCBBCategory();
           
            setCBB_Tablet( bll.SetIDTableByIDBill(id_bill));
            setDateOrderByIDBill(id_bill);
            setTimeOrderByIDBill(id_bill);
           
            ID = id_bill;
        }
       
        void setCBB_Tablet(int i)
        {
            QLCFBLL bll = new QLCFBLL();
            cbb_Table.Items.AddRange(bll.GetCBB_TableName().ToArray());
            cbb_Table.Text = "Bàn " + i + "";
        }
        void setDateOrderByIDBill(int idbll)
        {
            DateOrder.Text =bll.SetDateOrderByIDBill(idbll);
        }
        void setTimeOrderByIDBill(int idbll)
        {
            txbTimeOrder.Text = bll.SetTimeDBill(idbll);
        }
        void setTotalByIDBill(int idBill)
        {          
            txbTotal_Bill.Text = bll.SetTotalBill(idBill);
        }
        void loadDatagridviewBillDetail(int id_bill)
        {
            dataGridView_BillDetail.DataSource = bll.GetDGV_Bill_Detail(id_bill);
            setTotalByIDBill(id_bill);
            dataGridView_BillDetail.Columns[0].HeaderText = "Tên Nước";
            dataGridView_BillDetail.Columns[1].HeaderText = "Số Lượng";
            dataGridView_BillDetail.Columns[2].HeaderText = "Đơn Giá";
            dataGridView_BillDetail.Columns[3].HeaderText = "Thành Tiền";

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
        

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            setCBBFood(Convert.ToInt32(cbCategory.SelectedIndex) + 1);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {   
            
            bll.Add_Food(ID,cbFood.Text);

            dataGridView_BillDetail.DataSource = bll.GetDGV_Bill_Detail(ID);
            nameSP = "";
            label_Status_Total.Text = "Đã lưu";
            int sum = 0;
            foreach (DataGridViewRow row in dataGridView_BillDetail.Rows)
            {
               
                int Total = Convert.ToInt32( row.Cells["Total"].Value);

                sum += Total;
            }
            txbTotal_Bill.Text = sum.ToString();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
           
            
            if(nameSP == "")
            {
                MessageBox.Show("Chọn sản phẩm cần xóa!", "Thông báo!");

            }
            else
            {
                bll.Delete_Food(ID, nameSP);
                dataGridView_BillDetail.DataSource = bll.GetDGV_Bill_Detail(ID);
            }

            nameSP = "";
            

            label_Status_Total.Text = "Đã lưu";
            int sum = 0;
            foreach (DataGridViewRow row in dataGridView_BillDetail.Rows)
            {

                int Total = Convert.ToInt32(row.Cells["Total"].Value);

                sum += Total;
            }
            txbTotal_Bill.Text = sum.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin(useName);
            this.Hide();
            f.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (bll.UpdateBill(ID,txbTotal_Bill.Text,DateOrder.Text, txbTimeOrder.Text, cbb_Table.Text))
            {
                this.Hide();
                fAdmin f = new fAdmin(useName);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin hóa đơn thành công!", "Thông báo");
            }
        }

        private void dataGridView_BillDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView_BillDetail.CurrentRow.Index;
            nameSP = Convert.ToString(dataGridView_BillDetail.Rows[i].Cells[0].Value);
        }

       
    }
}
