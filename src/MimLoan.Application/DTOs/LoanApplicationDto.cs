namespace MimLoan.Application.DTOs;

public record LoanApplicationDto(
    string Name,
    string Address,
    DateTime DateOfBirth,
    string Email,
    bool IsHomeOwner,
    decimal Amount);