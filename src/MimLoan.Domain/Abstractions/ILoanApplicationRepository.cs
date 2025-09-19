using MimLoan.Domain.Entities;

namespace MimLoan.Domain.Abstractions;

public interface ILoanApplicationRepository
{
    Task<LoanApplication> CreateAsync(LoanApplication loanApplication);
}

// TODO: Add concellation token