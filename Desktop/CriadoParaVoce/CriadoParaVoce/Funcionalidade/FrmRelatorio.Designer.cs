namespace CriadoParaVoce.Funcionalidade
{
    partial class FrmRelatorio
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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.txtDia = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 40);
            this.groupBox1.Size = new System.Drawing.Size(964, 316);
            this.groupBox1.Text = "";
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(757, 362);
            this.btnGravar.Size = new System.Drawing.Size(106, 38);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(869, 362);
            this.btnSair.Size = new System.Drawing.Size(106, 38);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Relatórios";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAno);
            this.groupBox2.Controls.Add(this.txtMes);
            this.groupBox2.Controls.Add(this.txtDia);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.groupBox2.Location = new System.Drawing.Point(14, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(944, 188);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vendas";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(355, 94);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(181, 29);
            this.txtAno.TabIndex = 11;
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(355, 60);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(181, 29);
            this.txtMes.TabIndex = 10;
            // 
            // txtDia
            // 
            this.txtDia.Location = new System.Drawing.Point(355, 26);
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(181, 29);
            this.txtDia.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(542, 94);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(216, 31);
            this.button4.TabIndex = 7;
            this.button4.Text = "Gerar mais Detalhes";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(542, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(216, 31);
            this.button3.TabIndex = 6;
            this.button3.Text = "Gerar mais Detalhes";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(292, 24);
            this.label7.TabIndex = 5;
            this.label7.Text = "Valor Total Vendido (Nesta Ano) :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(293, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Valor Total Vendido (Nesta Mês) :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Gerar mais Detalhes";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valor Total Vendido (Neste Dia) :";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(178, 245);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(181, 29);
            this.textBox3.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gastos Totais :";
            // 
            // FrmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 465);
            this.Name = "FrmRelatorio";
            this.Text = "";
            this.Load += new System.EventHandler(this.CarregarCampos);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.TextBox txtDia;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
    }
}