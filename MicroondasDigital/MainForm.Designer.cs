namespace Microondas.WinForms
{
    partial class MainForm
    {
        
        private System.ComponentModel.IContainer components = null;

       
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


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTempo = new Label();
            lblPotencia = new Label();
            lblStatus = new Label();
            txtTempo = new TextBox();
            txtPotencia = new TextBox();
            listaProgramas = new ListBox();
            timerAquecimento = new System.Windows.Forms.Timer(components);
            btnIniciar = new Button();
            btnPausarCancelar = new Button();
            rtbAquecimento = new RichTextBox();
            rtbDescricao = new RichTextBox();
            label1 = new Label();
            lblTempoRestante = new Label();
            btnLimparPrograma = new Button();
            btnNovoPrograma = new Button();
            SuspendLayout();
            // 
            // lblTempo
            // 
            lblTempo.AutoSize = true;
            lblTempo.Location = new Point(64, 55);
            lblTempo.Name = "lblTempo";
            lblTempo.Size = new Size(47, 15);
            lblTempo.TabIndex = 0;
            lblTempo.Text = "Tempo:";
            // 
            // lblPotencia
            // 
            lblPotencia.AutoSize = true;
            lblPotencia.Location = new Point(64, 91);
            lblPotencia.Name = "lblPotencia";
            lblPotencia.Size = new Size(56, 15);
            lblPotencia.TabIndex = 1;
            lblPotencia.Text = "Potência:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(126, 131);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 2;
            // 
            // txtTempo
            // 
            txtTempo.Location = new Point(126, 55);
            txtTempo.Name = "txtTempo";
            txtTempo.Size = new Size(100, 23);
            txtTempo.TabIndex = 3;
            // 
            // txtPotencia
            // 
            txtPotencia.Location = new Point(126, 88);
            txtPotencia.Name = "txtPotencia";
            txtPotencia.Size = new Size(100, 23);
            txtPotencia.TabIndex = 4;
            // 
            // listaProgramas
            // 
            listaProgramas.FormattingEnabled = true;
            listaProgramas.ItemHeight = 15;
            listaProgramas.Location = new Point(319, 177);
            listaProgramas.Name = "listaProgramas";
            listaProgramas.Size = new Size(204, 109);
            listaProgramas.TabIndex = 5;
            // 
            // timerAquecimento
            // 
            timerAquecimento.Interval = 1000;
            timerAquecimento.Tick += timerAquecimento_Tick;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(319, 349);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(75, 23);
            btnIniciar.TabIndex = 6;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnPausarCancelar
            // 
            btnPausarCancelar.Location = new Point(400, 349);
            btnPausarCancelar.Name = "btnPausarCancelar";
            btnPausarCancelar.Size = new Size(123, 23);
            btnPausarCancelar.TabIndex = 7;
            btnPausarCancelar.Text = "Pausar/Cancelar";
            btnPausarCancelar.UseVisualStyleBackColor = true;
            btnPausarCancelar.Click += btnPausarCancelar_Click;
            // 
            // rtbAquecimento
            // 
            rtbAquecimento.Location = new Point(64, 201);
            rtbAquecimento.Name = "rtbAquecimento";
            rtbAquecimento.Size = new Size(219, 171);
            rtbAquecimento.TabIndex = 9;
            rtbAquecimento.Text = "";
            // 
            // rtbDescricao
            // 
            rtbDescricao.Location = new Point(319, 52);
            rtbDescricao.Name = "rtbDescricao";
            rtbDescricao.ReadOnly = true;
            rtbDescricao.Size = new Size(204, 112);
            rtbDescricao.TabIndex = 15;
            rtbDescricao.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 131);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 10;
            label1.Text = "Status: ";
            // 
            // lblTempoRestante
            // 
            lblTempoRestante.AutoSize = true;
            lblTempoRestante.Location = new Point(72, 170);
            lblTempoRestante.Name = "lblTempoRestante";
            lblTempoRestante.Size = new Size(0, 15);
            lblTempoRestante.TabIndex = 12;
            // 
            // btnLimparPrograma
            // 
            btnLimparPrograma.Location = new Point(319, 320);
            btnLimparPrograma.Name = "btnLimparPrograma";
            btnLimparPrograma.Size = new Size(204, 23);
            btnLimparPrograma.TabIndex = 13;
            btnLimparPrograma.Text = "Limpar Programa";
            btnLimparPrograma.UseVisualStyleBackColor = true;
            btnLimparPrograma.Click += btnLimparPrograma_Click;
            // 
            // btnNovoPrograma
            // 
            btnNovoPrograma.Location = new Point(319, 291);
            btnNovoPrograma.Name = "btnNovoPrograma";
            btnNovoPrograma.Size = new Size(204, 23);
            btnNovoPrograma.TabIndex = 14;
            btnNovoPrograma.Text = "Cadastrar Programa";
            btnNovoPrograma.UseVisualStyleBackColor = true;
            btnNovoPrograma.Click += btnNovoPrograma_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 450);
            Controls.Add(btnNovoPrograma);
            Controls.Add(btnLimparPrograma);
            Controls.Add(lblTempoRestante);
            Controls.Add(rtbDescricao);
            Controls.Add(label1);
            Controls.Add(rtbAquecimento);
            Controls.Add(btnPausarCancelar);
            Controls.Add(btnIniciar);
            Controls.Add(listaProgramas);
            Controls.Add(txtPotencia);
            Controls.Add(txtTempo);
            Controls.Add(lblStatus);
            Controls.Add(lblPotencia);
            Controls.Add(lblTempo);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTempo;
        private Label lblPotencia;
        private Label lblStatus;
        private TextBox txtTempo;
        private TextBox txtPotencia;
        private ListBox listaProgramas;
        private System.Windows.Forms.Timer timerAquecimento;
        private Button btnIniciar;
        private Button btnPausarCancelar;
        private RichTextBox rtbAquecimento;
        private RichTextBox rtbDescricao;
        private Label label1;
        private Label lblTempoRestante;
        private Button btnLimparPrograma;
        private Button btnNovoPrograma;
    }
}