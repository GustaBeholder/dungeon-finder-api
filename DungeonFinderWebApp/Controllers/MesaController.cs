using DungeonFinderWebApp.Domain.Interface.Services;
using DungeonFinderWebApp.Domain.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DungeonFinderWebApp.Controllers
{
    [Authorize]
    public class MesaController : Controller
    {
        private readonly IMesaService _mesaService;

        public MesaController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _CardsMesa(MesaRequest request)
        {
            request.Nome = "";
            var response = await _mesaService.getMesas(request);
            return PartialView(response);
        }
        public async Task<IActionResult> MesaDetails(int idMesa)
        {
            var response = await _mesaService.getMesaDetail(idMesa);
            return View(response.Response);
        }


        public IActionResult CreateMesa()
        {
            return View();
        }


        public async Task<JsonResult> CreateMesaFunc(CreateMesaRequest request)
        {

            var response = await _mesaService.createMesa(request);
            ViewBag.Message = response.Message;

            return Json(response);

        }
        [HttpPost]
        public async Task<IActionResult> _ListJogadoresMesa(MesaRequest request)
        {
            var response = await _mesaService.getJogadoresNaMesa(request.IdMesa);

            return PartialView(response);
        }

        public async Task<JsonResult> AddJogadorNaMesa(AddJogadorNaMesa request)
        {
            var response = await _mesaService.addJogadorNaMesa(request);
            ViewBag.Message = response.Message;

            return Json(response);

        }
    }
}
