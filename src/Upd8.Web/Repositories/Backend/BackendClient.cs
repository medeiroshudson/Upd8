namespace Upd8.Web.Repositories.Backend;

public static class BackendClient
{
    public const string ClientName = "Backend";

    public static IServiceCollection AddBackendClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient(ClientName, (serviceProvider, httpClient) => 
        {
            httpClient.BaseAddress = new Uri(configuration.GetConnectionString(ClientName) ?? throw new ArgumentNullException());
            httpClient.Timeout = TimeSpan.FromSeconds(30);
        });

        return services;
    }
}