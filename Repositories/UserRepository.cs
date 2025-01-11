
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{

    private readonly AppDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserRepository(AppDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public Task<bool> CheckIfAccountExistsAsync(string username)
    {
        return _context.Users
            .AnyAsync(u => u.UserName.ToLower() == username.ToLower());
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
    }

    public string HashPassword(User user, string UnhashedPassword)
    {
        return _passwordHasher.HashPassword(user, UnhashedPassword);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public bool VerifyPassword(User user, string UnhashedPassword)
    {
        return _passwordHasher
            .VerifyHashedPassword(user, user.PasswordHash, UnhashedPassword) 
                == PasswordVerificationResult.Success;
    }
}