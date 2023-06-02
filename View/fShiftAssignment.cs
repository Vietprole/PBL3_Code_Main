using PBL3CodeDemo.BLL;
using PBL3CodeDemo.DTO;
using System;
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
    public partial class fShiftAssignment : Form
    {
        public delegate void MyDel(string txt);
        public MyDel d { get; set; }
        string userName;
        QLCFBLL bll = new QLCFBLL();
        public fShiftAssignment( string user)
        {
            InitializeComponent();
            userName = user;
            this.Text = "Phân Công Ca làm cho - " + bll.SetAcountName(user) ;
            LoadCheckBox();
            LoadRecommend();
        }
        //tên checkbox có dạng CbT2_Ca1 nên phần tử thứ 7 là thứ tự ca
        //Tương tự, phần tử thứ 3 là ngày của ca làm trong tuần
        //Lưu ý i.Name[] có kiểu dữ liệu là char nên sẽ ra mã ASCII nếu chuyển đổi theo cách thông thường,
        //nên dùng ToString() trước khi chuyển kiểu int.Parse()
        private void LoadCheckBox()
        {
            foreach (Shift i in bll.Return_ShiftByUserID(userName))
            {
                foreach(CheckBox j in this.Controls.OfType<CheckBox>())
                {
                    if(int.Parse(j.Name[7].ToString()) == i.ShiftNumber && 
                        int.Parse(j.Name[3].ToString()) == i.Date)
                    {
                        j.Checked = true;
                    }
                }
            }
        }
        //tên label có dạng LabelT1 nên phần tử thứ 6 là ngày của ca trong tuần
        //Lưu ý i.Name[] có kiểu dữ liệu là char nên sẽ ra mã ASCII nếu chuyển đổi theo cách thông thường,
        //nên dùng ToString() trước khi chuyển kiểu int.Parse()
        private void LoadRecommend()
        {
            foreach (Shift i in bll.Return_ShiftByUserID(userName))
            {
                foreach (Label j in this.Controls.OfType<Label>())
                {
                    if (j.Name.Contains("T"))
                    {
                        if (int.Parse(j.Name[6].ToString()) == i.Date)
                        {
                            j.Text += "Ca " + i.ShiftNumber + ", ";
                        }
                    }
                }
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (CheckBox i in this.Controls.OfType<CheckBox>())
            {
                if (i.Checked == true)
                {
                    count++;
                    Shift shift = new Shift
                    {
                        IdAccount = bll.Return_IDAccount(userName),
                        ShiftNumber = int.Parse(i.Name[7].ToString()), //tên checkbox có dạng CbT2_Ca1 nên phần tử thứ 7 là thứ tự ca
                        Date = int.Parse(i.Name[3].ToString()), //Tương tự, phần tử thứ 3 là ngày của ca làm trong tuần
                        FlagAssigned = true //Đã phân công
                    };
                    //lưu ý i.Name[] có kiểu dữ liệu là char nên sẽ ra mã ASCII nếu chuyển đổi theo cách thông thường,
                    //nên dùng ToString() trước khi chuyển kiểu int.Parse()
                    if (bll.Assign_Selected_Shift(shift))
                        Debug.Write("Truyền ca làm " + i.Name[7] + ", ngày thứ " + i.Name[3] + " thành công");
                    else
                        Debug.Write("Truyền ca làm " + i.Name[7] + ", ngày thứ " + i.Name[3] + " thất bại");
                }
            }
            if (count == 0)
            {
                MessageBox.Show("Bạn chưa chọn ca làm nào", "Thông báo!");
            }
            else MessageBox.Show("Phân công ca làm thành công", "Thông báo!");
            d("");
        }
    }
}
