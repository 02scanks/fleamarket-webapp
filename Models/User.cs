using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string ProfilePictureURL { get; set; }
    public string FirebaseToken { get; set; }
    public string PhoneNumber { get; set; }
}