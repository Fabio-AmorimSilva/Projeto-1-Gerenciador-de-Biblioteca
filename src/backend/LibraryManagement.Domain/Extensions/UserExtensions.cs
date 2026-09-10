namespace LibraryManagement.Domain.Extensions;

public static class UserExtensions
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        return new List<Claim>
        {
            new(ClaimTypes.Sid, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Email, user.Email)
        };
    }
}