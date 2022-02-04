// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;


// SOme details
// https://code-maze.com/dependency-injection-lifetimes-aspnet-core/


Console.WriteLine("Hello, World!");
// https://auth0.com/blog/dependency-injection-in-dotnet-core/
// https://www.blog.jamesmichaelhickey.com/NET-Core-Dependency-Injection/
// https://henriquesd.medium.com/dependency-injection-and-service-lifetimes-in-net-core-ab9189349420
// FRAMEWORKS
// https://autofac.org/

// Youtube 
// https://www.youtube.com/watch?v=tTJetZj3vg0

// DEPENDENCY INJECTION WITH SERILOG and SETTINGS

var builder = new ConfigurationBuilder();
BuildConfig(builder);

Log.Logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Build())
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

Log.Logger.Information("Application Starting");

// Override default Builder for Dependency injection
// And logger Serialog
var host = Host.CreateDefaultBuilder()
  .ConfigureServices((context, services) =>
  {
    services.AddTransient<IGreetingService, GreetingService>();
  })
  .UseSerilog()
  .Build();

var service = ActivatorUtilities.CreateInstance<GreetingService>(host.Services);

service.Run();


static void BuildConfig(IConfigurationBuilder builder)
{
  builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional:true)
    .AddEnvironmentVariables();
}
