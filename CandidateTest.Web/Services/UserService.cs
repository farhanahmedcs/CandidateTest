using CandidateTest.Web.Data;
using CandidateTest.Web.Dtos;
using CandidateTest.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateTest.Web.Services;

public sealed class UserService(IDbContextFactory<CandidateTestDbContext> dbContextFactory) : IUserService
{
    public async Task<int> GetDashboardSattsAsync(CancellationToken cancellationToken = default)
    {
        await using var _dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await _dbContext.Users.AsNoTracking().CountAsync();
    }
    public async Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await using var _dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await _dbContext.Users
            .AsNoTracking()
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .ToListAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await using var _dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<ServiceResult> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var _dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);

            var emailExists = await _dbContext.Users
                .AnyAsync(x => x.Email == user.Email, cancellationToken);

            if (emailExists)
            {
                return ServiceResult.Failure("A user with the same email already exists.");
            }

            user.CreatedAt = DateTimeOffset.UtcNow;

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessResult();
        }
        catch
        {
            return ServiceResult.Failure("Internal server error, please contact support.");
        }
    }

    public async Task<ServiceResult> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        try
        {
            await using var _dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
            var existingUser = await _dbContext.Users.FindAsync(user.Id);

            if (existingUser is null)
            {
                return ServiceResult.Failure("User not found.");
            }

            var duplicateEmailExists = await _dbContext.Users
                .AnyAsync(x => x.Id != user.Id && x.Email == user.Email, cancellationToken);

            if (duplicateEmailExists)
            {
                return ServiceResult.Failure("A user with the same email already exists.");
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.DateOfBirth = user.DateOfBirth;

            await _dbContext.SaveChangesAsync();

            return ServiceResult.SuccessResult();
        }
        catch
        {
            return ServiceResult.Failure("Internal server error, please contact support.");
        }
    }

    // To delete user record
    public async Task<ServiceResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var _dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);

            var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (existingUser is null)
            {
                return ServiceResult.Failure("User not found.");
            }

            _dbContext.Users.Remove(existingUser);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessResult();
        }
        catch
        {
            return ServiceResult.Failure("Internal server error, please contact support.");
        }
    }
}
