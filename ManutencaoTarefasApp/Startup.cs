using CrossCutting.Ioc.Configuracao;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ManutencaoTarefasApp.Startup))]

namespace ManutencaoTarefasApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.ConfigurarInjecaoDeDependencia(builder.GetContext().Configuration);
        }
    }
}
