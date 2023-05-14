using PBL3CodeDemo.BLL;
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

namespace PBL3CodeDemo.View
{
    public partial class fBillCheckOut : Form
    {
        QLCFBLL bll = new QLCFBLL();
        CultureInfo culture = new CultureInfo("vi-VN");
        public fBillCheckOut(string user, int idTable, int discount)
        {
            InitializeComponent();
            setNameAccount(user);
            loadDatagridviewBillDetail(bll.getIdBillByIdTable(idTable));
            setNamTable(idTable);
            setDate(bll.getIdBillByIdTable(idTable));
            setDiscount(discount);
            setTotal(bll.getIdBillByIdTable(idTable));
            setTotalLast(bll.getIdBillByIdTable(idTable), discount);
            
        }


        void setTotal(int idBill)
        {
            int SumPrice = Convert.ToInt32(bll.SetTotalBill(idBill));
            labeltotalBill.Text = "Tổng giá :" + SumPrice.ToString("c", culture);
        }
        void setTotalLast(int idBill, int discount)
        {
            int SumPrice = Convert.ToInt32(bll.SetTotalBill(idBill));
            SumPrice = SumPrice - SumPrice * discount / 100;
            labelTotalLast.Text = "Còn lại: " + SumPrice.ToString("c", culture);
        }
        void setDiscount(int discount)
        {
            labelDiscount.Text = "Giảm Giá: " + discount + "%";
        }
        void setDate(int idBill)
        {
            //string day = bll.SetDateOrderByIDBill(idBill);
            //DateTime dateTime = DateTime.ParseExact(day, "dd/MM/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            //string datePart = dateTime.ToString("'Đà Nẵng, Ngày' dd 'Tháng' MM 'Năm' yyyy", CultureInfo.GetCultureInfo("vi-VN"));
            //string timePart = dateTime.ToString("'Thời gian:' HH 'giờ' mm 'phút'");
          
            labelTime.Text = bll.SetDateOrderByIDBill(idBill);

        }

        void setNamTable(int idTable)
        {
            labelNameTable.Text = "Bàn " + idTable;
        }
        void setNameAccount(string user)
        {
            labelNameAccount.Text = bll.SetNameAcount(user);
        }
        void loadDatagridviewBillDetail(int id_bill)
        {
            dataGridView_BillDetail.DataSource = bll.GetDGV_Bill_Detail(id_bill);
            dataGridView_BillDetail.Columns[0].HeaderText = "Tên Nước";
            dataGridView_BillDetail.Columns[1].HeaderText = "Số Lượng";
            dataGridView_BillDetail.Columns[2].HeaderText = "Đơn Giá";
            dataGridView_BillDetail.Columns[3].HeaderText = "Thành Tiền";

        }

        private void labelNameTable_Click(object sender, EventArgs e)
        {

        }
    }
}
