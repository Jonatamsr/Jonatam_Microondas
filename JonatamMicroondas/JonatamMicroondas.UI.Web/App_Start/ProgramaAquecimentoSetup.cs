using JonatamMicroondas.Domain.Entities;
using JonatamMicroondas.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonatamMicroondas.UI.Web.App_Start
{
    public static class ProgramaAquecimentoSetup
    {
        static ProgramaAquecimentoService programaAquecimentoService = new ProgramaAquecimentoService();
        public static void Init()
        {
            ProgramaAquecimento programaAquecimento = new ProgramaAquecimento()
            {
                Id = Guid.NewGuid(),
                Nome = "Frango",
                Instrucao = "Frango Congelado. Descongelar o frango por 30 minutos fora da geladeira e inserí-lo no microondas por 2 minutos.",
                Tempo = 120,
                Potencia = 10,
                Caractere = 'F'
            };

            programaAquecimentoService.Criar(programaAquecimento);

            programaAquecimento = new ProgramaAquecimento()
            {
                Id = Guid.NewGuid(),
                Nome = "Frango Descongelado",
                Instrucao = "Frango Descongelado. Aquecer no microondas por 50 segundos em potência 3.",
                Tempo = 50,
                Potencia = 3,
                Caractere = 'D'
            };

            programaAquecimentoService.Criar(programaAquecimento);

            programaAquecimento = new ProgramaAquecimento()
            {
                Id = Guid.NewGuid(),
                Nome = "Carne",
                Instrucao = "Remover a gordura da carne de aquecer por 2 minutos, em potência 2.",
                Tempo = 120,
                Potencia = 2,
                Caractere = 'C'
            };

            programaAquecimentoService.Criar(programaAquecimento);

            programaAquecimento = new ProgramaAquecimento()
            {
                Id = Guid.NewGuid(),
                Nome = "Pipoca",
                Instrucao = "Inserir o pacote de pipoca no microondas com as abas para cima e aquecer por 1 minuto, com potência em 5.",
                Tempo = 60,
                Potencia = 5,
                Caractere = 'P'
            };

            programaAquecimentoService.Criar(programaAquecimento);

            programaAquecimento = new ProgramaAquecimento()
            {
                Id = Guid.NewGuid(),
                Nome = "Chá",
                Instrucao = "Inserir a xícara no microondas com o sache de chá, aquecendo-a por 34 segundos, em potência 9.",
                Tempo = 34,
                Potencia = 9,
                Caractere = 'X'
            };

            programaAquecimentoService.Criar(programaAquecimento);
        }
    }
}