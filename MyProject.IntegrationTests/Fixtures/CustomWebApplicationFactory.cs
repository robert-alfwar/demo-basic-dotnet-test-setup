using Microsoft.AspNetCore.Mvc.Testing;

namespace MyProject.IntegrationTests.Fixtures
{
    public class CustomWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> 
        where TEntryPoint : class
    {
        protected override void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
        {
            // Configure your application for testing here if needed
            // For example: mock services, test database, etc.
            
            builder.ConfigureServices(services =>
            {
                // Add or replace services here as needed
            });
        }
    }
}