using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository;

public sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges)
    => await FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToListAsync();

    public async Task<Company> GetCompany(Guid companyId, bool trackChanges)
    => await FindByCondition(c=>c.Id.Equals(companyId),trackChanges)
    .SingleOrDefaultAsync();

    public void CreateCompany(Company company)
    =>Create(company);

    public async Task<IEnumerable<Company>> GetById(IEnumerable<Guid> ids, bool trackChanges)
    => await FindByCondition(c => ids.Contains(c.Id), trackChanges)
        .ToListAsync();
    
    public void Delete(Company company)
    =>Delete(company);
}