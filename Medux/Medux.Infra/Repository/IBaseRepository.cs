using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medux.Domain.Models;

namespace Medux.Infra.Repository
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetById(string id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(string id);
    }
}
