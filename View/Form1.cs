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

namespace PBL3CodeDemo
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Bạn Muốn Thoát Ứng Dụng?", "Thông báo!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            } 

        }
        
        bool checkForm()
        {   
            if(txbUserName.Text =="" ||txbPassWord.Text == "")
            {
                return true;
            }
            return false;
        }
        private void Login_Click(object sender, EventArgs e)
        {

            if(checkForm()==true) 
            {
                MessageBox.Show("Vui lòng nhập thông tin Tài Khoản và Mật Khẩu!","Thông Báo");
            }
            else
             {   
                 QLCFBLL bll = new QLCFBLL();
                if (bll.CheckAcount(txbUserName.Text,txbPassWord.Text) == true)
                {
                    View.fTableManager a = new View.fTableManager(txbUserName.Text, txbPassWord.Text);
                    a.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng thông tin đăng nhập!", "Thông Báo");
                }

                
            }
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {   
            if(checkBoxShowPass.Checked == true)
            {
                txbPassWord.UseSystemPasswordChar = false;
            }
            else 
            {
                txbPassWord.UseSystemPasswordChar = true;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
