using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medux.Domain.Models.Usuarios;

namespace Medux.Infra.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
    }
}
