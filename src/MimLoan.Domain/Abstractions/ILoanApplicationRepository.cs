using MimLoan.Domain.Entities;
using MimLoan.Domain.Enums;

namespace MimLoan.Domain.Abstractions;

public interface ILoanApplicationRepository
{
    Task<LoanApplication> CreateAsync(LoanApplication loanApplication);
    Task<LoanApplication?> GetByIdAsync(int applicationId);
    Task<IEnumerable<LoanApplication>> GetAllAsync();

    Task UpdateStatusAsync(int applicationId, ApplicationStatus status);
}

// TODO: Add concellation token