using Microondas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microondas.Application.Models
{
    public class AquecimentoStatus
    {
        public int TempoRestante { get; set; }

        public int Potencia { get; set; }

        public string TextoAquecimento { get; set; }

        public string ExibirAndamento { get; set; }

        public bool Concluido { get; set; }

        public StatusMicroondas Status { get; set; }

        public char CaractereAquecimento { get; set; }
    }
}
