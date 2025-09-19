using MimLoan.Application.DTOs;
using MimLoan.Application.Interfaces;

namespace MimLoan.Application.Services;

public class LoanCalculatorService : ILoanCalculatorService
{
    private const int LOAN_TERM_MONTHS = 18;
    private const decimal MONTHLY_INTEREST_RATE = 0.15m; // 15% monthly
    
    public LoanCalulationResultDto CalculateLoan(decimal loanAmount)
    {
        decimal totalInterest = loanAmount * MONTHLY_INTEREST_RATE * LOAN_TERM_MONTHS;
        decimal totalPayable = loanAmount + totalInterest;
        decimal monthlyRepayment = totalPayable / LOAN_TERM_MONTHS;

        return new LoanCalulationResultDto(
            loanAmount,
            LOAN_TERM_MONTHS,
            MONTHLY_INTEREST_RATE,
            monthlyRepayment,
            totalPayable,
            totalInterest);
    }
}