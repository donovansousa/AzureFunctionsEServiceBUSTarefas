using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Data.ContextoDB
{
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        private IConfiguration configuration_;

        public ContextoFactory(IConfiguration configuration) => this.configuration_ = configuration;

        public Contexto CreateDbContext(string[] args)
        {
            string connectionstring = this.configuration_.GetConnectionString("Conexao");

            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseSqlServer(connectionstring).EnableDetailedErrors();

            return new Contexto(dbContextOptionsBuilder.Options);
        }
    }
}
