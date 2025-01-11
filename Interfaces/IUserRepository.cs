public interface IUserRepository 
{
    Task AddAsync(User user);
    void Remove(User user);
    Task<User> GetUserByUsernameAsync(string username);
    Task<bool> CheckIfAccountExistsAsync(string username);
    string HashPassword(User user, string UnhashedPassword);
    bool VerifyPassword(User user, string UnhashedPassword);
    Task UpdateUserAsync(User user);

}