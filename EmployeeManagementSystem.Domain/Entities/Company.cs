using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Domain.Entities;

public sealed class Company
{
    [Column("CompanyId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "Company name is required fields")]
    [MaxLength(60, ErrorMessage = "Maximum length for the name is 60 characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Company address is required fields")]
    [MaxLength(60, ErrorMessage = "Maximum length for the address is 60 characters")]
    public string? Address { get; set; }

    public string? Country { get; set; }

    public ICollection<Employee>? Employees { get; set; } 
}