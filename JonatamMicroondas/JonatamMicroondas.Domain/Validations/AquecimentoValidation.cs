using JonatamMicroondas.Domain.Entities;
using JonatamMicroondas.Domain.Exceptions;
using JonatamMicroondas.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonatamMicroondas.Domain.Validations
{
    public class AquecimentoValidation
    {
        public void ValidarTempo(int tempo)
        {
            if (tempo > 120)
            {
                throw new AquecimentoException("O tempo máximo é 2 minutos.");
            }
            else if (tempo < 1)
            {
                throw new AquecimentoException("O tempo mínimo é 1 segundo.");
            }
        }

        public void ValidarPotencia(int? potencia)
        {
            if (potencia > 10)
            {
                throw new AquecimentoException("A potência máxima é 10");
            }
            else if (potencia < 1)
            {
                throw new AquecimentoException("A potência mínima é 1");
            }
        }

        public ProgramaAquecimento ValidarPrograma(string programa)
        {
            ProgramaAquecimentoService programaAquecimentoService = new ProgramaAquecimentoService();

            var programaExiste = programaAquecimentoService.ProcurarPorPrograma(programa);
            if (programaExiste == null)
            {
                throw new AquecimentoException("Programa Incompatível");
            }
            return programaExiste;
        }
    }
}