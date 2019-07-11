using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonatamMicroondas.Domain.Exceptions
{
    public class AquecimentoException : Exception
    {
        public AquecimentoException(string message) : base(message) { }
    }
}
