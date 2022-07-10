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
            MesaRequest request = new MesaRequest() { Sistema = 0, isAtivo = -1, IdMesa = 0, Nome=""};
            var response = await _mesaService.getMesas(request);
            return View(response);
        }

        public async Task<IActionResult> MesaDetails(int idMesa)
        {
            var response = await _mesaService.getMesaDetail(idMesa);
            return View(response.Response);
        }
    }
}
