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
    public IActionResult GetAllCompanies()
    {
        try
        {
            var companies = _service.CompanyService.GetAllCompaniesAsync(false);
            return Ok(companies);

        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Server Error");
        }
        
    }
    [HttpGet("{id:guid}", Name = "CompanyById")]
    public IActionResult GetCompany(Guid id)
    {
        var company = _service.CompanyService.GetCompany(id,trackChanges: false);
        return Ok(company);
    }

    [HttpPost]
    public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
    {
        if (company is null)
            return BadRequest("CompanyForCreationDto object is null");
        var createdCompany = _service.CompanyService.CreateCompany(company);
        return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);

    }
}