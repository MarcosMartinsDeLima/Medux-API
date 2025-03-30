using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medux.Domain.Models.Usuarios;
using Medux.Infra.Context;
using MongoDB.Driver;

namespace Medux.Infra.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>,IUsuarioRepository
    {
        public UsuarioRepository(IMongoClient mongoClient, string bancoNome, string nomeCollection) : base(mongoClient,bancoNome,nomeCollection) { }
    }
}
