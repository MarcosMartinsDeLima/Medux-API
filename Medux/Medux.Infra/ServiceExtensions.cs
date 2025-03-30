using Medux.Domain.Models.Usuarios;
using Medux.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;


namespace Medux.Infra
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistance(this IServiceCollection services,string stringConexao,string nomeBanco) 
        {
            services.AddSingleton<IMongoClient>(ServiceProvider => new MongoClient(stringConexao));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>(ServiceProvider =>
                new UsuarioRepository(ServiceProvider.GetRequiredService<IMongoClient>(), nomeBanco, "Usuarios")
            );
        }
    }
}
