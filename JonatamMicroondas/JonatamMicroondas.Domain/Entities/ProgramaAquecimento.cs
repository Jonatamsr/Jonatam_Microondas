using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonatamMicroondas.Domain.Entities
{
    public class ProgramaAquecimento
    {
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Instrucao { get; set; }
        [Required]
        [MaxLength]
        public String Tempo { get; set; }
        [Required]
        public String Potencia { get; set; }
        [Required]
        public char Caractere { get; set; }
    }
}
