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
        

        private void Login_Click(object sender, EventArgs e)
        {
            View.fTableManager a = new View.fTableManager();
            a.ShowDialog();
            this.Close();
        }
    }
}
