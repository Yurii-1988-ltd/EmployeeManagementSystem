using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository;

public sealed class RepositoryContext : DbContext
{
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Employee> Employees => Set<Employee>();

    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
        
    }

}