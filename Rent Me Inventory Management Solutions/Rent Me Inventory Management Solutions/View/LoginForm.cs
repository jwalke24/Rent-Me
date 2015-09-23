using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_Me_Inventory_Management_Solutions
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            this.InitializeComponent();
            this.FormClosing += formClosing;
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall || e.CloseReason != CloseReason.FormOwnerClosing)
            {
                this.DialogResult = DialogResult.Abort;
            }

        
        }

        private void lblServer_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
    }
}
