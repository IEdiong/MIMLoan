using MimLoan.Application.DTOs;
using MimLoan.Application.Interfaces;
using MimLoan.Domain.Constants;

namespace MimLoan.Application.Services;

public class LoanCalculatorService : ILoanCalculatorService
{
    public LoanCalulationResultDto CalculateLoan(decimal loanAmount)
    {
        var r = LoanConstants.MonthlyInterestRate;
        var n = LoanConstants.TermInMonths;

        var monthlyRepayment = (double)loanAmount * (Math.Pow(1 + (double)r, n) * (double)r) / (Math.Pow(1 + (double)r, n) - 1);
        var totalPayable = (decimal)monthlyRepayment * n;
        var totalInterest = totalPayable - loanAmount;

        return new LoanCalulationResultDto(
            loanAmount,
            n,
            r,
            (decimal)monthlyRepayment,
            totalPayable,
            totalInterest);
    }
}