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

    public Company GetCompany(Guid companyId, bool trackChanges)
    =>FindByCondition(c=>c.Id.Equals(companyId),trackChanges)
    .SingleOrDefault();

    public void CreateCompany(Company company)
    =>Create(company);

    public IEnumerable<Company> GetById(IEnumerable<Guid> ids, bool trackChanges)
    => FindByCondition(c => ids.Contains(c.Id), trackChanges);
}