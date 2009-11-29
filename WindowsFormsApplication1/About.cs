using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace NFSU2CH
{
    public partial class About : Form
    {
        private string textabout = "Разработка: Greevex, POPSuL\nТестирование: NPRxSadProxy, MDTxVlad";
        public About()
        {
            InitializeComponent();
        }

        void About_Shown(object sender, System.EventArgs e)
        {
            this.label1.Text = this.textabout;
            this.Activate();
        }
    }

}
