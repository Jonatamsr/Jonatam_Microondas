using System;
using System.ComponentModel.DataAnnotations;

namespace JonatamMicroondas.Domain.Entities
{
    public class ProgramaAquecimento
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Instrucao { get; set; }
        [Required]
        [Range(1, 120)]
        public int Tempo { get; set; }
        [Required]
        [Range(1, 10)]
        public int Potencia { get; set; }
        [Required]
        public char Caractere { get; set; }
    }
}