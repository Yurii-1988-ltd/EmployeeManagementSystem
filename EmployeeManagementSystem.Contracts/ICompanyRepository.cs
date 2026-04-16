using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Contracts;

public interface ICompanyRepository
{
    IEnumerable<Company> GetAllCompaniesAsync(bool trackChanges);
    Company GetCompany(Guid companyId, bool trackChanges);
    void CreateCompany(Company company);
    IEnumerable<Company>GetById(IEnumerable<Guid>ids, bool trackChanges);
}