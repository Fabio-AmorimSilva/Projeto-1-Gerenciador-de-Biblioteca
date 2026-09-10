namespace LibraryManagement.Infrastructure.Auth.Models;

public sealed class JwtSettings
{
    public string? JwtKey { get; init; } = string.Empty;
    public int ExpireMinutes { get; init; }
    public string Emissary { get; init; } = string.Empty;
    public string ValidOn { get; init; } = string.Empty;
}