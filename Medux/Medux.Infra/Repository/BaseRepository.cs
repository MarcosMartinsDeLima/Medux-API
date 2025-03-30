using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medux.Domain.Models;
using Medux.Domain.Models.Usuarios;
using Medux.Infra.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Medux.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntidadeBase
    {
        private readonly IMongoCollection<T> _usuarios;

        public BaseRepository(IMongoClient mongoClient,string bancoNome,string nomeCollection)
        {
            var database = mongoClient.GetDatabase(bancoNome);
            _usuarios = database.GetCollection<T>(nomeCollection);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _usuarios.Find(usuario => true).ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return await _usuarios.Find(usuario => usuario.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Create(T entity)
        {
            entity.DataCriacao = DateTime.Now;

            try
            {
                await _usuarios.InsertOneAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                return false;
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                await _usuarios.ReplaceOneAsync(Usuario => Usuario.Id == entity.Id, entity);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                await _usuarios.DeleteOneAsync(usuario => usuario.Id == id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
