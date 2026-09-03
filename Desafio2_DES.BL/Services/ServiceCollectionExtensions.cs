using Desafio2_DES.BL.Interfaces;
using Desafio2_DES.BL.Profiles;
using Desafio2_DES.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio2_DES.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<EventoProfile>();
                cfg.AddProfile<ParticipanteProfile>();
                cfg.AddProfile<OrganizadorProfile>();
            });

            services.AddTransient<IEventoService, EventoService>();
            services.AddTransient<IParticipanteService, ParticipanteService>();
            services.AddTransient<IOrganizadorService, OrganizadorService>();

            return services;
        }
    }
}
