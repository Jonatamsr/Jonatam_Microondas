using JonatamMicroondas.Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace JonatamMicroondas.Domain.Services
{
    public class ProgramaAquecimentoService
    {
        private static Timer temporizador;
        private static int contador = 0;
        private static int tempoValue;

        public class AquecimentoException : Exception
        {
            public AquecimentoException(string message) : base(message)
            {

            }
        }

        public void IniciarPrograma(string tempo, string potencia, string programa)
        {
            if (programa.Length != 0)
            {
                //implementar programa
            }
            else
            {
                if (!int.TryParse(tempo, out int tempoInt))
                {
                    throw new AquecimentoException("Tempo não informado ou inválido.");
                }
                if (!int.TryParse(potencia, out int potenciaInt))
                {
                    if (potencia.Length == 0)
                    {
                        potenciaInt = 10;
                    }
                    else
                    {
                        throw new AquecimentoException("Potência inválida.");
                    }
                }
                if (ValidaTempo(tempoInt) && ValidaPotencia(potenciaInt))
                {
                    IniciarTemporizador();
                    tempoValue = tempoInt;
                }
            }
        }
        private void IniciarTemporizador()
        {
            temporizador = new Timer(1000);
            temporizador.Elapsed += AdicionarCaractere;
            temporizador.AutoReset = true;
            temporizador.Start();
            contador = 0;
        }

        private void AdicionarCaractere(Object source, ElapsedEventArgs e)
        {
            contador += 1000;
        }
        public bool ObterStatus()
        {
            if (contador >= tempoValue)
            {
                temporizador.Stop();
                temporizador.Dispose();
                contador = 0;
                return true;
            }
            return false;
        }

        #region Validação
        public bool ValidaTempo(int tempo)
        {
            if (tempo > 120000)
            {
                throw new AquecimentoException("O tempo máximo é 2 minutos.");
            }
            else if (tempo < 1000)
            {
                throw new AquecimentoException("O tempo mínimo é 1 segundo.");
            }
            else
            {
                return true;
            }
        }
        public bool ValidaPotencia(int potencia)
        {
            if (potencia > 10)
            {
                throw new AquecimentoException("A potência máxima é 10");
            }
            else if (potencia < 1)
            {
                throw new AquecimentoException("A potência mínima é 1");
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}