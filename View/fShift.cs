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

    public partial class fShift : Form
    {
        string userName;
        QLCFBLL bll = new QLCFBLL();
        public fShift(string User)
        {
            InitializeComponent();
            userName = User;
            this.Text ="Đăng ký ca làm - "+ bll.SetAcountName(User);
            LoadCheckBox();
        }
        private void LoadCheckBox()
        {
            foreach (Shift i in bll.Return_ShiftByUserID(userName))
            {
                foreach (CheckBox j in this.Controls.OfType<CheckBox>())
                {
                    if (int.Parse(j.Name[7].ToString()) == i.ShiftNumber &&
                        int.Parse(j.Name[3].ToString()) == i.Date &&
                        i.FlagAssigned == true)//Duyet roi

                    {
                        j.Checked = true;
                        j.Enabled = false;
                        j.ForeColor = System.Drawing.Color.Gray;
                    }
                    if (int.Parse(j.Name[7].ToString()) == i.ShiftNumber &&
                        int.Parse(j.Name[3].ToString()) == i.Date &&
                        i.FlagAssigned == false)//Chua duyet 

                    {
                        j.Checked = true;
                        j.Enabled = true;
                    }
                }
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (CheckBox i in this.Controls.OfType<CheckBox>())
            {
                if (i.Checked == true)
                {
                    Shift shift = new Shift
                    {
                        IdAccount = bll.Return_IDAccount(userName),
                        ShiftNumber = int.Parse(i.Name[7].ToString()), //tên checkbox có dạng CbT2_Ca1 nên phần tử thứ 7 là thứ tự ca
                        Date = int.Parse(i.Name[3].ToString()), //Tương tự, phần tử thứ 3 là ngày của ca làm trong tuần
                        FlagAssigned = false //Mới đăng ký, chưa phân công
                    };
                    //lưu ý i.Name[] có kiểu dữ liệu là char nên sẽ ra mã ASCII nếu chuyển đổi theo cách thông thường,
                    //nên dùng ToString() trước khi chuyển kiểu int.Parse()
                    if (bll.Add_Selected_Shift(shift))
                        Debug.Write("Truyền ca làm " + i.Name[7] + ", ngày thứ " + i.Name[3] + " thành công");
                    else
                        Debug.Write("Truyền ca làm " + i.Name[7] + ", ngày thứ " + i.Name[3] + " thất bại");
                }
                if (i.Checked == false)
                {
                    //MessageBox.Show("Duyet " + i.Name);
                    Shift shift = new Shift
                    {
                        IdAccount = bll.Return_IDAccount(userName),
                        ShiftNumber = int.Parse(i.Name[7].ToString()), 
                        Date = int.Parse(i.Name[3].ToString()), 
                        FlagAssigned = false 
                    };
                    //Debug.Write(" Tao new Shift thanh cong ");
                    if (bll.CheckShift(shift))
                    {
                        //Debug.Write("Shift " + i.Name + " can delete");
                        bll.DeleteShift(shift);
                    }

                }
            }
            MessageBox.Show("Đăng ký ca làm thành công", "Thông báo!");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
