using Data.Context;
using Data.Implementations.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataBaseContext _context;
    private readonly DbSet<User> _users;

    public UserRepository(DataBaseContext context)
    {
        _context = context;
        _users = _context.Set<User>();
    }

    public async Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _users.SingleAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _users.ToListAsync(cancellationToken);
    }

    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken)
    {
        await _users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        _users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User?> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _users.SingleAsync(s => s.Id == id, cancellationToken);
        if (user != null)
        {
            _users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return user;
    }
}
