using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadoParaVoce
{
    public partial class FrmApresentacao : Telas.Modelo.FrmModelo
    {
        public FrmApresentacao()
        {
            InitializeComponent();
            string DadosBanco;

            DadosBanco = TCC.ClasseParaManipularBancoDeDados.Conexao().ToString();

            this.txtDescricao.Text = DadosBanco;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TCC.ClasseParaManipularBancoDeDados c = new TCC.ClasseParaManipularBancoDeDados();
            try
            {
                FrmLogin frm = new FrmLogin();
                if (progressBar1.Value < 100)
                {
                    progressBar1.Value = progressBar1.Value + 20;
                }
                else
                {
                    timer1.Enabled = false; //Desativar o nosso Timer
                    //Application.Exit();     //Encerra a aplicação
                    this.Hide();
                    frm.Text = "Login";
                    frm.ShowDialog();
                }

                /*if (this.txtDescricao.Text.Substring(this.txtDescricao.Text.Length - 2, 2) == "OK")
                {
                    frm.BackColor = System.Drawing.Color.Green;
                    //flog.label3.Text = Convert.ToString(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

                    //flog.label3.Text = Application.StartupPath;
                    frm.FuncionamentoBancoDados = true;
                }
                else
                {
                    frm.BackColor = System.Drawing.Color.Red;
                    frm.FuncionamentoBancoDados = false;
                }
                frm.ShowDialog();*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }

    }


}
