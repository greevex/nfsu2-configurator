using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NFSU2CH.Resources
{
    public partial class AboutSoft : Form
    {
        public AboutSoft()
        {
            InitializeComponent();
        }

        private void AboutSoft_Load(object sender, EventArgs e)
        {
            label6.Text = this.ProductVersion;
            label5.Text = this.ProductVersion;
        }
    }
}
