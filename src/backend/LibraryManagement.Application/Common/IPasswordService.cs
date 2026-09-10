namespace LibraryManagement.Application.Common;

public interface IPasswordService
{
    string HashPassword(string password);
}