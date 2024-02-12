using LibraryManagement.Infra.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.API.Configuration;

public static class SqlServerConfiguration
{
    public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryManagementContext>(options => options.UseSqlServer(configuration["ConnectionStrings:Default"],x=>x.MigrationsAssembly("LibraryManagement.Infra.Domain")));
    }
}
