using Data.Context;
using Data.Implementations.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataBaseContext _context;

    public UserRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.User.SingleAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.User.ToListAsync(cancellationToken);
    }

    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken)
    {
        await _context.User.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        _context.User.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User?> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _context.User.SingleAsync(s => s.Id == id, cancellationToken);
        if (user != null)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return user;
    }
}
