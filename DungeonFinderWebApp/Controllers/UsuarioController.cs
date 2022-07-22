using DungeonFinderWebApp.Domain.Interface.Services;
using DungeonFinderWebApp.Domain.Models.Request;
using DungeonFinderWebApp.Domain.Models.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DungeonFinderWebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILoginService _loginService;

        public UsuarioController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if(!ModelState.IsValid) return View(request);

            var response = await _loginService.Login(request);
            if (response.BaseResponse.ErrorCode == 0)
            {
                await RealizarLogin(response.Response);
                return RedirectToAction("Index", "Mesa");
            }
            ViewBag.Message = response.BaseResponse.Message;
            return View(request);
        }
        
        [HttpPost]
        public async Task<JsonResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid) return Json(request);
            var response = await _loginService.Register(request);

            if(response.ErrorCode == 0)
            {
                LoginRequest loginRequest = new LoginRequest()
                {
                    Email = request.Email,
                    Password = request.Password
                };
                var login = await _loginService.Login(loginRequest);
                await RealizarLogin(login.Response) ;
                RedirectToAction("Index", "Mesa");
                return Json(response);
            }
            ViewBag.Message = response.Message;
            return Json(request);
        }

        public async Task<IActionResult> LogOut()
        {
   
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }


        [HttpPost("UploadProfilePic")]
        public async Task<BaseResponse> UploadProfilePic(IEnumerable<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            MemoryStream ms = new MemoryStream();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    formFile.OpenReadStream().CopyTo(ms);
                    var data = ms.ToArray();

                    CreateFileRequest request = new CreateFileRequest(formFile.FileName, data, formFile.ContentType);

                    string fileName = CreateArquivo(request);

                    BaseResponse response = new BaseResponse()
                    {
                        ErrorCode = 0,
                        Message = fileName
                    };

                    return response;
                }
            }

            return null;
        }

        public string CreateArquivo(CreateFileRequest request)
        {
            request.FileName = Guid.NewGuid().ToString();
            string path = $"wwwroot\\img\\users\\{request.FileName}.{request.ContentType.Split("/")[1]}";
            string fileName = $"{request.FileName}.{request.ContentType.Split("/")[1]}";
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                stream.Write(request.Data);
            }
            return fileName;
        }

        private async Task RealizarLogin(LoginResponse response)
        {

            var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(response.IdUsuario)),
                        new Claim(ClaimTypes.Name, response.Nome),
                        new Claim("JogadorId", Convert.ToString(response.IdJogador)),
                        new Claim("Email", response.Email),
                        new Claim("Nome", response.Nome),
                        new Claim("UserId", Convert.ToString(response.IdUsuario))
                };
            //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
            var principal = new ClaimsPrincipal(identity);
            //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties());
        }
    }
}
