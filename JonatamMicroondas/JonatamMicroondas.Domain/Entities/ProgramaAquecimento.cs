using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonatamMicroondas.Domain.Entities
{
    public class ProgramaAquecimento
    {
        public String Nome { get; set; }
        public String Instrucao { get; set; }
        public String Tempo { get; set; }
        public String Potencia { get; set; }
        public char Caractere { get; set; }
    }
}
