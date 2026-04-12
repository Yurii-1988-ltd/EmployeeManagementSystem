using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagementSystem.Repository.Extensions;

public static class GetDbConnectionExtension
{
    public static void ConfigureDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")
                ,b=>b.MigrationsAssembly("EmployeeManagementSystem"));
        });
        
        
    }
    
    
}