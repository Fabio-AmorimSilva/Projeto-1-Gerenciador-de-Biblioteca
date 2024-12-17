namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(options => options.UseInMemoryDatabase("LibraryDb"));
        services.AddScoped<ILibraryDbContext>(provider => provider.GetRequiredService<LibraryDbContext>());
        
        return services;
    }
}