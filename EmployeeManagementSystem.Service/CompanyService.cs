using AutoMapper;
using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Exceptions;
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

    public async Task<CompanyDto>CreateCompanyAsync(CompanyForCreationDto company)
    {
        var companyEntity = _mapper.Map<Company>(company);
         _repositoryManager.Company.CreateCompany(companyEntity);
        await _repositoryManager.SaveAsync();
        return _mapper.Map<CompanyDto>(company);
    }

    public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges)
    {
        
            var companies = await _repositoryManager.Company.GetAllCompaniesAsync(trackChanges);
            var companyDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companyDto;      
    }

    public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadReqiuestException();
        var companies =  await _repositoryManager.Company.GetById(ids, trackChanges);
        if (ids.Count() != companies.Count())
            throw new IdParametersBadReqiuestException();
        var companyDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        return companyDto;
    }

    public async Task <(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(
        IEnumerable<CompanyForCreationDto> companyCollection)
    {
        if (companyCollection is null)
            throw new CompanyCollectionBadRequest();
        var companiesEntity = _mapper.Map<IEnumerable<Company>>(companyCollection);
        foreach (var company in companiesEntity)
        {
            _repositoryManager.Company.CreateCompany(company);
        }

        await _repositoryManager.SaveAsync();
        var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companiesEntity);
        var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));
        return (companies: companyCollectionToReturn, ids: ids);
    }

    public async Task DeleteCompanyAsync(Guid companyId, bool trackChanges)
    {
        var company = await _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);
        _repositoryManager.Company.Delete(company);
        await _repositoryManager.SaveAsync();
    }

    public async Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdateDto, bool trackChanges)
    {
        var company = await _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);
        _mapper.Map(companyForUpdateDto, company);
       await _repositoryManager.SaveAsync();
    }


    public async Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges)
    {
        var company =await _repositoryManager.Company.GetCompany(companyId,trackChanges);
        if(company is null)
            throw new CompanyNotFoundException(companyId);
        var companyDto = _mapper.Map<CompanyDto>(company);
        return companyDto;
     
     
    }
}