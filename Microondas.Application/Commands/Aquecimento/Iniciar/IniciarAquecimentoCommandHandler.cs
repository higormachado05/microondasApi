using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microondas.Application.Services;
using Microondas.Domain.Enums;

namespace Microondas.Application.Commands.Aquecimento.Iniciar
{
    public class IniciarAquecimentoCommandHandler
    {
        private readonly MicroondasService service;

        public IniciarAquecimentoCommandHandler(MicroondasService service)
        {
            this.service = service;
        }

        public string Handle(IniciarAquecimentoCommand command)
        {
            var status = service.ObterStatusAquecimento();

            if (status.Status == StatusMicroondas.Pausado)
                return service.RetomarAquecimento();


            // Início rápido
            if (command.Tempo == null && command.Potencia == null)
                return service.IniciarAquecimento(30, 10, false);


            // Tempo obrigatório
            if (command.Tempo == null)
                throw new ArgumentException("O campo de tempo está vazio.");


            int tempo = command.Tempo.Value;

            int potencia = command.Potencia ?? 10;

            if (command.ProgramaPreDefinido)
                return service.IniciarAquecimento(tempo, potencia, true);

            if (status.Status == StatusMicroondas.Concluido)
            {
                return service.IniciarAquecimento(tempo, potencia, false);
            }

            return service.IniciarAquecimento(tempo, potencia, false);
        }
    }
}
