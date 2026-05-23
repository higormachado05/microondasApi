using Microondas.Application.Services;
using Microondas.Application.Commands.Aquecimento.Iniciar;
using Microondas.Application.Commands.Aquecimento.Pausar;
using Microondas.Domain.Enums;
using Microondas.Application.Repositories;
using Microondas.Domain.Entities;
using System.Net.NetworkInformation;

namespace Microondas.WinForms
{
    public partial class MainForm : Form
    {
        private readonly IniciarAquecimentoCommandHandler iniciarAquecimentoHandler;

        private readonly PausarOuCancelarAquecimentoCommandHandler pausarOuCancelarAquecimentoHandler;

        private readonly MicroondasService service;

        private readonly ProgramaAquecimentoRepository repository;

        private bool programaPreDefinido = false;

        private ProgramaAquecimento? programaSelecionado;

        public MainForm()
        {
            InitializeComponent();
            service = new MicroondasService();
            iniciarAquecimentoHandler = new IniciarAquecimentoCommandHandler(service);
            pausarOuCancelarAquecimentoHandler = new PausarOuCancelarAquecimentoCommandHandler(service);
            repository = new ProgramaAquecimentoRepository();
            CarregarProgramas();

            listaProgramas.DrawMode = DrawMode.OwnerDrawFixed;
            listaProgramas.DrawItem += ListaProgramas_DrawItem;

            listaProgramas.SelectedIndexChanged += listaProgramas_SelectedIndexChanged;

            btnLimparPrograma.Enabled = false;
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                var currentStatus = service.ObterStatusAquecimento();

                if (currentStatus.Status == StatusMicroondas.Aquecendo)
                    return;

                if (programaSelecionado != null)
                {
                    iniciarProgramaSelecionado();
                }
                else
                {
                    var command = new IniciarAquecimentoCommand
                    {
                        Tempo = string.IsNullOrWhiteSpace(txtTempo.Text)
                            ? null
                            : int.Parse(txtTempo.Text),

                        Potencia = string.IsNullOrWhiteSpace(txtPotencia.Text)
                            ? null
                            : int.Parse(txtPotencia.Text),

                        ProgramaPreDefinido = programaPreDefinido
                    };

                    lblStatus.Text =
                        iniciarAquecimentoHandler.Handle(command);
                }

                var status = service.ObterStatusAquecimento();
                txtTempo.Text = status.TempoRestante.ToString();
                txtPotencia.Text = status.Potencia.ToString();
                listaProgramas.Enabled = false;
                btnLimparPrograma.Enabled = false;

                timerAquecimento.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPausarCancelar_Click(object sender, EventArgs e)
        {
            var resultado = pausarOuCancelarAquecimentoHandler.Handle(new PausarOuCancelarAquecimentoCommand());
            lblStatus.Text = resultado;

            var status = service.ObterStatusAquecimento();

            if (status.Status == StatusMicroondas.Cancelado)
            {
                timerAquecimento.Stop();
                LimparTela();
            }
        }

        private void timerAquecimento_Tick(object sender, EventArgs e)
        {
            var status = service.ProcessarStatus();

            lblStatus.Text = status.TextoAquecimento;

            rtbAquecimento.Text = status.ExibirAndamento;

            lblTempoRestante.Text = $"Tempo restante: {service.FormatarTempo(status.TempoRestante)}";

            if (status.Concluido)
            {
                timerAquecimento.Stop();
                listaProgramas.Enabled = true;
            }

        }

        private void LimparTela()
        {
            txtTempo.Text = "";

            txtPotencia.Text = "";

            rtbAquecimento.Text = "";

            lblTempoRestante.Text =
                $"Tempo restante: {service.FormatarTempo(0)}";

            listaProgramas.ClearSelected();

            txtTempo.Enabled = true;

            txtPotencia.Enabled = true;

            listaProgramas.Enabled = true;

            programaSelecionado = null;

            programaPreDefinido = false;
        }

        private void CarregarProgramas()
        {
            var programas = repository.ObterTodos();
            listaProgramas.DataSource = programas;
            listaProgramas.DisplayMember = "Nome";
        }

        private void ListaProgramas_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            var item = (ProgramaAquecimento)listaProgramas.Items[e.Index];

            Font itemFont = item.PreDefinido ? e.Font : new Font(e.Font, FontStyle.Italic);

            Color foreColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected ? SystemColors.HighlightText : e.ForeColor;

            using (var brush = new SolidBrush(foreColor))
            {
                e.Graphics.DrawString(item.Nome, itemFont, brush, e.Bounds.Location);
            }

            e.DrawFocusRectangle();
        }

        private void listaProgramas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentStatus = service.ObterStatusAquecimento();

            if (currentStatus.Status == StatusMicroondas.Aquecendo)
            {
                listaProgramas.SelectedItem = programaSelecionado;
                btnLimparPrograma.Enabled = false;
                return;
            }

            if (listaProgramas.SelectedItem == null)
            {
                programaSelecionado = null;
                programaPreDefinido = false;
                btnLimparPrograma.Enabled = false;
                rtbDescricao.Text = "";
                return;
            }

            programaSelecionado = (ProgramaAquecimento)listaProgramas.SelectedItem;

            programaPreDefinido = true;

            txtPotencia.Text = programaSelecionado.Potencia.ToString();
            txtTempo.Text = programaSelecionado.Tempo.ToString();
            rtbDescricao.Text = programaSelecionado.Instrucoes ?? "Sem instruções.";

            txtPotencia.Enabled = false;
            txtTempo.Enabled = false;
            btnLimparPrograma.Enabled = true;

            lblStatus.Text = $"Programa selecionado: {programaSelecionado.Nome}";
        }

        private void iniciarProgramaSelecionado()
        {

            if (programaSelecionado == null)
                return;

            var command = new IniciarAquecimentoCommand
            {
                Tempo = programaSelecionado.Tempo,
                Potencia = programaSelecionado.Potencia,
                ProgramaPreDefinido = true
            };

            var resultado = iniciarAquecimentoHandler.Handle(command);

            try
            {
                var status = service.ObterStatusAquecimento();
                status.CaractereAquecimento = programaSelecionado.CaractereAquecimento;
            }
            catch
            {
            }

            lblStatus.Text = resultado;

            listaProgramas.Enabled = false;

            timerAquecimento.Start();

            return;
        }

        private void btnLimparPrograma_Click(object sender, EventArgs e)
        {
            var status = service.ObterStatusAquecimento();

            if (status.Status == StatusMicroondas.Aquecendo)
            {
                MessageBox.Show("Não é possível limpar o programa enquanto houver aquecimento em andamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            programaSelecionado = null;

            programaPreDefinido = false;

            listaProgramas.ClearSelected();

            txtTempo.ReadOnly = false;

            txtPotencia.ReadOnly = false;

            txtTempo.Text = "";

            txtPotencia.Text = "";

            rtbDescricao.Text = "";

            lblStatus.Text =
                "Modo manual ativado.";

            txtTempo.Enabled = true;
            txtPotencia.Enabled = true;

            // Permitir selecionar outro programa após limpar
            listaProgramas.Enabled = true;
            try { listaProgramas.Focus(); } catch { }

            btnLimparPrograma.Enabled = false;
        }

        private void btnNovoPrograma_Click(object sender, EventArgs e)
        {
            var telaCadastro = new CadastroProgramaForm(repository);

            telaCadastro.ShowDialog();

            CarregarProgramas();
        }
    }
}
