using DungeonFinderAPI.Interface;
using DungeonFinderAPI.Model.Requests;
using DungeonFinderAPI.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace DungeonFinderAPI.Controller
{
    [ApiController]
    [Route("Mesas")]
    public class MesaController : ControllerBase
    {
        private readonly IMesaRepository _mesaRepository;

        public MesaController(IMesaRepository mesaRepository)
        {
            _mesaRepository = mesaRepository;
        }
        [HttpGet("GetMesa/{idMesa}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MesaResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetMesaDetails(int idMesa)
        {
            var response = _mesaRepository.getMesaDetails(idMesa);

            if (response.IdMesa != 0) return Ok(response);

            var resp = new
            {
                response.ErrorCode,
                response.Message
            };
            return BadRequest(resp);
        }

        [HttpPost("GetMesa")]
        [ProducesResponseType(typeof(MesaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetMesas([FromBody] MesaRequest request)
        {
            var response = _mesaRepository.getMesas(request);

            if(response.Items != null) return Ok(response.Items);

            return BadRequest(response);

        }

        [HttpGet("GetJogadoresNaMesa/{idMesa}")]
        [ProducesResponseType(typeof(JogadorNaMesaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetJogadoresNaMesa(int idMesa)
        {
            var response = _mesaRepository.getJogadoresNaMesa(idMesa);

            if (response.Items != null) return Ok(response.Items);

            return BadRequest(response);

        }

        [HttpPost("CreateMesa")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetMesas([FromBody] MesaCreateRequest request)
        {
            var response = _mesaRepository.createMesa(request);

            if (response.ErrorCode == 201) return Ok(response);

            return BadRequest(response);

        }
    }
}
