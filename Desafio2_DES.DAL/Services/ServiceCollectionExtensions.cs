using Desafio2_DES.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio2_DES.DAL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseRepository, DatabaseRepository>();
            services.AddTransient<IEventoRepository, EventoRepository>();
            services.AddTransient<IParticipanteRepository, ParticipanteRepository>(); // ← agregar
            services.AddTransient<IOrganizadorRepository, OrganizadorRepository>();   // ← agregar

            return services;
        }
    }
}

