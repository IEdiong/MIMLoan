using MimLoan.Application.DTOs;
using MimLoan.Domain.Entities;

namespace MimLoan.Application.Interfaces;

public interface ILoanApplicationService
{
    Task<LoanApplication> CreateApplicationAsync(LoanApplicationDto dto);
}