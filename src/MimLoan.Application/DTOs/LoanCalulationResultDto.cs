namespace MimLoan.Application.DTOs;

public record LoanCalulationResultDto(
    decimal LoanAmount,
    int TermMonths,
    decimal MonthlyInterestRate,
    decimal MonthlyRepayment,
    decimal TotalPayable,
    decimal TotalInterest);