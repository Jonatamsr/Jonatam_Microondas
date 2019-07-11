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

        public Aquecimento IniciarAquecimento(int tempo, int? potencia)
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
                Potencia = potencia.Value
            };
            //var temporizador = new Timer(tempo * 1000);
            //temporizador.Elapsed += AquecimentoFinalizado;
            //temporizador.Start();
            Thread thread = new Thread(() => Aquecer(aquecimento));
            thread.Start();

            return aquecimento;
        }

        public Aquecimento IniciarAquecimentoRapido()
        {
            return IniciarAquecimento(30, 8);
        }

        private void Aquecer(Aquecimento aquecimento)
        {
            aquecimentos.Add(aquecimento);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            do
            {
                aquecimento.TempoDecorrido = (int)stopWatch.Elapsed.TotalSeconds;
                aquecimento.Progresso = string.Concat(Enumerable.Repeat(". ", aquecimento.Potencia * aquecimento.TempoDecorrido));
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
