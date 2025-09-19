using Microsoft.EntityFrameworkCore;
using MimLoan.Domain.Abstractions;
using MimLoan.Domain.Entities;
using MimLoan.Domain.Enums;
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

    public async Task<LoanApplication?> GetByIdAsync(int applicationId)
    {
        return await _context.LoanApplications.FirstOrDefaultAsync(a => a.Id == applicationId);
    }

    public async Task<IEnumerable<LoanApplication>> GetAllAsync()
    {
        return await _context.LoanApplications
            .OrderByDescending(a => a.SubmittedAt)
            .ToListAsync();
    }

    public async Task UpdateStatusAsync(int applicationId, ApplicationStatus status)
    {
        var application = await _context.LoanApplications
            .FirstOrDefaultAsync(a => a.Id == applicationId);
            
        if (application != null)
        {
            application.Status = status;
            application.ProcessedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}