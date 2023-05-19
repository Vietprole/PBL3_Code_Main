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
    public partial class fShiftAssignment : Form
    {
        string userName;
        QLCFBLL bll = new QLCFBLL();
        public fShiftAssignment( string user)
        {
            InitializeComponent();
            userName = user;
            this.Text = "Phân Công Ca làm cho - " + bll.SetAcountName(user) ;
        }
    }
}
