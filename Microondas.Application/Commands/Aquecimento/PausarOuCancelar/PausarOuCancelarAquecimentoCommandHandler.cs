using Microondas.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microondas.Application.Commands.Aquecimento.Pausar
{
    public class PausarOuCancelarAquecimentoCommandHandler
    {
        private readonly MicroondasService service;

        public PausarOuCancelarAquecimentoCommandHandler(MicroondasService service)
        {
            this.service = service;
        }

        public string Handle(PausarOuCancelarAquecimentoCommand command)
        {
            return service.PausarOuCancelarAquecimento();
        }
    }
}
