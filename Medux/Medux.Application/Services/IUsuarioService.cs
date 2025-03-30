using Medux.Domain.DTO;
using Medux.Domain.Models.Usuarios;

namespace Medux.Application.Services
{
    public interface IUsuarioService
    {
        Task<bool> CriarUsuario(UsuarioDTO dto);
        Task<List<Usuario>> ListarUsuarios();
    }
}
