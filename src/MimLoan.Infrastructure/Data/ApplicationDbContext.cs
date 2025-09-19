using Microsoft.EntityFrameworkCore;
using MimLoan.Domain.Entities;

namespace MimLoan.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
        
    }
    
    public ApplicationDbContext(){}
    
    public DbSet<LoanApplication> LoanApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<LoanApplication>()
            .Property(e => e.Status)
            .HasConversion<string>();
    }
}