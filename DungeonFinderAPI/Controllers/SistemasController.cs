using DungeonFinderDomain.Model.Response;
using Microsoft.AspNetCore.Mvc;
using DungeonFinderDomain.Model.Requests;
using DungeonFinderDomain.Interface.Service;
using DungeonFinderDomain.Model.Entities;

namespace DungeonFinderAPI.Controller
{
    [ApiController]
    [Route("api/Sistemas")]
    public class SistemasController : ControllerBase
    {
        private readonly ISistemaService _sistemaService;

        public SistemasController(ISistemaService sistemaService)
        {
            _sistemaService = sistemaService;
        }

        [HttpGet("GetSistema")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Sistema))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetListSistemas()
        {
            var response = _sistemaService.getListSistemas();

            if (response.Items != null) return Ok(response.Items);

            return BadRequest(response);
        }

        [HttpGet("GetSistema/{idSistema}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Sistema))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetSistema(int idSistema)
        {
            var response = _sistemaService.getSistema(idSistema);

            if (response.Response != null) return Ok(response);

            return BadRequest(response);
        }

    }
}
