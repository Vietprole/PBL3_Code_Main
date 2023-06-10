using PBL3CodeDemo.BLL;
using PBL3CodeDemo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3CodeDemo.View
{
    public partial class fAccountProfile : Form
    {   
        QLCFBLL bll = new QLCFBLL();
        public fAccountProfile(string user, string pass)
        {
            
            InitializeComponent();
            userName = user;
            passWord= pass;
            txbUserName.Text = userName;
            txbDisplayName.Text = bll.SetAcountName(user);
            txbPhone.Text = bll.SetAcountPhone(user);
            txbSalary.Text=bll.SetAcountSalary(user);
            txbAdress.Text= bll.SetAcountAddress(user);
            this.Text=" Cập nhật thông tin - "+ bll.SetAcountName(user);
        }
        
         string userName;
        string passWord;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string selectedUserName = txbDisplayName.Text;
            if (bll.UpdateAccount(selectedUserName, txbUserName.Text, txbDisplayName.Text, txbSalary.Text,txbPhone.Text, txbAdress.Text, bll.CheckAcount_Role(userName).ToString()))
            {   
                bll.UpdateAccount_PassWord(userName, passWord); 
                MessageBox.Show("Đã cập nhật tài khoản " + txbDisplayName.Text + " thành công !", "Thông báo!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật Không thành công!", "Thông báo");
            }
        }
    }
}
