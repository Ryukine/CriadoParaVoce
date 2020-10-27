using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas
{
    public partial class FrmTrocaSenha : Form
    {
        public FrmTrocaSenha()
        {
            InitializeComponent();
        }

        private void Sair(Object o, EventArgs e)
        {
            Close();
        }

        private void RealizarTroca(Object o, EventArgs e)
        {
            try
            {
                BLL.Usuario usu = new BLL.Usuario();
                usu.NomeSistema = txtNome.Text;
                usu.SenhaSistema = txtNova.Text;
                int cod = usu.Logar();
                if (cod !=0)
                {
                    usu.CodigoUsuario = cod;
                    usu.SenhaSistema = txtAnterior.Text;
                    usu.TrocarSenhaComParametro();
                    MessageBox.Show("Senha Trocada com sucesso");
                    Close();
                }
                else
                {
                    MessageBox.Show("Usuário Inexistente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Mostrar_Senha(object sender, EventArgs e)
        {
            if (this.cbMostrarSenha.Checked)
            {
                this.txtNova.PasswordChar = '\0';
                this.txtAnterior.PasswordChar = '\0';

            }
            else
            {
                this.txtNova.PasswordChar = '•';
                this.txtAnterior.PasswordChar = '•';
            }
        }
    }
}
