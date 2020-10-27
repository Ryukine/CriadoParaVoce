using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace CriadoParaVoce.Funcionalidade
{
    public partial class FrmFaleConsulta : Telas.Modelo.FrmModeloCadastro
    {
        public FrmFaleConsulta()
        {
            InitializeComponent();
        }

        private int _CodigoUsuario;

        public int CodigoUsuario { get => _CodigoUsuario; set => _CodigoUsuario = value; }

        private int _TipoUso;

        public int TipoUso { get => _TipoUso; set => _TipoUso = value; }

        private DateTime DataMsg;
        private void CarregarCampos(Object o, EventArgs e)
        {
            try
            {
                /* CarregarComboDepartamento(o, e);
                 CarregarComboCargo(o, e);*/
                //txtTelAdd2.Visible = false;
                //txtTelAdd3.Visible = false;
                /*label19.Visible = false;
                label21.Visible = false;
                label22.Visible = false;*/
                btnGravar.Visible = true;
                txtUsuario.Enabled = false;

                BLL.FaleConosco fale = new BLL.FaleConosco();
                System.Data.SqlClient.SqlDataReader dr;
                fale.IDMSG = Codigo;
                dr = fale.Consultar();
                if (dr.Read())
                {
                    txtIdMensagem.Text = Convert.ToString(dr["IDMSG"]);
                    txtEmail.Text = Convert.ToString(dr["EMAIL"]);
                    txtNome.Text = Convert.ToString(dr["NOME"]);
                    txtAssunto.Text = Convert.ToString(dr["Assunto"]);
                    txtTelefone.Text = Convert.ToString(dr["TELEFONE"]);
                    txtMensagem.Text = Convert.ToString(dr["MSG"]);
                    txtDataResp.Text = Convert.ToString(dr["DATA_RESP_MSG"]);
                    txtResposta.Text = Convert.ToString(dr["RESP_MSG"]);
                    DataMsg = Convert.ToDateTime(dr["DATA_MSG"]);
                    /*txtUsuario.Text = Convert.ToString(dr["NomeSistema"]);
                    txtUsuario.Enabled = false;
                    txtSenha.Text = BLL.FuncoesGerais.Descriptografar(Convert.ToString(dr["SenhaSistema"]));
                    txtNome.Text = Convert.ToString(dr["NomeUsuario"]);
                    PinUsuario = Convert.ToString(dr["PinUsuario"]);
                    chkAtivo.Checked = Convert.ToBoolean(dr["StatusUsuario"]);

                    /*if (Convert.ToString(dr["PerguntaUsuario"]) == String.Empty)
                    {
                        txtPergunta.Text = "Qual é o PIN?";
                        RespostaSecreta = Convert.ToString(dr["PinUsuario"]);
                    }
                    else*/
                    //{
                    //txtPergunta.Text = Convert.ToString(dr["PerguntaUsuario"]);
                    //RespostaSecreta = BLL.FuncoesGerais.Descriptografar(Convert.ToString(dr["RespostaUsuario"]));
                    //}

                }

                BLL.Usuario usu = new BLL.Usuario();
                usu.CodigoUsuario = CodigoUsuario;
                System.Data.SqlClient.SqlDataReader drr;
                drr = usu.Consultar();
                if (drr.Read())
                {
                    txtUsuario.Text = Convert.ToString(drr["NomeUsuario"]);
                }


                this.groupBox1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro");
            }

        }

        private void Responder(Object o, EventArgs e)
        {
            if (txtResposta.Text.Trim().Length  == 0)
            {
                errorProvider1.SetError(txtResposta, "Preencha este campo"); return;
            }
            else
            {
                errorProvider1.SetError(txtResposta, "");
            }

            if (chkEnviar.Checked)
            {
                enviarEmail(txtEmail.Text);
            }

            BLL.FaleConosco fale = new BLL.FaleConosco();
            fale.IDMSG = Convert.ToInt32(txtIdMensagem.Text);
            fale.Assunto = txtAssunto.Text;
            fale.CodigoUsuario = CodigoUsuario;
            fale.DATA_RESP_MSG = DateTime.Now;
            fale.EMAIL = txtEmail.Text;
            fale.NOME = txtNome.Text;
            fale.TELEFONE = txtTelefone.Text;
            fale.RESP_MSG = txtResposta.Text;
            fale.STATUS_MSG = 0;
            fale.DATA_MSG = Convert.ToDateTime(DataMsg);
            //fale.DATA_MSG = Convert.ToDateTime("18/09/2019");
            fale.AlterarComParametro();
            MessageBox.Show("Mensagem Respondida com sucesso!");
            Close();
        }

        protected void sendMessage_Click(object sender, EventArgs e)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("CriadoParaVoceTCC@outlook.com", "Papelhigienico_61743");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("CriadoParaVoceTCC@outlook.com", "ENVIADOR");
            mail.From = new MailAddress("CriadoParaVoceTCC@outlook.com", "ENVIADOR");
            mail.To.Add(new MailAddress("thiagi-araujo@hotmail.com.br", "RECEBEDOR"));
            mail.Subject = "Princesa";
            mail.Body = " Mensagem do site:<br/> Nome:  " + txtNome.Text + "<br/> Email : " + "CriadoParaVoceTCC@outlook.com" + " <br/> Mensagem : " + txtResposta.Text;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
            }
            catch (System.Exception erro)
            {
                //trata erro
                MessageBox.Show(erro.Message);
            }
            finally
            {
                mail = null;
            }
        }

        private void mail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                new SmtpClient().UseDefaultCredentials = false;
                mail.From = new MailAddress("criadoparavocetcc@gmail.com");
                mail.To.Add(txtEmail.Text);
                mail.Subject = "Olá " + txtNome.Text;
                mail.Body = " Mensagem do site:<br/> Nome:  " + txtNome.Text + "<br/> Email : " + "criadoparavocetcc@gmail.com" + " <br/> Mensagem : " + txtResposta.Text;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("criadoparavocetcc@gmail.com", "Papelhigienico_61743");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Este E-mail não existe" + ex.Message);
                //throw;
            }
        }

        private void Outlook(Object o, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        public void enviarEmail(string email)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(email); //email que vai receber
            msg.Subject = "Não Responda"; //assunto
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Caro cliente, recebemos seu comentário, agradecemos pela colaboração, " + txtResposta.Text + " Atenciosamente, Companhia Criado Para Você"; //msg
            msg.BodyEncoding = System.Text.Encoding.UTF8;

            //msg.IsBodyHtml = true; descomentar caso esteja mandando um html
            msg.From = new MailAddress("criadoparavocetcc@gmail.com"); //email que vai enviar

            SmtpClient cliente = new SmtpClient();
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new System.Net.NetworkCredential("criadoparavocetcc@gmail.com", "Papelhigienico_61743");  //email e senha que vai enviar

            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            try
            {
                cliente.Send(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //tratar erros
            }
        }
    }
}
