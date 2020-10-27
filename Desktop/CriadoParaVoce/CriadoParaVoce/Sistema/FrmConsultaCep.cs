using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorretoraConvenios.Sistema
{
    public partial class FrmConsultaCep : Telas.Modelo.FrmModelo
    {
        public FrmConsultaCep()
        {
            InitializeComponent();
        }

        BLL.Postal post = new BLL.Postal();

        private void CarregarForm(Object o, EventArgs e)
        {
            
        }

        private void Buscar(Object o, EventArgs e)
        {
            if (txtRua.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtRua, "Digite uma Rua");
            }
            else
            {
                errorProvider1.SetError(txtRua, "");
                CarregarDadosGrid(o, e);
            }
        }

        private void CarregarDadosGrid(Object o, EventArgs e)
        {
            dataGridView1.DataSource = post.ListarCep(txtRua.Text.Trim().ToUpper()).Tables[0];

            dataGridView1.Columns[0].HeaderText = "CEP";

            dataGridView1.AutoResizeColumn(0);
            dataGridView1.Columns[1].HeaderText = "UF";
            dataGridView1.AutoResizeColumn(1);
            dataGridView1.Columns[3].HeaderText = "Cidade";
            dataGridView1.AutoResizeColumn(3);
            dataGridView1.Columns[4].HeaderText = "Bairro";
            dataGridView1.AutoResizeColumn(4);
        }


     
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Close();
        }

        private void txtRua_Leave(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }
    }
}
