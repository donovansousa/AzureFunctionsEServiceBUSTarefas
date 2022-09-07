using Data.ContextoDB;
using Data.UnidadeDeTrabalho;
using Dominio.Interfaces.UnidadeDeTrabalho;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Ioc.Configuracao
{
    public static class ConfiguraIoc
    {
        public static void ConfigurarInjecaoDeDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigurarMediatR(services);
            ConfigurarUnidadeDeTrabalho(services, configuration);
        }

        private static void ConfigurarUnidadeDeTrabalho(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnidadeDeTrabalho>(c =>
            {
                return new UnidadeDeTrabalho(new ContextoFactory(configuration)
                                .CreateDbContext(null!));
            });
        }

        private static void ConfigurarMediatR(IServiceCollection services)
        {
            services.AddMediatR(typeof(Mediator));
        }
    }
}
