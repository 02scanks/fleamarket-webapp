public interface IUserService
{
    Task UpdateProfilePictureAsync(User user, string newPictureURL);
    Task UpdateUserAddressAsync(User user, string newAddress);
}