using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microondas.Application.Commands.Aquecimento.Iniciar
{
    public class IniciarAquecimentoCommand
    {
        public int? Tempo { get; set; }

        public int? Potencia { get; set; }

        public bool ProgramaPreDefinido { get; set; }
    }
}
