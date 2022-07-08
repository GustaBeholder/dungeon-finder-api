using DungeonFinderDomain.Interface.Service;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace DungeonFinderAPI.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpPost("CreateUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult CreateUsuario([FromBody] Usuario request)
        {
            var response = _usuarioService.createUsuario(request);

            if (response.ErrorCode == 0) return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("GetUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<Usuario>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        public IActionResult GetUsuario([FromBody] Usuario request)
        {
            var response = _usuarioService.getusuario(request);

            if (response.BaseResponse.ErrorCode == 0) return Ok(response);

            return BadRequest(response.BaseResponse);
        }
    }
}
