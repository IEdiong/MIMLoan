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
        
        modelBuilder.Entity<LoanApplication>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasConversion<string>();
            
            entity.Property(e => e.LoanAmount)
                .HasPrecision(10, 2);
            
            entity.Property(e => e.SubmittedAt)
                .ValueGeneratedOnAdd();
        });
    }
}