using DungeonFinderDomain.Interface.Service;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Requests;
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
        public IActionResult CreateUsuario([FromBody] CreateUserRequest request)
        {
            var response = _usuarioService.createUsuario(request);

            if (response.ErrorCode == 0) return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("GetUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<Usuario>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse<Usuario>))]
        public IActionResult GetUsuario([FromBody] UserLoginRequest request)
        {
            var response = _usuarioService.getUsuario(request);

            if (response.BaseResponse.ErrorCode == 0) return Ok(response);

            return BadRequest(response);
        }
    }
}
