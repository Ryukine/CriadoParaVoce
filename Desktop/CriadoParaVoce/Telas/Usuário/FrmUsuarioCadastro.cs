using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas.Usuário
{
    public partial class FrmUsuarioCadastro : Modelo.FrmModeloCadastro
    {
        public FrmUsuarioCadastro()
        {
            InitializeComponent();
        }

        private void Gravar(Object o, EventArgs e)
        {
            try
            {
                if (txtNome.Text.Length == 0)
                {
                    errorProvider1.SetError(txtNome, "Nome é obrigatório");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtNome, "");
                }
                if (txtSenha.Text.Length == 0)
                {
                    errorProvider1.SetError(txtSenha, "Senha é obrigatória");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtSenha, "");
                }
                BLL.Usuario usu = new BLL.Usuario();
                usu.CodigoUsuario = Codigo;
                usu.NomeSistema = txtNome.Text;
                usu.SenhaSistema = txtSenha.Text;
                usu.StatusUsuario = 0;
                if (chkAtivo.Checked)
                {
                    usu.StatusUsuario = 1;
                }
                //Testamos com ifs se ocorreu a digitação do nome e senha. Em caso de não preenchimento um 'erroprovider1' foi associado a cada textbox para exibir uma indicação de erro 'seterro' com uma mensagem específica. Instanciamos um objeto 'usu' para fazer com que as propriedades '.codigo' '.nome' '.status' recebam '=' o conteúdo da digitação
                if (Funcionalidade == 0)
                {
                    //Incluir
                    usu.Incluir();
                    MessageBox.Show("Novo Usuário foi inserido no sistema");
                }

                if (Funcionalidade == 1)
                {
                    //Alterar
                    usu.Alterar();
                    MessageBox.Show("Alterado com sucesso");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void CarregarCampos(Object o, EventArgs e)
        {
            try
            {
                if (Funcionalidade != (byte)BLL.FuncoesGerais.TipoUso.Inclusao)
                {
                    BLL.Usuario usu = new BLL.Usuario();
                    System.Data.SqlClient.SqlDataReader dr;
                    usu.CodigoUsuario = Codigo;
                    dr = usu.Consultar();
                    //faço instancia do objeto 'usu'  'new'; Defino um objeto 'dr'; informo o 'Codigo' para a propriedade '.Codigo' do objeto 'usu'; 'dr' recebe '=' o método 'Consultar' do objeto 'usu'. OBSERVAÇÃO-O método consultar é a instrução SELECT * FROM TBUSUARIO WHERE codigo=1
                    if (dr.Read())
                    {
                        txtNome.Text = dr["nome"].ToString();
                        chkAtivo.Checked = true;
                        if (Convert.ToByte(dr["ativo"]) == 0)
                        {
                            chkAtivo.Checked = false;
                        }
                        //dr.read executa o método consultar e se há sucesso, ou seja, encontrou algo é carregado o 'txtnome' com o dado que está na coluna 'nome' do objeto 'dr' transformado em string; Assumo que o 'chkativo' é verdadeiro e na sequencia faço um teste 'if' verificando o dado da coluna 'ativo'
                        txtSenha.Text = Convert.ToString(dr["senha"]);

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }

        private void Sair(Object o, EventArgs e)
        {
            Close();
        }

    }
}
