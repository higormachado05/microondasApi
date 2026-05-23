using Microondas.Application.Commands.ProgramaAquecimento.Adicionar;
using Microondas.Application.Repositories;
using Microondas.Domain.Exceptions;


namespace Microondas.WinForms
{
    public partial class CadastroProgramaForm : Form
    {
        private readonly ProgramaAquecimentoRepository repository;
        private readonly AdicionarProgramaCommandHandler adicionarHandler; // Adicione o handler

        public CadastroProgramaForm(ProgramaAquecimentoRepository repository)
        {
            this.repository = repository;
            this.adicionarHandler = new AdicionarProgramaCommandHandler(repository); // Inicialize o handler
            InitializeComponent();

            txtNome.PlaceholderText = "Nome do programa";
            txtAlimento.PlaceholderText = "Tipo de alimento";
            txtTempo.PlaceholderText = "Tempo em segundos";
            txtPotencia.PlaceholderText = "Potência (1-10)";
            txtCaractere.PlaceholderText = "Caractere de aquecimento";
            txtInstrucoes.PlaceholderText = "Descrição (opcional)";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var command = new AdicionarProgramaCommand
                {
                    Nome = txtNome.Text,
                    Alimento = txtAlimento.Text,
                    Tempo = int.TryParse(txtTempo.Text, out int tempo)
                        ? tempo
                        : 0,

                    Potencia = int.TryParse(txtPotencia.Text, out int potencia)
                        ? potencia
                        : 0,

                    CaractereAquecimento =
                        string.IsNullOrWhiteSpace(txtCaractere.Text)
                            ? '\0'
                            : txtCaractere.Text[0],

                    Instrucoes = txtInstrucoes.Text
                };

                adicionarHandler.Handle(command);

                MessageBox.Show(
                    "Programa adicionado com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro de validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
