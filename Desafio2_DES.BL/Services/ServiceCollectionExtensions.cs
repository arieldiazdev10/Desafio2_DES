using Desafio2_DES.BL.Interfaces;
using Desafio2_DES.BL.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio2_DES.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<EventoProfile>());
            services.AddTransient<IEventoService, EventoService>();
            return services;
        }
        }
}
