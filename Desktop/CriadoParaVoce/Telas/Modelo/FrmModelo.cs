using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas.Modelo
{
    public partial class FrmModelo : Form
    {
        public FrmModelo()
        {
            InitializeComponent();
        }

        private void AtivarRelogio(Object o, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void Escapar(Object o, KeyEventArgs k)
        {
            if (k.KeyCode == Keys.Escape)
            {
                Close();
            }
        }








    }
}
