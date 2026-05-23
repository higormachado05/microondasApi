using Microondas.Application.Commands.Aquecimento.Pausar;
using Microondas.Application.Models;
using Microondas.Domain.Entities;
using Microondas.Domain.Enums;


namespace Microondas.Application.Services
{
    public class MicroondasService
    {
        private readonly AquecimentoStatus status = new();
        public string IniciarAquecimento(int tempo, int potencia, bool programaPreDefinido)
        {

            if (status.Status == StatusMicroondas.Cancelado ||
                status.Status == StatusMicroondas.Concluido)
            {
                status.ExibirAndamento = "";
                status.Concluido = false;
            }

            if (status.Status == StatusMicroondas.Aquecendo)
            {
                if (!programaPreDefinido && status.TempoRestante + 30 > 120)
                {
                    status.TempoRestante = 120;
                    return "Tempo máximo atingido.";
                }

                status.TempoRestante += 30;
                return "Tempo acrescido em 30 segundos.";
            }

            if (tempo <= 0)
                throw new ArgumentException("O tempo deve ser maior que zero.");

            if (tempo > 120 && !programaPreDefinido)
                throw new ArgumentException("O tempo deve ser no máximo 2 minutos segundos.");

            if (potencia < 1 || potencia > 10)
                throw new ArgumentException("A potência deve ser entre 1 e 10.");

            status.CaractereAquecimento = '.';

            status.TempoRestante = tempo;

            status.Potencia = potencia;

            status.TextoAquecimento = "Aquecendo";

            status.Status = StatusMicroondas.Aquecendo;

            return status.TextoAquecimento;
        }

        public string PausarOuCancelarAquecimento()
        {
            if (status.Status == StatusMicroondas.Aquecendo)
            {
                status.Status = StatusMicroondas.Pausado;
                status.TextoAquecimento = "Aquecimento pausado.";
                return status.TextoAquecimento;
            }

            if (status.Status == StatusMicroondas.Pausado)
            {
                LimparCampos();
                status.Status = StatusMicroondas.Cancelado;
                status.TextoAquecimento = "Aquecimento cancelado.";
                return status.TextoAquecimento;
            }

            return "Nenhum aquecimento em andamento para pausar ou cancelar.";

        }

        public AquecimentoStatus ObterStatusAquecimento()
        {
            return status;
        }

        public AquecimentoStatus ProcessarStatus()
        {
            if (status.Status != StatusMicroondas.Aquecendo)
                return status;

            status.TempoRestante--;

            status.ExibirAndamento += new string(status.CaractereAquecimento, status.Potencia) + " ";

            if (status.TempoRestante <= 0)
            {
                status.TextoAquecimento = "Aquecimento concluído.";
                status.ExibirAndamento += " Aquecimento concluído.";
                status.Status = StatusMicroondas.Concluido;
                status.TempoRestante = 0;
                status.Potencia = 0;
                status.Concluido = true;
            }

            return status;
        }

        public string IniciarProgramaAquecimento(ProgramaAquecimento programa)
        {
            if (status.Status == StatusMicroondas.Pausado)
            {
                status.Status = StatusMicroondas.Aquecendo;
                status.TextoAquecimento = "Aquecendo";

                return "Aquecimento retomado.";
            }

            status.Concluido = false;

            status.ExibirAndamento = "";

            status.TempoRestante =
                programa.Tempo;

            status.Potencia =
                programa.Potencia;

            status.CaractereAquecimento =
                programa.CaractereAquecimento;

            status.Status =
                StatusMicroondas.Aquecendo;

            status.TextoAquecimento =
                "Aquecendo";

            return status.TextoAquecimento;
        }

        public string FormatarTempo (int segundos)
        {
            TimeSpan tempo = TimeSpan.FromSeconds(segundos);
            return tempo.ToString(@"m\:ss");
        }

        public string RetomarAquecimento()
        {
            if (status.Status != StatusMicroondas.Pausado)
                return "Nenhum aquecimento pausado.";

            status.Status = StatusMicroondas.Aquecendo;

            status.TextoAquecimento = "Aquecendo";

            return "Aquecimento retomado.";
        }

        public string LimparCampos()
        {
            status.TempoRestante = 0;
            status.Potencia = 0;
            status.ExibirAndamento = "";
            status.TextoAquecimento = "";
            status.Status = StatusMicroondas.Parado;
            status.CaractereAquecimento = '.';
            return "Campos limpos. Pronto para um novo aquecimento.";
        }
    }
}
