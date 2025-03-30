using Medux.Application.Services;
using Medux.Infra.Context;
using Medux.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Medux.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
