using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonatamMicroondas.Domain.Entities
{
    public class Aquecimento
    {
        public Guid Id { get; set; }
        public bool Finalizado { get; set; }
        public int Tempo { get; set; }
        public int TempoDecorrido { get; set; }
        public int Potencia { get; set; }
        public string Progresso { get; set; }
        public char Caractere { get; set; }
        public ProgramaAquecimento ProgramaAquecimento { get; set; }
    }
}
