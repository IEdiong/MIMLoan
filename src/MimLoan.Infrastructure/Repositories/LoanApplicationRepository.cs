using Microsoft.EntityFrameworkCore;
using MimLoan.Domain.Abstractions;
using MimLoan.Domain.Entities;
using MimLoan.Infrastructure.Data;

namespace MimLoan.Infrastructure.Repositories;

public class LoanApplicationRepository : ILoanApplicationRepository
{
    private readonly ApplicationDbContext _context;

    public LoanApplicationRepository(IDbContextFactory<ApplicationDbContext> factory)
    {
        _context = factory.CreateDbContext();
    }

    public async Task<LoanApplication> CreateAsync(LoanApplication loanApplication)
    {
        loanApplication.SubmittedAt = DateTime.Now;
        var application = await _context.LoanApplications.AddAsync(loanApplication);
        await _context.SaveChangesAsync();
        
        return application.Entity;
    }
}