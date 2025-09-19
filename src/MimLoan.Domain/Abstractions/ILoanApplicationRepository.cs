using MimLoan.Domain.Entities;

namespace MimLoan.Domain.Abstractions;

public interface ILoanApplicationRepository
{
    Task<LoanApplication> CreateAsync(LoanApplication loanApplication);
    Task<LoanApplication?> GetAsync(int applicationId);
}

// TODO: Add concellation token