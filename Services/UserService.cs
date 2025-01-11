
public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task UpdateProfilePictureAsync(User user, string newPictureURL)
    {
        // change profile url and save
        user.ProfilePictureURL = newPictureURL;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserAddressAsync(User user, string newAddress)
    {
        user.Address = newAddress;
        await _context.SaveChangesAsync();
    }
}