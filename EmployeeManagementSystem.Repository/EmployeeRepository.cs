using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Repository;

public sealed class EmployeeRepository:RepositoryBase<Employee>,IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext context) : base(context)
    {
    }
}