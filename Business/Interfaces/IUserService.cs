using Data.Models;

namespace Business.Interfaces;

public interface IUserService
{
    Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    Task<User> CreateAsync(User user, CancellationToken cancellationToken);
    Task<User> UpdateAsync(User user, CancellationToken cancellationToken);
    Task<User> DeleteAsync(int id, CancellationToken cancellationToken);
}
