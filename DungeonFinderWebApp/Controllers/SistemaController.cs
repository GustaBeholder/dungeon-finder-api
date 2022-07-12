using DungeonFinderWebApp.Domain.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace DungeonFinderWebApp.Controllers
{
    public class SistemaController : Controller
    {
        private readonly ISistemaService _sistemaService;

        public SistemaController(ISistemaService sistemaService)
        {
            _sistemaService = sistemaService;
        }

        public async Task<JsonResult> GetSistemas()
        {
            var response =  await _sistemaService.getSistemas();
            return Json(response);
        }
    }
}
