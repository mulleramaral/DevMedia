using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System.XML_Example
{
    public partial class Form4 : Form
    {
        Contatos contatos = null;
        List<Contato> resultado = null;

        public Form4()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            contatos = SContatos.Read();
            if (cmbCampo.SelectedItem.Equals("Nome"))
            {
                resultado = contatos.Contato.Where(p => p.Nome.Contains(txtBusca.Text)).ToList();
            }

            FiltroContatos.Filtro = resultado;
        }
    }
}
