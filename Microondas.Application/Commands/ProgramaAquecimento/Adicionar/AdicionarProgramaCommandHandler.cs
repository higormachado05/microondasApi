using Microondas.Application.Repositories;
using Microondas.Domain.Exceptions;

namespace Microondas.Application.Commands.ProgramaAquecimento.Adicionar
{
    public class AdicionarProgramaCommandHandler
    {
        private readonly ProgramaAquecimentoRepository repository;
        public AdicionarProgramaCommandHandler(ProgramaAquecimentoRepository repository)
        {
            this.repository = repository;
        }
        public string Handle(AdicionarProgramaCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Nome))
            {
                throw new BusinessException(
                    "Nome é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(command.Alimento))
            {
                throw new BusinessException(
                    "Alimento é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(command.Tempo.ToString()))
            {
                throw new BusinessException(
                    "Tempo é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(command.Potencia.ToString()))
            {
                throw new BusinessException(
                    "Potência é obrigatória.");
            }

            if (string.IsNullOrWhiteSpace(command.CaractereAquecimento.ToString()) || command.CaractereAquecimento == '\0')
            {
                throw new BusinessException(
                    "Catactere é obrigatório.");
            }

            if (command.Potencia < 1 ||
                command.Potencia > 10)
            {
                throw new BusinessException(
                    "Potência inválida.");
            }

            if (command.CaractereAquecimento == '.')
            {
                throw new BusinessException(
                    "O caractere '.' é reservado.");
            }

            var existentes = repository.ObterTodos();

            if (existentes.Any(p =>
                p.CaractereAquecimento ==
                command.CaractereAquecimento))
            {
                throw new BusinessException(
                    "O caractere de aquecimento já está em uso por outro programa.");
            }

            var programa =
                new Domain.Entities.ProgramaAquecimento
                {
                    Nome = command.Nome,
                    Alimento = command.Alimento,
                    Tempo = command.Tempo,
                    Potencia = command.Potencia,
                    CaractereAquecimento = command.CaractereAquecimento,
                    Instrucoes = command.Instrucoes
                };

            repository.Adicionar(programa);

            return "Programa cadastrado com sucesso.";
        }
    }
}
