namespace LibraryManagement.Infrastructure.Auth.Services;

public class PasswordHashService : IPasswordService
{
    public string HashPassword(string password)
    {
        string combinedHash = password;

        using (var sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(combinedHash);
            
            byte[] hash = sha256.ComputeHash(bytes);
            
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
                builder.Append(hash[i].ToString("x2"));
            
            return Convert.ToBase64String(hash);
        }
    }
}