using DungeonFinderWebApp.Domain.Interface.Services;
using DungeonFinderWebApp.Domain.Models.Request;
using DungeonFinderWebApp.Domain.Models.Response;
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

        [HttpPost("UploadProilePic")]
        public async Task<BaseResponse> UploadProilePic(IEnumerable<IFormFile> files)
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
            string path = $"wwwroot\\img\\mesas\\{request.FileName}.{request.ContentType.Split("/")[1]}";
            string fileName = $"{request.FileName}.{request.ContentType.Split("/")[1]}";
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                stream.Write(request.Data);
            }
            return fileName;
        }
    }
}
