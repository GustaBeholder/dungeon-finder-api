
using DungeonFinderDomain.Model.Response;
using Microsoft.AspNetCore.Mvc;
using DungeonFinderDomain.Model.Requests;
using DungeonFinderDomain.Interface.Service;

namespace DungeonFinderAPI.Controller
{
    [ApiController]
    [Route("api/Mesas")]
    public class MesasController : ControllerBase
    {
        private readonly IMesaService _mesaService;

        public MesasController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }
        [HttpGet("GetMesa/{idMesa}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MesaResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type=  typeof(BaseResponse))]
        public IActionResult GetMesaDetails(int idMesa)
        {
            var response = _mesaService.getMesaDetails(idMesa);

            if (response.Response != null) return Ok(response);

            return  BadRequest(response);
        }

        [HttpPost("GetMesa")]
        [ProducesResponseType(typeof(MesaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetMesas([FromBody] MesaRequest request)
        {
            var response = _mesaService.getMesas(request);

            if(response.Items != null) return Ok(response.Items);

            return BadRequest(response);

        }

        [HttpGet("GetJogadoresNaMesa/{idMesa}")]
        [ProducesResponseType(typeof(JogadorNaMesaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetJogadoresNaMesa(int idMesa)
        {
            var response = _mesaService.getJogadoresNaMesa(idMesa);

            if (response.Items != null) return Ok(response.Items);

            return BadRequest(response);

        }

        [HttpPost("CreateMesa")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetMesas([FromBody] MesaCreateRequest request)
        {
            var response = _mesaService.createMesa(request);

            if (response.ErrorCode == 201) return Ok(response);

            return BadRequest(response);

        }

        [HttpPost("JogadorMesa")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult InsertJogadorNaMesa([FromBody] JogadorNaMesaRequest request)
        {
            var response = _mesaService.createJogadorNaMesa(request);

            if (response.ErrorCode == 201) return Ok(response);

            return BadRequest(response);

        }
        [HttpDelete("JogadorMesa")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult RemoveJogadorNaMesa([FromBody] JogadorNaMesaRequest request)
        {
            var response = _mesaService.RemoveJogadorDaMesa(request);

            if (response.ErrorCode == 201) return Ok(response);

            return BadRequest(response);

        }

        [HttpPut("UpdateMesa")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult UpdateMesa([FromBody] UpdateMesa request)
        {
            var response = _mesaService.updateMesa(request);

            if (response.ErrorCode == 201) return Ok(response);

            return BadRequest(response);

        }

    }
}
