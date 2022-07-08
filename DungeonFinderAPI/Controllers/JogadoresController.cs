using DungeonFinderDomain.Interface.Service;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace DungeonFinderAPI.Controllers
{
    [ApiController]
    [Route("api/Jogadores")]
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadorService _jogadorService;
        public JogadoresController(IJogadorService jogadorService)
        {
            _jogadorService = jogadorService;   
        }

        [HttpGet("GetJogador")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Jogador))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetListJogador()
        {
            var response = _jogadorService.getJogadorList();

            if (response.Items != null) return Ok(response.Items);

            return BadRequest(response);
        }

        [HttpGet("GetJogadorByIdUsuario/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<Jogador>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetJogador(int idUsuario)
        {
            var response = _jogadorService.getJogador(idUsuario);

            if (response.Response != null) return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("GetJogadorByIdJogador/{idJogador}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<Jogador>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetJogadorById(int idJogador)
        {
            var response = _jogadorService.getJogador(idJogador);

            if (response.Response != null) return Ok(response);

            return BadRequest(response);
        }


    }
}
