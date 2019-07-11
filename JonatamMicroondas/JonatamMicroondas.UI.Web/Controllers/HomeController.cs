using JonatamMicroondas.Domain.Entities;
using JonatamMicroondas.Domain.Exceptions;
using JonatamMicroondas.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JonatamMicroondas.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        //Normalmente seria utilizado injeção de dependência. Por questões de tempo fiz a instância diretamente.
        AquecimentoService aquecimentoService = new AquecimentoService();
        ProgramaAquecimentoService programaAquecimentoService = new ProgramaAquecimentoService();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult IniciarAquecimento(int tempo, int? potencia, string programa, char caractere)
        {
            try
            {
                var aquecimento = aquecimentoService.IniciarAquecimento(tempo, potencia, programa, caractere);
                return Json(aquecimento);
            }
            catch (AquecimentoException e)
            {
                return ThrowJSONError(e);
            }
        }

        [HttpPost]
        public JsonResult IniciarAquecimentoRapido()
        {
            try
            {
                var aquecimento = aquecimentoService.IniciarAquecimentoRapido();
                return Json(aquecimento);
            }
            catch (AquecimentoException e)
            {
                return ThrowJSONError(e);
            }
        }

        [HttpPost]
        public JsonResult ObterAquecimento(Guid id)
        {
            try
            {
                var aquecimento = aquecimentoService.ObterAquecimento(id);
                return Json(aquecimento);
            }
            catch (Exception e)
            {
                return ThrowJSONError(e);
            }
        }

        private JsonResult ThrowJSONError(Exception e)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            return Json(new { Message = e.Message });
        }
    }
}