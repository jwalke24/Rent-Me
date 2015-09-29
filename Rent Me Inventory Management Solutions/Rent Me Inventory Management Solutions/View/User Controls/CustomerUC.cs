﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rent_Me_Inventory_Management_Solutions.View.User_Controls;

namespace Rent_Me_Inventory_Management_Solutions.View
{
    public partial class CustomerUserControl : UserControl, IRentMeUcInterface
    {
        public CustomerUserControl()
        {
            InitializeComponent();
        }

        public UserControls ControlType { get; set; }
        public DataGridView DataGrid { get; set; }
    }
}