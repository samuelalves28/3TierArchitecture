using Business.Interfaces;
using Data.Implementations.Interfaces;
using Data.Models;

namespace Business.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await userRepository.GetUserByIdAsync(id, cancellationToken);
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await userRepository.GetAllAsync(cancellationToken);
    }

    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken)
    {
        return await userRepository.CreateAsync(user, cancellationToken);
    }

    public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        return await userRepository.UpdateAsync(user, cancellationToken);
    }

    public async Task<User> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        return await userRepository.DeleteAsync(id, cancellationToken);
    }
}
