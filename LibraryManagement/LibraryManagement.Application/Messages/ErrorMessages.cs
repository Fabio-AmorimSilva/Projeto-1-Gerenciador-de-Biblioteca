namespace LibraryManagement.Application.Messages;

public static class ErrorMessages
{
    public static string CannotBeEmpty(string field)
        => $"{field} cannot be empty.";
    
    public static string HasMaxLength(string field, int length)
        => $"{field} has max length of {length}.";
    
    public static string NotFound<T>()
        => $"{typeof(T).Name} not found.";
    
    public static string AlreadyExists<T>()
        => $"{typeof(T).Name}  already exists.";
}