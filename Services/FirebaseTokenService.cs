
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

public class FirebaseTokenService : IFirebaseTokenService
{

    private static FirebaseApp _firebaseApp;

    public FirebaseTokenService()
    {
        if(_firebaseApp == null)
        {
            _firebaseApp = FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("Properties/fleamarket-firebase-config.json")
            });
        }
    }


    public async Task<string> GenerateTokenAsync(string userId)
    {
        return await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(userId);
    }
}