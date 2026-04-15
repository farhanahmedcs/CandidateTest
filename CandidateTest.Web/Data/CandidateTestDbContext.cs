using CandidateTest.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateTest.Web.Data;

public sealed class CandidateTestDbContext(DbContextOptions<CandidateTestDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var user = modelBuilder.Entity<User>();

        user.ToTable("Users");
        user.HasKey(x => x.Id);

        user.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        user.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        user.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(100);

        user.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(150);

        user.Property(x => x.DateOfBirth)
            .HasColumnType("date");

        user.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("datetimeoffset");

        user.HasIndex(x => x.Email)
            .IsUnique();
    }
}
