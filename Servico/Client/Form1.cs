using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private async void btnInvocarServico_Click(object sender, EventArgs e)
        {
            var prx = new PrxOlaMundo.OlaMundoServiceClient();
            string t = await prx.OlaMundoAsync();
            txtResult.Text = t;
            prx.Close();
        }

    }
}
