using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Service.Contracts;

public interface ICompanyService
{
    IEnumerable<Company> GetAllCompaniesAsync(bool trackChanges);
}