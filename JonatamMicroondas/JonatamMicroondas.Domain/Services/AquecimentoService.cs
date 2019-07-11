using JonatamMicroondas.Domain.Entities;
using JonatamMicroondas.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace JonatamMicroondas.Domain.Services
{
    public class AquecimentoService
    {
        //Normalmente seria utilizado injeção de dependência. Por questões de tempo fiz a instância diretamente.
        private AquecimentoValidation aquecimentoValidation = new AquecimentoValidation();
        private static List<Aquecimento> aquecimentos = new List<Aquecimento>();

        public Aquecimento IniciarAquecimento(int tempo, int? potencia, string programa, char caractere)
        {
            if (!string.IsNullOrEmpty(programa))
            {
                var programaAquecimento = aquecimentoValidation.ValidarPrograma(programa);
                var aquecimento = new Aquecimento()
                {
                    Id = Guid.NewGuid(),
                    Tempo = programaAquecimento.Tempo,
                    Potencia = programaAquecimento.Potencia,
                    Caractere = programaAquecimento.Caractere
                };
                aquecimento.Progresso = programaAquecimento.Nome + " ";
                Thread thread = new Thread(() => Aquecer(aquecimento));
                thread.Start();

                return aquecimento;
            }
            else
            {
                aquecimentoValidation.ValidarTempo(tempo);

                if (potencia.HasValue)
                {
                    aquecimentoValidation.ValidarPotencia(potencia.Value);
                }
                else
                {
                    potencia = 10;
                }

                var aquecimento = new Aquecimento()
                {
                    Id = Guid.NewGuid(),
                    Tempo = tempo,
                    Potencia = potencia.Value,
                    Caractere = caractere
                };
                Thread thread = new Thread(() => Aquecer(aquecimento));
                thread.Start();

                return aquecimento;
            }

        }


        public Aquecimento IniciarAquecimentoRapido()
        {
            return IniciarAquecimento(30, 8, "", '0');
        }

        private void Aquecer(Aquecimento aquecimento)
        {
            aquecimentos.Add(aquecimento);
            var programa = aquecimento.Progresso;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            do
            {
                aquecimento.TempoDecorrido = (int)stopWatch.Elapsed.TotalSeconds;
                if (char.IsLetter(aquecimento.Caractere))
                {
                    aquecimento.Progresso = programa + string.Concat(Enumerable.Repeat(aquecimento.Caractere + " ", aquecimento.Potencia * aquecimento.TempoDecorrido));
                }
                else
                {
                    aquecimento.Progresso = string.Concat(Enumerable.Repeat(". ", aquecimento.Potencia * aquecimento.TempoDecorrido));
                }
            }
            while (aquecimento.TempoDecorrido < aquecimento.Tempo);

            stopWatch.Stop();

            aquecimento.Finalizado = true;
            aquecimento.Progresso += " Aquecido";
        }

        public Aquecimento ObterAquecimento(Guid id)
        {
            return aquecimentos.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
