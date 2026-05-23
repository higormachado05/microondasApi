namespace Microondas.WinForms
{
    partial class CadastroProgramaForm
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
            txtNome = new TextBox();
            txtAlimento = new TextBox();
            txtTempo = new TextBox();
            txtPotencia = new TextBox();
            txtCaractere = new TextBox();
            txtInstrucoes = new TextBox();
            btnSalvar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(174, 97);
            txtNome.Margin = new Padding(3, 4, 3, 4);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(180, 27);
            txtNome.TabIndex = 0;
            // 
            // txtAlimento
            // 
            txtAlimento.Location = new Point(174, 171);
            txtAlimento.Margin = new Padding(3, 4, 3, 4);
            txtAlimento.Name = "txtAlimento";
            txtAlimento.Size = new Size(180, 27);
            txtAlimento.TabIndex = 1;
            // 
            // txtTempo
            // 
            txtTempo.Location = new Point(174, 239);
            txtTempo.Margin = new Padding(3, 4, 3, 4);
            txtTempo.Name = "txtTempo";
            txtTempo.Size = new Size(180, 27);
            txtTempo.TabIndex = 2;
            // 
            // txtPotencia
            // 
            txtPotencia.Location = new Point(174, 316);
            txtPotencia.Margin = new Padding(3, 4, 3, 4);
            txtPotencia.Name = "txtPotencia";
            txtPotencia.Size = new Size(180, 27);
            txtPotencia.TabIndex = 3;
            // 
            // txtCaractere
            // 
            txtCaractere.Location = new Point(174, 380);
            txtCaractere.Margin = new Padding(3, 4, 3, 4);
            txtCaractere.Name = "txtCaractere";
            txtCaractere.Size = new Size(180, 27);
            txtCaractere.TabIndex = 4;
            // 
            // txtInstrucoes
            // 
            txtInstrucoes.Location = new Point(408, 95);
            txtInstrucoes.Margin = new Padding(3, 4, 3, 4);
            txtInstrucoes.Multiline = true;
            txtInstrucoes.Name = "txtInstrucoes";
            txtInstrucoes.Size = new Size(159, 312);
            txtInstrucoes.TabIndex = 5;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(408, 440);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(159, 31);
            btnSalvar.TabIndex = 7;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(141, 25);
            label1.Name = "label1";
            label1.Size = new Size(370, 46);
            label1.TabIndex = 8;
            label1.Text = "Cadastrar Programação";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 100);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 9;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 178);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 10;
            label3.Text = "Alimento:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 246);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 11;
            label4.Text = "Tempo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 323);
            label5.Name = "label5";
            label5.Size = new Size(68, 20);
            label5.TabIndex = 12;
            label5.Text = "Potência:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(44, 387);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 13;
            label6.Text = "Caractere: ";
            // 
            // CadastroProgramaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 600);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSalvar);
            Controls.Add(txtInstrucoes);
            Controls.Add(txtCaractere);
            Controls.Add(txtPotencia);
            Controls.Add(txtTempo);
            Controls.Add(txtAlimento);
            Controls.Add(txtNome);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CadastroProgramaForm";
            Text = "CadastroProgramaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtAlimento;
        private TextBox txtTempo;
        private TextBox txtPotencia;
        private TextBox txtCaractere;
        private TextBox txtInstrucoes;
        private TextBox textBox7;
        private Button btnSalvar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}