using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCMicrosoftContainerDI
{
  

  public class SpecializationService : ISpecializationService
  {
    private readonly ILogger<SpecializationService> _log;
    private readonly IConfiguration _config;
    private readonly IReferencesService _referencesService;

    public SpecializationService(ILogger<SpecializationService> log, IConfiguration config, IReferencesService referencesService)
    {
      _log = log;
      _config = config;
      _referencesService = referencesService;
    }

    public string GetDescription()
    {
      // flexible way for logger
      for (int i = 0; i < _config.GetValue<int>("LoopTimes"); i++)
      {
        _log.LogInformation("Run number {runNumber}", i);
        Thread.Sleep(100);
      }
      _referencesService.MostImportantLinks();
      
      return "Choosing database specialization you will learn RMDBS, SQL, NOSQL and ETC.";
    }
  }


}


