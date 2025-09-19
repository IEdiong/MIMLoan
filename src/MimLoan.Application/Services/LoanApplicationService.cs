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

    public Task<LoanApplication?> GetApplicationByIdAsync(int applicationId)
    {
        return _loanApplicationRepository.GetByIdAsync(applicationId);
    }

    public async Task<IEnumerable<LoanApplication>> GetAllApplicationsAsync()
    {
        return await _loanApplicationRepository.GetAllAsync();
    }

    public async Task UpdateApplicationStatusAsync(int applicationId, ApplicationStatus newStatus)
    {
        await _loanApplicationRepository.UpdateStatusAsync(applicationId, newStatus);
    }
}