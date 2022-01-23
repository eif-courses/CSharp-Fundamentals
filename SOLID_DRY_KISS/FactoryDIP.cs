using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DRY_KISS
{
  public static class FactoryDIP
  {
    public static DIP.IQuest CreateQuest() { return new DIP.Quest(CreateLogger(), CreateDatabase()); }
    public static DIP.IPlayer CreatePlayer() { return new DIP.Player(); }
    public static DIP.ILogger CreateLogger() { return new DIP.Logger(); }
    public static DIP.IDatabase CreateDatabase() { return new DIP.RealtimeDatabase(); }
  }
}
