using Api.Domain.Interfaces.Services.BarbecueService;
using Api.Domain.Interfaces.Services.Participants;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesServices(IServiceCollection services)
        {
            services.AddTransient<IBarbecueService, BarbecueService>();
            services.AddTransient<IParticipantService, ParticipantService>();
        }
    }
}
