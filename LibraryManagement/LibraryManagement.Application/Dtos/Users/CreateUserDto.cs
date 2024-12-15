namespace LibraryManagement.Application.Dtos.Users;

public sealed record CreateUserDto(
    string Name,
    string Email
);