using CrossCutting.Ioc.Configuracao;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

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
