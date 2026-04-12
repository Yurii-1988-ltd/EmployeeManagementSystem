using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Contracts;

public interface ICompanyRepository
{
    IEnumerable<Company> GetAllCompaniesAsync(bool trackChanges);
}