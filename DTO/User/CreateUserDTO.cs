public class CreateUserDTO 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string UnhashedPassword { get; set; }
    public string DefaultProfilePictureURL { get; set; }
}