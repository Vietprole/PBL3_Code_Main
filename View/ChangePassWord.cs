using PBL3CodeDemo.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3CodeDemo.View
{
    public partial class ChangePassWord : Form
    {
        public ChangePassWord( string user, string pass)
        {
            InitializeComponent();
            userName= user;
            passWord= pass;
            txbDisplayName.Text = bll.SetAcountName(user);
            txbUserName.Text = userName; 
        }
        string userName;
        string passWord;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        QLCFBLL bll = new QLCFBLL();
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (txbPassWord.Text == "" || txbNewPass.Text == "" || txbReEnterPass.Text == "")
            {
                MessageBox.Show("Vui lòng không bỏ trống!", "Thông báo");
            }
            else 
            if (txbNewPass.Text == txbReEnterPass.Text )
            {
                if (bll.UpdateAccount( userName, bll.SetAcountName(userName), bll.SetAcountSalary(userName), bll.SetAcountPhone(userName), bll.SetAcountAddress(userName), txbNewPass.Text, bll.CheckAcount_Role(userName).ToString()) && txbPassWord.Text == passWord)
                {
                    MessageBox.Show("Đã cập nhật mật khẩu của tài khoản " + bll.SetAcountName(userName) + " thành công !", "Thông báo!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mật khẩu trùng khớp!", "Thông báo");
            }

            
        }
    }
}
