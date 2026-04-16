using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Repository;

public sealed class EmployeeRepository:RepositoryBase<Employee>,IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateEmployeeForCompany(Guid companyId, Employee employee)
    {
        employee.CompanyId = companyId;
        Create(employee);
     
    }

    public IEnumerable<Employee> GetAllEmployeesAsync(Guid companyId, bool trackChanges)
    => FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
        .OrderBy(e => e.Name)
        .ToList();

    public Employee GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
    => FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}