using Medux.Application.Services;
using Medux.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Medux.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromForm]UsuarioDTO dto)
        {
            var resultado = await _usuarioService.CriarUsuario(dto);

            if (!resultado)
            {
                return BadRequest();
            }

            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _usuarioService.ListarUsuarios();

            if (resultado ==  null || !resultado.Any())
            {
                return NotFound();
            }

            return Ok(resultado);
        }
    }
}
