﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions.View
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.loginUser();
        }

        private void loginUser()
        {
            var loginWindow = new LoginForm();
            DialogResult loginResult = loginWindow.ShowDialog(this);
            if (loginResult == DialogResult.OK)
            {
                this.Enabled = true;
                this.Opacity = 100;
            }
            else
            {
                this.Close();
            }
            
        }
    }
}
