using MimLoan.Domain.Enums;

namespace MimLoan.Domain.Entities;

public class LoanApplication
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public decimal LoanAmount { get; set; }
    public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
    public DateTime SubmittedAt { get; set; }
    public DateTime? ProcessedAt { get; set; }
}