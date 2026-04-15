using CandidateTest.Web.Dtos;
using CandidateTest.Web.Models;

namespace CandidateTest.Web.Services;

public interface IUserService
{
    Task<int> GetDashboardSattsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ServiceResult> CreateAsync(User user, CancellationToken cancellationToken = default);
    Task<ServiceResult> UpdateAsync(User user, CancellationToken cancellationToken = default);
    Task<ServiceResult> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
