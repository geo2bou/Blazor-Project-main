using BlazorApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
// using MudBlazor.Services;

try
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    
    builder.Services.AddScoped(sp => new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

    //builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("api"));
    //builder.Services.AddAuthorizationCore();
    builder.Services.AddScoped<CustomerService>();
    // builder.Services.AddMudServices();

    builder.Services.AddOidcAuthentication(options =>
    {
        builder.Configuration.Bind("Local", options.ProviderOptions);
    });

    await builder.Build().RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Blazor startup failed: {ex.Message}");
}