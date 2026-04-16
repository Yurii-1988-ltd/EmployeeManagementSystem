using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Contracts;

public interface IEmployeeRepository
{
    IEnumerable<Employee>GetAllEmployeesAsync(Guid companyId, bool trackChanges);
    Employee GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
    void CreateEmployeeForCompany(Guid  companyId, Employee employee);
    
}