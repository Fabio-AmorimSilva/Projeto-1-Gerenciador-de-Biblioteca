namespace LibraryManagement.Domain.Specifications;

public sealed class UserAlreadyExistsSpec : Specification<User>
{
    public UserAlreadyExistsSpec(string name, string email)
    {
        Query.Where(q =>
            q.Email == email &&
            q.Name == name
        );
    }
}