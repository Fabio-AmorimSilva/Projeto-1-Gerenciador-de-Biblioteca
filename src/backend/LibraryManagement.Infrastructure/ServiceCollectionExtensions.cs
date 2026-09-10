namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        services.AddDbContext(configuration);
        
        return services;
    }

    private static IServiceCollection AddDbContext(
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<ILibraryDbContext>(provider => provider.GetRequiredService<LibraryDbContext>());
        
        return services;
    }

    private static IServiceCollection AddIdentity(
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        var settings = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(settings);

        var appSettings = settings.Get<JwtSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings?.JwtKey!);
        
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = appSettings?.ValidOn,
                ValidIssuer = appSettings?.Emissary
            };
        });
        
        return services;
    }
}