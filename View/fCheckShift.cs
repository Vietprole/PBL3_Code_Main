using PBL3CodeDemo.BLL;
using PBL3CodeDemo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PBL3CodeDemo.View
{
    public partial class fCheckShift : Form
    {
        string userName;
        QLCFBLL bll = new QLCFBLL();
        public fCheckShift( string user)
        {
            InitializeComponent();
            userName = user;
            this.Text= "Xem ca làm - "+ bll.SetAcountName(userName);
            LoadCheckBox();
        }
        private void LoadCheckBox()
        {
            foreach (Shift i in bll.Return_AssignedShiftById(userName))
            {
                foreach (System.Windows.Forms.CheckBox j in this.Controls.OfType<System.Windows.Forms.CheckBox>())
                {
                    j.Enabled = false;
                    if (int.Parse(j.Name[7].ToString()) == i.ShiftNumber &&
                        int.Parse(j.Name[3].ToString()) == i.Date &&
                        i.FlagAssigned == true)//Duyet roi
                        
                    {
                        j.Checked = true;
                        j.Enabled = false;
                        j.ForeColor = System.Drawing.Color.Blue;
                    }
                }
            }
        }
    }
}
