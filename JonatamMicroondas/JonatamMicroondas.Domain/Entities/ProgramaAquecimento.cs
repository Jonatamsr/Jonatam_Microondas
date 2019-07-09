using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonatamMicroondas.Domain.Entities
{
    class ProgramaAquecimento
    {
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public DateTime Tempo { get; set; }
        public int Potencia { get; set; }
    }
}
