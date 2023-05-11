using PBL3CodeDemo.BLL;
using PBL3CodeDemo.DTO;
using System;
using System.CodeDom.Compiler;
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
    public partial class fTableManager : Form
    {
        string useName;
        string passWord;
        QLCFBLL bll = new QLCFBLL();
        void setNameForm(string user)
        {
            this.Text = bll.SetNameAcount(user);
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
        public fTableManager( string use, string pass)
        {
            InitializeComponent();
            useName = use;
            passWord = pass;
            setNameForm(useName);            
            setCBBCategory();            
        }
       
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Thoát Ứng Dụng?", "Thông báo!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.fAccountProfile a = new View.fAccountProfile( useName, passWord);
           
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
                fLogin a = new fLogin();
                a.ShowDialog();
                
            }
            
        }
       
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bll.CheckAcount_Role(useName) == 1)
            {
                View.fAdmin a = new View.fAdmin(useName);
               
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tài khoản này không có chức năng quản lý!","Thông báo");
            }

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if(bll.CheckAcount_Role(useName) == 1 || bll.CheckAcount_Role(useName) == 2)
            {
                //thanh toan
            }
            else
            {
                MessageBox.Show("Tài khoản nhân viên không có chức năng thanh toán!", "Thông báo");
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {   

            setCBBFood(Convert.ToInt32(cbCategory.SelectedIndex) + 1);
            
        }

        private void thanhToánCtrlShiftTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // điền chức năng Thanh Toán
        }

        private void chuyểnBànCtrlShiftTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Chức năng Chuyển bàn
        }

        private void ctrlShiftTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chức năng thêm món
        }
    }
}
