
using EmployeeManagementSystem.Presentation.ModelBinders;
using EmployeeManagementSystem.Service.Contracts;
using EmployeeManagementSystem.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController: ControllerBase
{
    private readonly IServiceManager _service;

    public CompanyController(IServiceManager companyService)=>_service = companyService;
    
    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        try
        {
            var companies = await _service.CompanyService.GetAllCompaniesAsync(false);
            return Ok(companies);

        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Server Error");
        }
        
    }
    [HttpGet("collection/({ids})",Name ="CompanyCollection")]
    public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType =typeof(ArrayModelBinder))]IEnumerable<Guid>ids)
    {
        var companies = await _service.CompanyService.GetByIdsAsync(ids, trackChanges: false);
        return Ok(companies);


    }
    [HttpGet("{id:guid}", Name = "CompanyById")]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await _service.CompanyService.GetCompanyAsync(id,trackChanges: false);
        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
    {
        if (company is null)
            return BadRequest("CompanyForCreationDto object is null");
        var createdCompany = await _service.CompanyService.CreateCompanyAsync(company);
        return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);

    }
    [HttpPost("collection")]
    public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
    {
        var result =await _service.CompanyService.CreateCompanyCollectionAsync(companyCollection);
        return CreatedAtRoute("CompanyCollection", new { id = result.ids }, result.companies);
        
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        await _service.CompanyService.DeleteCompanyAsync(id, trackChanges: false);
        return NoContent();
    }
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
    { 
        if(company is null)
            return BadRequest("CompanyForUpdateDto object is null");
        await _service.CompanyService.UpdateCompanyAsync(id, company, trackChanges: false);
        return NoContent();
    }
    
}