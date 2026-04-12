using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Domain.Entities;

namespace EmployeeManagementSystem.Repository;

public sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext context) : base(context)
    {
    }

    public IEnumerable<Company> GetAllCompaniesAsync(bool trackChanges)
    => FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToList();
  
}