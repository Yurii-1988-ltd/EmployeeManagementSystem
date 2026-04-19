using AutoMapper;
using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Exceptions;
using EmployeeManagementSystem.Service.Contracts;
using EmployeeManagementSystem.Shared.DTOs;

namespace EmployeeManagementSystem.Service;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    
    public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager,IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(Guid companyId, bool trackChanges)
    {
        var company =  await _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);
        var employeeFromDb = _repositoryManager.Employee.GetAllEmployeesAsync(companyId, trackChanges);
        return _mapper.Map<IEnumerable<EmployeeDto>>(employeeFromDb);

    }

    public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
    {
        var company = await _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);
        var employeeFromDb =  _repositoryManager.Employee.GetEmployeeAsync(companyId, id, trackChanges);
        if (employeeFromDb is null)
            throw new EmployeeNotFoundException(id);
        return _mapper.Map<EmployeeDto>(employeeFromDb);
    }

    public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto companyForCreationDto)
    {
        var companyEntity = _mapper.Map<Company>(companyForCreationDto);
        _repositoryManager.Company.CreateCompany(companyEntity);
        await _repositoryManager.SaveAsync();
        return _mapper.Map<CompanyDto>(companyEntity);
    }

    public async Task <EmployeeDto>CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto creationEmployeeDto, bool trackChanges)
    {
        var company = await _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if(company is null)
            throw new CompanyNotFoundException(companyId);
        var employeeEntity = _mapper.Map<Employee>(creationEmployeeDto);
        _repositoryManager.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
        await _repositoryManager.SaveAsync();
        return _mapper.Map<EmployeeDto>(employeeEntity);
    }

    public async Task DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges)
    {
       var company = await _repositoryManager.Company.GetCompany(companyId, trackChanges);
       if (company is null)
            throw new CompanyNotFoundException(companyId);
       var employeeFromDb = _repositoryManager.Employee.GetEmployeeAsync(companyId, id, trackChanges);
       if (employeeFromDb is null)
            throw new EmployeeNotFoundException(id);
       _repositoryManager.Employee.Delete(employeeFromDb);
     await  _repositoryManager.SaveAsync();
    }

    public async Task UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdateDto,
        bool companyTrackChanges, bool employeeTrackChanges)
    {
        var company  = _repositoryManager.Company.GetCompany(companyId, companyTrackChanges);
        if (company is null)
            throw new CompanyNotFoundException(companyId);
        var employeeFromDb =  _repositoryManager.Employee.GetEmployeeAsync(companyId, id, employeeTrackChanges);
        if (employeeFromDb is null)
            throw new EmployeeNotFoundException(id);
        _mapper.Map(employeeForUpdateDto, employeeFromDb);
       await _repositoryManager.SaveAsync();
        
        
        
        
    }
}