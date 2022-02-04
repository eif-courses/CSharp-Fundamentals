// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public interface IGreetingService
{
  void Run();
}

public class GreetingService : IGreetingService
{
  private readonly ILogger<GreetingService> _log;
  private readonly IConfiguration _config;

  public GreetingService(ILogger<GreetingService> log, IConfiguration config)
  {
    _config = config;
    _log = log;
  }
  public void Run()
  {

    // flexible way for logger
    for (int i = 0; i < _config.GetValue<int>("LoopTimes"); i++)
    {
      _log.LogInformation("Run number {runNumber}", i);
    }
  }
}
