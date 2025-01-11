public interface IFirebaseTokenService
{
    Task<string> GenerateTokenAsync(string userId);
}