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
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
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
            View.fAccountProfile a = new View.fAccountProfile();    
            a.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.ChangePassWord a = new ChangePassWord();
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

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.fAdmin a = new View.fAdmin();
            a.Show();
        }
    }
}
