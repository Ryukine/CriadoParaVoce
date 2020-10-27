namespace CriadoParaVoce.Funcionário
{
    partial class FrmFuncionarioCadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabPessoais = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabEndereco = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.cboCidade = new System.Windows.Forms.ComboBox();
            this.cboUF = new System.Windows.Forms.ComboBox();
            this.btnBuscaCep = new System.Windows.Forms.Button();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.tabDadosPessoais = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cbMostrarSenha = new System.Windows.Forms.CheckBox();
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtCpf = new System.Windows.Forms.MaskedTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.rbtFeminino = new System.Windows.Forms.RadioButton();
            this.rbtMasculino = new System.Windows.Forms.RadioButton();
            this.txtDataNasc = new System.Windows.Forms.MaskedTextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.tabGeral = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNomeFoto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImagem = new System.Windows.Forms.TextBox();
            this.btnAdicionarFoto = new System.Windows.Forms.Button();
            this.pbxFuncionario = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCargo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabPessoais.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabEndereco.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabDadosPessoais.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabGeral.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFuncionario)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(11, 20);
            this.groupBox1.Size = new System.Drawing.Size(786, 572);
            this.groupBox1.Text = "";
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(601, 598);
            this.btnGravar.Size = new System.Drawing.Size(96, 35);
            this.btnGravar.Click += new System.EventHandler(this.Gravar);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(702, 598);
            this.btnSair.Size = new System.Drawing.Size(96, 35);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Size = new System.Drawing.Size(57, 21);
            // 
            // tabPessoais
            // 
            this.tabPessoais.BackColor = System.Drawing.Color.Transparent;
            this.tabPessoais.Controls.Add(this.tabControl2);
            this.tabPessoais.Location = new System.Drawing.Point(4, 30);
            this.tabPessoais.Name = "tabPessoais";
            this.tabPessoais.Padding = new System.Windows.Forms.Padding(3);
            this.tabPessoais.Size = new System.Drawing.Size(778, 521);
            this.tabPessoais.TabIndex = 2;
            this.tabPessoais.Text = "Pessoais";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabEndereco);
            this.tabControl2.Controls.Add(this.tabDadosPessoais);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(772, 515);
            this.tabControl2.TabIndex = 0;
            // 
            // tabEndereco
            // 
            this.tabEndereco.BackColor = System.Drawing.Color.Transparent;
            this.tabEndereco.Controls.Add(this.groupBox8);
            this.tabEndereco.Location = new System.Drawing.Point(4, 30);
            this.tabEndereco.Name = "tabEndereco";
            this.tabEndereco.Padding = new System.Windows.Forms.Padding(3);
            this.tabEndereco.Size = new System.Drawing.Size(764, 481);
            this.tabEndereco.TabIndex = 0;
            this.tabEndereco.Text = "Endereço";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.maskedTextBox2);
            this.groupBox8.Controls.Add(this.maskedTextBox1);
            this.groupBox8.Controls.Add(this.label42);
            this.groupBox8.Controls.Add(this.label43);
            this.groupBox8.Controls.Add(this.txtEmail);
            this.groupBox8.Controls.Add(this.label44);
            this.groupBox8.Controls.Add(this.cboCidade);
            this.groupBox8.Controls.Add(this.cboUF);
            this.groupBox8.Controls.Add(this.btnBuscaCep);
            this.groupBox8.Controls.Add(this.txtComplemento);
            this.groupBox8.Controls.Add(this.label28);
            this.groupBox8.Controls.Add(this.txtNumero);
            this.groupBox8.Controls.Add(this.label33);
            this.groupBox8.Controls.Add(this.label34);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Controls.Add(this.label36);
            this.groupBox8.Controls.Add(this.label37);
            this.groupBox8.Controls.Add(this.txtBairro);
            this.groupBox8.Controls.Add(this.txtLogradouro);
            this.groupBox8.Controls.Add(this.txtCep);
            this.groupBox8.Controls.Add(this.label38);
            this.groupBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox8.Location = new System.Drawing.Point(2, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(756, 321);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Geral";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(181, 216);
            this.maskedTextBox2.Mask = "(99) 0000-0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(140, 27);
            this.maskedTextBox2.TabIndex = 14;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(181, 246);
            this.maskedTextBox1.Mask = "(99) 00000-0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(140, 27);
            this.maskedTextBox1.TabIndex = 15;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label42.Location = new System.Drawing.Point(2, 249);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(143, 21);
            this.label42.TabIndex = 133;
            this.label42.Text = "Telefone Celular :";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label43.Location = new System.Drawing.Point(2, 219);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(175, 21);
            this.label43.TabIndex = 132;
            this.label43.Text = "Telefone Residencial :";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(181, 186);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(404, 27);
            this.txtEmail.TabIndex = 13;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label44.Location = new System.Drawing.Point(2, 189);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(64, 21);
            this.label44.TabIndex = 130;
            this.label44.Text = "E-mail :";
            // 
            // cboCidade
            // 
            this.cboCidade.FormattingEnabled = true;
            this.cboCidade.Location = new System.Drawing.Point(182, 119);
            this.cboCidade.Name = "cboCidade";
            this.cboCidade.Size = new System.Drawing.Size(300, 29);
            this.cboCidade.TabIndex = 11;
            // 
            // cboUF
            // 
            this.cboUF.FormattingEnabled = true;
            this.cboUF.Location = new System.Drawing.Point(552, 122);
            this.cboUF.Name = "cboUF";
            this.cboUF.Size = new System.Drawing.Size(69, 29);
            this.cboUF.TabIndex = 12;
            // 
            // btnBuscaCep
            // 
            this.btnBuscaCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaCep.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnBuscaCep.Location = new System.Drawing.Point(287, 24);
            this.btnBuscaCep.Name = "btnBuscaCep";
            this.btnBuscaCep.Size = new System.Drawing.Size(129, 27);
            this.btnBuscaCep.TabIndex = 129;
            this.btnBuscaCep.Text = "Localizar Cep";
            this.btnBuscaCep.UseVisualStyleBackColor = true;
            this.btnBuscaCep.Click += new System.EventHandler(this.BuscaCep);
            // 
            // txtComplemento
            // 
            this.txtComplemento.Location = new System.Drawing.Point(181, 155);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(404, 27);
            this.txtComplemento.TabIndex = 8;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label28.Location = new System.Drawing.Point(2, 155);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(132, 21);
            this.label28.TabIndex = 127;
            this.label28.Text = "Complemento :";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(552, 94);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 27);
            this.txtNumero.TabIndex = 7;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label33.Location = new System.Drawing.Point(510, 97);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(36, 21);
            this.label33.TabIndex = 126;
            this.label33.Text = "Nº :";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label34.Location = new System.Drawing.Point(509, 130);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(37, 21);
            this.label34.TabIndex = 125;
            this.label34.Text = "UF :";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label35.Location = new System.Drawing.Point(2, 123);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 21);
            this.label35.TabIndex = 124;
            this.label35.Text = "Cidade :";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label36.Location = new System.Drawing.Point(2, 94);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(61, 21);
            this.label36.TabIndex = 123;
            this.label36.Text = "Bairro :";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label37.Location = new System.Drawing.Point(2, 61);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(108, 21);
            this.label37.TabIndex = 122;
            this.label37.Text = "Logradouro :";
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(182, 90);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(300, 27);
            this.txtBairro.TabIndex = 10;
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Location = new System.Drawing.Point(182, 60);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(301, 27);
            this.txtLogradouro.TabIndex = 9;
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(181, 24);
            this.txtCep.Mask = "00000-999";
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(100, 27);
            this.txtCep.TabIndex = 5;
            this.txtCep.Leave += new System.EventHandler(this.Buscar);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label38.Location = new System.Drawing.Point(2, 27);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(49, 21);
            this.label38.TabIndex = 121;
            this.label38.Text = "CEP :";
            // 
            // tabDadosPessoais
            // 
            this.tabDadosPessoais.BackColor = System.Drawing.Color.Transparent;
            this.tabDadosPessoais.Controls.Add(this.groupBox10);
            this.tabDadosPessoais.Controls.Add(this.groupBox9);
            this.tabDadosPessoais.Location = new System.Drawing.Point(4, 30);
            this.tabDadosPessoais.Name = "tabDadosPessoais";
            this.tabDadosPessoais.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosPessoais.Size = new System.Drawing.Size(764, 481);
            this.tabDadosPessoais.TabIndex = 1;
            this.tabDadosPessoais.Text = "Dados Pessoais";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.cbMostrarSenha);
            this.groupBox10.Controls.Add(this.cboNivel);
            this.groupBox10.Controls.Add(this.chkAtivo);
            this.groupBox10.Controls.Add(this.txtSenha);
            this.groupBox10.Controls.Add(this.label45);
            this.groupBox10.Controls.Add(this.label48);
            this.groupBox10.Controls.Add(this.label49);
            this.groupBox10.Controls.Add(this.txtUsuario);
            this.groupBox10.Controls.Add(this.label50);
            this.groupBox10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox10.Location = new System.Drawing.Point(3, 188);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(756, 135);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Usuário";
            // 
            // cbMostrarSenha
            // 
            this.cbMostrarSenha.AutoSize = true;
            this.cbMostrarSenha.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cbMostrarSenha.Location = new System.Drawing.Point(309, 61);
            this.cbMostrarSenha.Name = "cbMostrarSenha";
            this.cbMostrarSenha.Size = new System.Drawing.Size(141, 25);
            this.cbMostrarSenha.TabIndex = 155;
            this.cbMostrarSenha.Text = "Mostrar Senha";
            this.cbMostrarSenha.UseVisualStyleBackColor = true;
            this.cbMostrarSenha.CheckedChanged += new System.EventHandler(this.Mostrar_Senha);
            // 
            // cboNivel
            // 
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(133, 91);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(170, 29);
            this.cboNivel.TabIndex = 22;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkAtivo.Location = new System.Drawing.Point(576, 27);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(72, 25);
            this.chkAtivo.TabIndex = 153;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(133, 58);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(170, 27);
            this.txtSenha.TabIndex = 21;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label45.Location = new System.Drawing.Point(422, 27);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(155, 21);
            this.label45.TabIndex = 141;
            this.label45.Text = "Status no Sistema :";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label48.Location = new System.Drawing.Point(2, 94);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(115, 21);
            this.label48.TabIndex = 123;
            this.label48.Text = "Nível Acesso :";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label49.Location = new System.Drawing.Point(2, 61);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(67, 21);
            this.label49.TabIndex = 122;
            this.label49.Text = "Senha :";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(133, 25);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(283, 27);
            this.txtUsuario.TabIndex = 20;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label50.Location = new System.Drawing.Point(2, 27);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(125, 21);
            this.label50.TabIndex = 121;
            this.label50.Text = "Nome Usuário :";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtCpf);
            this.groupBox9.Controls.Add(this.textBox3);
            this.groupBox9.Controls.Add(this.rbtFeminino);
            this.groupBox9.Controls.Add(this.rbtMasculino);
            this.groupBox9.Controls.Add(this.txtDataNasc);
            this.groupBox9.Controls.Add(this.label46);
            this.groupBox9.Controls.Add(this.label54);
            this.groupBox9.Controls.Add(this.label55);
            this.groupBox9.Controls.Add(this.label56);
            this.groupBox9.Controls.Add(this.txtNome);
            this.groupBox9.Controls.Add(this.label57);
            this.groupBox9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox9.Location = new System.Drawing.Point(3, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(756, 176);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Geral";
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(116, 55);
            this.txtCpf.Mask = "000,000,000-00";
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(118, 27);
            this.txtCpf.TabIndex = 17;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(116, 123);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(170, 27);
            this.textBox3.TabIndex = 19;
            // 
            // rbtFeminino
            // 
            this.rbtFeminino.AutoSize = true;
            this.rbtFeminino.ForeColor = System.Drawing.Color.RoyalBlue;
            this.rbtFeminino.Location = new System.Drawing.Point(594, 26);
            this.rbtFeminino.Name = "rbtFeminino";
            this.rbtFeminino.Size = new System.Drawing.Size(97, 25);
            this.rbtFeminino.TabIndex = 150;
            this.rbtFeminino.TabStop = true;
            this.rbtFeminino.Text = "Feminino";
            this.rbtFeminino.UseVisualStyleBackColor = true;
            // 
            // rbtMasculino
            // 
            this.rbtMasculino.AutoSize = true;
            this.rbtMasculino.ForeColor = System.Drawing.Color.RoyalBlue;
            this.rbtMasculino.Location = new System.Drawing.Point(482, 26);
            this.rbtMasculino.Name = "rbtMasculino";
            this.rbtMasculino.Size = new System.Drawing.Size(106, 25);
            this.rbtMasculino.TabIndex = 149;
            this.rbtMasculino.TabStop = true;
            this.rbtMasculino.Text = "Masculino";
            this.rbtMasculino.UseVisualStyleBackColor = true;
            // 
            // txtDataNasc
            // 
            this.txtDataNasc.Location = new System.Drawing.Point(185, 88);
            this.txtDataNasc.Mask = "00/00/0000";
            this.txtDataNasc.Name = "txtDataNasc";
            this.txtDataNasc.Size = new System.Drawing.Size(101, 27);
            this.txtDataNasc.TabIndex = 18;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label46.Location = new System.Drawing.Point(422, 27);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(54, 21);
            this.label46.TabIndex = 141;
            this.label46.Text = "Sexo :";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label54.Location = new System.Drawing.Point(2, 123);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(42, 21);
            this.label54.TabIndex = 124;
            this.label54.Text = "RG :";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label55.Location = new System.Drawing.Point(2, 94);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(182, 21);
            this.label55.TabIndex = 123;
            this.label55.Text = "Data de Nascimento :";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label56.Location = new System.Drawing.Point(2, 61);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(48, 21);
            this.label56.TabIndex = 122;
            this.label56.Text = "CPF :";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(116, 24);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 27);
            this.txtNome.TabIndex = 16;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label57.Location = new System.Drawing.Point(2, 27);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(65, 21);
            this.label57.TabIndex = 121;
            this.label57.Text = "Nome :";
            // 
            // tabGeral
            // 
            this.tabGeral.BackColor = System.Drawing.Color.Transparent;
            this.tabGeral.Controls.Add(this.groupBox4);
            this.tabGeral.Controls.Add(this.groupBox2);
            this.tabGeral.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabGeral.Location = new System.Drawing.Point(4, 30);
            this.tabGeral.Name = "tabGeral";
            this.tabGeral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeral.Size = new System.Drawing.Size(778, 521);
            this.tabGeral.TabIndex = 0;
            this.tabGeral.Text = "Geral";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtNomeFoto);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtImagem);
            this.groupBox4.Controls.Add(this.btnAdicionarFoto);
            this.groupBox4.Controls.Add(this.pbxFuncionario);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox4.Location = new System.Drawing.Point(7, 123);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(765, 398);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Funcionário";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(138, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 21);
            this.label7.TabIndex = 30;
            this.label7.Text = "Nome Da Foto:";
            // 
            // txtNomeFoto
            // 
            this.txtNomeFoto.Location = new System.Drawing.Point(271, 66);
            this.txtNomeFoto.Name = "txtNomeFoto";
            this.txtNomeFoto.Size = new System.Drawing.Size(203, 27);
            this.txtNomeFoto.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(305, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Foto Do Funcionário:";
            // 
            // txtImagem
            // 
            this.txtImagem.Location = new System.Drawing.Point(328, 268);
            this.txtImagem.Name = "txtImagem";
            this.txtImagem.ReadOnly = true;
            this.txtImagem.Size = new System.Drawing.Size(395, 27);
            this.txtImagem.TabIndex = 27;
            // 
            // btnAdicionarFoto
            // 
            this.btnAdicionarFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdicionarFoto.Location = new System.Drawing.Point(355, 201);
            this.btnAdicionarFoto.Name = "btnAdicionarFoto";
            this.btnAdicionarFoto.Size = new System.Drawing.Size(119, 61);
            this.btnAdicionarFoto.TabIndex = 26;
            this.btnAdicionarFoto.Text = "Adicionar Foto";
            this.btnAdicionarFoto.UseVisualStyleBackColor = true;
            this.btnAdicionarFoto.Click += new System.EventHandler(this.SalvarImagem);
            // 
            // pbxFuncionario
            // 
            this.pbxFuncionario.Location = new System.Drawing.Point(480, 26);
            this.pbxFuncionario.Name = "pbxFuncionario";
            this.pbxFuncionario.Size = new System.Drawing.Size(243, 236);
            this.pbxFuncionario.TabIndex = 25;
            this.pbxFuncionario.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboCargo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCodigo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(765, 110);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Geral";
            // 
            // cboCargo
            // 
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.Location = new System.Drawing.Point(90, 63);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(258, 29);
            this.cboCargo.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(6, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 14;
            this.label6.Text = "Código :";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(90, 31);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(139, 27);
            this.txtCodigo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cargo :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeral);
            this.tabControl1.Controls.Add(this.tabPessoais);
            this.tabControl1.Location = new System.Drawing.Point(0, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 555);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // FrmFuncionarioCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(808, 658);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmFuncionarioCadastro";
            this.Text = "";
            this.Load += new System.EventHandler(this.CarregarCampos);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabPessoais.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabEndereco.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabDadosPessoais.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabGeral.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFuncionario)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabGeral;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox cboCargo;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtCodigo;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TabPage tabPessoais;
        public System.Windows.Forms.TabControl tabControl2;
        public System.Windows.Forms.TabPage tabEndereco;
        public System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.MaskedTextBox maskedTextBox2;
        public System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        public System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label44;
        public System.Windows.Forms.ComboBox cboCidade;
        public System.Windows.Forms.ComboBox cboUF;
        private System.Windows.Forms.Button btnBuscaCep;
        public System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label label28;
        public System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        public System.Windows.Forms.TextBox txtBairro;
        public System.Windows.Forms.TextBox txtLogradouro;
        public System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.Label label38;
        public System.Windows.Forms.TabPage tabDadosPessoais;
        public System.Windows.Forms.GroupBox groupBox10;
        public System.Windows.Forms.CheckBox cbMostrarSenha;
        public System.Windows.Forms.ComboBox cboNivel;
        public System.Windows.Forms.CheckBox chkAtivo;
        public System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        public System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label50;
        public System.Windows.Forms.GroupBox groupBox9;
        public System.Windows.Forms.MaskedTextBox txtCpf;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.RadioButton rbtFeminino;
        public System.Windows.Forms.RadioButton rbtMasculino;
        public System.Windows.Forms.MaskedTextBox txtDataNasc;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        public System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label57;
        public System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNomeFoto;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtImagem;
        public System.Windows.Forms.Button btnAdicionarFoto;
        public System.Windows.Forms.PictureBox pbxFuncionario;
        private System.Windows.Forms.Label label7;
    }
}