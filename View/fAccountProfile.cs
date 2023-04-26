﻿using PBL3CodeDemo.BLL;
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
            if (bll.UpdateAccount(txbUserName.Text, txbDisplayName.Text, txbSalary.Text,txbPhone.Text, txbAdress.Text,passWord , bll.CheckAcount_Role(userName).ToString()))
            {
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
