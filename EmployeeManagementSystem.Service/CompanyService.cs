using AutoMapper;
using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Service.Contracts;
using EmployeeManagementSystem.Shared.DTOs;

namespace EmployeeManagementSystem.Service;
internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager,IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public CompanyDto CreateCompany(CompanyForCreationDto company)
    {
        var companyEntity = _mapper.Map<Company>(company);
        _repositoryManager.Company.CreateCompany(companyEntity);
        _repositoryManager.Save();
        return _mapper.Map<CompanyDto>(company);
    }

    public IEnumerable<CompanyDto> GetAllCompaniesAsync(bool trackChanges)
    {
        
            var companies = _repositoryManager.Company.GetAllCompaniesAsync(trackChanges);
            var companyDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companyDto;      
    }

    public IEnumerable<CompanyDto> GetById(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadReqiuestException();
    }

    public CompanyDto GetCompany(Guid companyId, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId,trackChanges);
        if(company is null)
            throw new CompanyNotFoundException(companyId);
        var compantDto = _mapper.Map<CompanyDto>(company);
        return compantDto;
     
     
    }
}