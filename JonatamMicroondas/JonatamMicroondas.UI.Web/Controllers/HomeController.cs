using JonatamMicroondas.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static JonatamMicroondas.Domain.Services.ProgramaAquecimentoService;

namespace JonatamMicroondas.UI.Web.Controllers
{
    public class HomeController : Controller
    {
            ProgramaAquecimentoService programaAquecimentoService = new ProgramaAquecimentoService();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult IniciarAquecimento(string tempo, string potencia, string programa)
        {
            try
            {
                programaAquecimentoService.IniciarPrograma(tempo, potencia, programa);
            }
            catch (AquecimentoException e)
            {
                return ThrowJSONError(e);
            }
            return Json("");
        }

        [HttpPost]
        public JsonResult ObterStatusAquecimento()
        {
            if (programaAquecimentoService.ObterStatus())
            {
                return Json("aquecida");
            };
            return Json("em processo");
        }

        private JsonResult ThrowJSONError(Exception e)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            return Json(new { Message = e.Message });
        }
    }
}