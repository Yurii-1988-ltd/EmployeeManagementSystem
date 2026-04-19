using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Contracts;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
    Task<Company> GetCompany(Guid companyId, bool trackChanges);
    void CreateCompany(Company company);
    Task<IEnumerable<Company>>GetById(IEnumerable<Guid>ids, bool trackChanges);
    void Delete(Company company);
}