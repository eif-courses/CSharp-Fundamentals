// See https://aka.ms/new-console-template for more information
using IoCMicrosoftContainerDI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

// 3 different way use Injection
// Contstructor Injection
// Method Injection
// Propery Injection



// Advantages

// Flexible
// SWAP IMPLEMENTATIONS
// NEW KEYWORD ONCE 
// AUTOMATIC INJECTION FROM FRAMEWORKS
// IoC -> Containers for services available

// Disadvantages

// Need follow rules more code.
// Some times you face perfomance issue problems.
// More Interfaces too much perfomance hit
// Extra errors at runtime.



var builder = new ConfigurationBuilder();
BuildConfig(builder);

Log.Logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Build())
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

Log.Logger.Information("Application Starting");

// Override default Builder for Dependency injection
// And logger Serilog
var host = Host.CreateDefaultBuilder()
  .ConfigureServices((context, services) =>
  {
    services.AddTransient<ISpecializationService, SpecializationService>();
    services.AddTransient<IReferencesService, BookReferencesService>();
  })
  .UseSerilog()
  .Build();

var dbService = host.Services.GetRequiredService<ISpecializationService>();

Console.WriteLine(dbService.GetDescription());


static void BuildConfig(IConfigurationBuilder builder)
{
  builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
    .AddEnvironmentVariables();
}
