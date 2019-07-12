using JonatamMicroondas.Domain.Entities;
using JonatamMicroondas.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JonatamMicroondas.UI.Web.Controllers
{
    public class ProgramaAquecimentoController : Controller
    {
        ProgramaAquecimentoService programaAquecimentoService = new ProgramaAquecimentoService();
        AquecimentoService aquecimentoService = new AquecimentoService();

        // GET: ProgramaAquecimento
        public ActionResult Index()
        {
            return View(programaAquecimentoService.Listar());
        }

        // GET: ProgramaAquecimento/Criar
        public ActionResult Criar()
        {
            return View();
        }

        // POST: ProgramaAquecimento/Criar
        [HttpPost]
        public ActionResult Criar(ProgramaAquecimento programaAquecimento)
        {
            programaAquecimento.Id = Guid.NewGuid();
            if (programaAquecimentoService.Criar(programaAquecimento))
            {
                TempData["Status"] = "Programa de Aquecimento Cadastrado com Sucesso.";
            }
            else
            {
                TempData["Status"] = "Programa Já Existe.";
            }
            return RedirectToAction("Index", "ProgramaAquecimento");
        }

        public ActionResult Executar(Guid id)
        {
            var programaAquecimento = programaAquecimentoService.ProcurarPorId(id);
            var programa = new
            {
                programa = programaAquecimento.Nome,
                tempo = programaAquecimento.Tempo,
                potencia = programaAquecimento.Potencia,
                caractere = programaAquecimento.Caractere
            };
            return RedirectToAction("Index", "Home", programa);
        }
    }
}
