using DungeonFinderWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DungeonFinderWebApp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            UsuarioLogin login = new UsuarioLogin();
            return View(login);
        }
    }
}
