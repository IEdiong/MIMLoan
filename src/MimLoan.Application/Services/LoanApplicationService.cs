using MimLoan.Application.DTOs;
using MimLoan.Application.Interfaces;
using MimLoan.Domain.Abstractions;
using MimLoan.Domain.Entities;
using MimLoan.Domain.Enums;

namespace MimLoan.Application.Services;

public class LoanApplicationService : ILoanApplicationService
{
    private readonly ILoanApplicationRepository _loanApplicationRepository;

    public LoanApplicationService(ILoanApplicationRepository loanApplicationRepository)
    {
        _loanApplicationRepository = loanApplicationRepository;
    }

    public async Task<LoanApplication> CreateApplicationAsync(LoanApplicationDto dto)
    {
        var application = new LoanApplication
        {
            CustomerName = dto.Name,
            Address = dto.Address,
            DateOfBirth = dto.DateOfBirth,
            Email = dto.Email,
            IsHomeOwner = dto.IsHomeOwner,
            LoanAmount = dto.Amount,
            Status = ApplicationStatus.Pending,
            SubmittedAt = DateTime.UtcNow
        };

        await _loanApplicationRepository.CreateAsync(application);
        return application;
    }
}