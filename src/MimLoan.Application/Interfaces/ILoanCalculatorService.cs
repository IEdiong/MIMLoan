using MimLoan.Application.DTOs;

namespace MimLoan.Application.Interfaces;

public interface ILoanCalculatorService
{
    LoanCalulationResultDto CalculateLoan(decimal loanAmount);
}