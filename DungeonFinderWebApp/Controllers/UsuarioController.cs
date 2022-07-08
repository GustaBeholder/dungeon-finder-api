using DungeonFinderWebApp.Domain.Interface.Service;
using DungeonFinderWebApp.Domain.Models.Entities;
using DungeonFinderWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DungeonFinderWebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILoginService _loginService;

        public UsuarioController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<IActionResult> Login(LoginModel usuarioLogin)
        {
            if(!ModelState.IsValid) return View(usuarioLogin);

            var reponse = await _loginService.Login(usuarioLogin);

            return RedirectToAction("Index", "Home");
        }
    }
}
