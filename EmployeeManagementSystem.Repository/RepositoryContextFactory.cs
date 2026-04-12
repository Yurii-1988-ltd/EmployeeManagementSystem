using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;



namespace EmployeeManagementSystem.Repository;

public sealed class RepositoryContextFactory: IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<RepositoryContext>();
        builder.UseSqlServer("Server=DESKTOP-CR0ELGM;Database=CompanyEmployees;Trusted_Connection=True; Integrated Security=True; TrustServerCertificate=True");
        return new RepositoryContext(builder.Options);
  
    }
}