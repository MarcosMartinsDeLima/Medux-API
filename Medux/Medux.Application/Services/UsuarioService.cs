using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Medux.Domain.DTO;
using Medux.Domain.Models.Usuarios;
using Medux.Infra.Repository;
using MongoDB.Bson;

namespace Medux.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        public async Task<bool> CriarUsuario(UsuarioDTO dto)
        {
            MemoryStream stream = new MemoryStream();

            dto.Imagem.CopyTo(stream);

            var entidade = new Usuario()
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
                Imagem = stream.ToArray(),
                Id = null
            };

            var senhaEncriptada = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

            entidade.Senha = senhaEncriptada;

            return await _repository.Create(entidade);
        }


        public async Task<List<Usuario>> ListarUsuarios()
        {
            return await _repository.GetAllAsync();
        }
    }
}
