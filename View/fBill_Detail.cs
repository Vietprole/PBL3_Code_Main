using PBL3CodeDemo.BLL;
using PBL3CodeDemo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3CodeDemo.View
{
    public partial class fBill_Detail : Form
    {
        public fBill_Detail()
        {
            InitializeComponent();
        }
         int ID;
        QLCFBLL bll = new QLCFBLL();
        public fBill_Detail(int id_bill)
        {
            InitializeComponent();
            loadDatagridviewBillDetail(id_bill);
            
            setCBBCategory();
            setCBBTableByIdBill(id_bill);
            
            setDateOrderByIDBill(id_bill);
            setTimeOrderByIDBill(id_bill);
            CheckStatus(id_bill);
            ID = id_bill;
        }
        void setCBB_NameTable()
        {
            QLCFBLL bll = new QLCFBLL();
            cbb_Table.Items.AddRange(bll.GetCBB_TableName().ToArray());
            cbb_Table.SelectedIndex = 0;
        }
        void setCBBTableByIdBill(int idbll)
        {
            cbb_Table.Text= bll.SetNameTableByIDBill(idbll);
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
        void CheckStatus(int idBill)
        {
            if (bll.CheckStatusByIdBll(idBill))
            {
                radioButtonTrue.Checked = true;
            }
            else
            {
                radioButtonfalse.Checked = true;
            }
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
        string nameSP = "";
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
            fAdmin f = new fAdmin();
            this.Hide();
            f.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (bll.UpdateBill(ID,txbTotal_Bill.Text,DateOrder.Text, txbTimeOrder.Text, cbb_Table.Text, radioButtonTrue.Checked))
            {
                this.Hide();
                fAdmin f = new fAdmin();
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

        private void cbb_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
