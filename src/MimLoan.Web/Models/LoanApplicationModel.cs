using System.ComponentModel.DataAnnotations;
using MimLoan.Web.Validations;

namespace MimLoan.Web.Models;
public class LoanApplicationModel
{
    [Required]
    [StringLength(20, MinimumLength = 2)]
    public string Name { get; set; } = null!;
    
    [Required]
    [StringLength(20, MinimumLength = 2)]
    public string Address { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required]
    [DataType(DataType.Date)]
    [MinimumAge(18)]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [Range(20000, 50000)]
    public decimal LoanAmount { get; set; }
    
    public bool IsHomeOwner { get; set; }
}