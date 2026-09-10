namespace LibraryManagement.Application.Common;

public interface ITokenService
{
    string GenerateToken(
        IEnumerable<string> roles,
        IEnumerable<string> permissions,
        User user
    );
}