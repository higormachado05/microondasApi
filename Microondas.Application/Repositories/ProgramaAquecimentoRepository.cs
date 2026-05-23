using Microondas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microondas.Application.Repositories
{
    public class ProgramaAquecimentoRepository
    {
        private readonly List<ProgramaAquecimento> programas = new List<ProgramaAquecimento>();

        private readonly string customProgramsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "custom_programs.json");

        public ProgramaAquecimentoRepository()
        {
            // pré-definidos
            programas.AddRange(new[]
            {
                new ProgramaAquecimento
                {
                    Nome = "Pipoca",
                    Alimento = "Pipoca de micro-ondas",
                    Tempo = 180,
                    Potencia = 7,
                    CaractereAquecimento = '*',
                    Instrucoes =
                        "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos " +
                        "entre um estouro e outro, interrompa o aquecimento.",
                    PreDefinido = true
                },
                new ProgramaAquecimento
                {
                    Nome = "Leite",
                    Alimento = "Leite",
                    Tempo = 300,
                    Potencia = 5,
                    CaractereAquecimento = '~',
                    Instrucoes =
                        "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode" +
                        " causar fervura imediata causando risco de queimaduras.",
                    PreDefinido = true
                },
                new ProgramaAquecimento
                {
                    Nome = "Carnes de boi",
                    Alimento = "Carne em pedaço ou fatias",
                    Tempo = 840,
                    Potencia = 4,
                    CaractereAquecimento = '´',
                    Instrucoes =
                        "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o" +
                        " descongelamento uniforme.",
                    PreDefinido = true
                },
                new ProgramaAquecimento
                {
                    Nome = "Frango",
                    Alimento = "Frango (qualquer corte)",
                    Tempo = 480,
                    Potencia = 7,
                    CaractereAquecimento = '#',
                    Instrucoes =
                        "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o" +
                        " descongelamento uniforme.",
                    PreDefinido = true
                },
                new ProgramaAquecimento
                {
                    Nome = "Feijão",
                    Alimento = "Feijão congelado",
                    Tempo = 480,
                    Potencia = 9,
                    CaractereAquecimento = '$',
                    Instrucoes =
                        "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o" +
                        " mesmo pode perder resistência em altas temperaturas.",
                    PreDefinido = true
                },
            });

            var customs = LoadCustomPrograms();
            foreach (var c in customs)
            {
                c.PreDefinido = false;
                programas.Add(c);
            }
        }

        public List<ProgramaAquecimento> ObterTodos()
        {
            return programas.ToList();
        }

        public void Adicionar(ProgramaAquecimento programa)
        {
            if (programa == null)
                throw new ArgumentNullException(nameof(programa));

            if (programa.CaractereAquecimento == '.')
                throw new ArgumentException("Caractere de aquecimento inválido.", nameof(programa));

            if (programas.Any(p => p.CaractereAquecimento == programa.CaractereAquecimento))
                throw new ArgumentException(
                    $"Já existe um programa com o caractere '{programa.CaractereAquecimento}'.",
                    nameof(programa));

            programa.PreDefinido = false;
            programas.Add(programa);
            SaveCustomPrograms();
        }

        private void SaveCustomPrograms()
        {
            try
            {
                var customs = programas.Where(p => !p.PreDefinido).ToList();
                var json = JsonSerializer.Serialize(customs, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(customProgramsPath, json);
            }
            catch
            {
            }
        }

        private List<ProgramaAquecimento> LoadCustomPrograms()
        {
            try
            {
                if (!File.Exists(customProgramsPath))
                    return new List<ProgramaAquecimento>();

                var json = File.ReadAllText(customProgramsPath);
                var list = JsonSerializer.Deserialize<List<ProgramaAquecimento>>(json);
                return list ?? new List<ProgramaAquecimento>();
            }
            catch
            {
                return new List<ProgramaAquecimento>();
            }
        }
    }
}
