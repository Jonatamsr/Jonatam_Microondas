using JonatamMicroondas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonatamMicroondas.Domain.Services
{
    public class ProgramaAquecimentoService
    {
        //Onde será armazenado os programas de aquecimento, por não poder utilizar BD
        private static List<ProgramaAquecimento> programasAquecimento = new List<ProgramaAquecimento>();

        public bool Criar(ProgramaAquecimento programaAquecimento)
        {
            if (programasAquecimento.SingleOrDefault(i => i.Nome == programaAquecimento.Nome) == null)
            {
                programasAquecimento.Add(programaAquecimento);
                return true;
            }
            return false;
        }

        public List<ProgramaAquecimento> Listar()
        {
            return programasAquecimento.ToList();
        }

        public ProgramaAquecimento ProcurarPorId(Guid id)
        {
            return programasAquecimento.SingleOrDefault(i => i.Id == id);
        }

        public ProgramaAquecimento ProcurarPorPrograma(string programa)
        {
            return programasAquecimento.SingleOrDefault(i => i.Nome == programa);
        }
    }
}
