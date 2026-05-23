using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microondas.Domain.Entities
{
    public class ProgramaAquecimento
    {
        public string Nome { get; set; }

        public string Alimento { get; set; }

        public int Tempo { get; set; }

        public int Potencia { get; set; }

        public char CaractereAquecimento { get; set; }

        public string Instrucoes { get; set; }

        public bool PreDefinido { get; set; }
    }
}
