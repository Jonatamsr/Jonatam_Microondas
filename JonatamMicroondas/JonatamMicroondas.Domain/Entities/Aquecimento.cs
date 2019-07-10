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
        public ProgramaAquecimento ProgramaAquecimento { get; set; }
    }
}
