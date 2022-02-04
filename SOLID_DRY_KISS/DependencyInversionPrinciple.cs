using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DRY_KISS
{

  /*
 * The Dependency Inversion Principle (DIP) states that high-level modules/classes should not depend on low-level modules/classes.
 * Both should depend upon abstractions. Secondly, abstractions should not depend upon details. 
 * Details should depend upon abstractions.
 * High - level modules/classes implement business rules or logic in a system (application). 
 * Low - level modules / classes deal with more detailed operations; 
in other words they may deal with writing information to databases or passing messages to the operating system or services.
*/
  // If you follow and use Dependency Inversion you are Ready apply Dependency Injection to your project
  namespace DIP
  {
    public interface IPlayer {
      string Name { get; set; }
      decimal Experience { get; set; }
    }
    public interface ILogger
    {
      void Log(string message);
    }
    public interface IDatabase
    {
      void SaveToDatabase(IPlayer player);
    }
    public interface IQuest
    {
      bool IsComplete { get; }
      string Name { get; set; }
      DateOnly ObtainedDate { get; }
      IPlayer Owner { get; set; }
      decimal Reward { get; }

      void CompleteQuest(DateOnly dateOnly);
      void StartQuest(DateOnly date);
    }

    public class Player : IPlayer
    {
      public string Name { get; set; }
      public decimal Experience { get; set; }
    }

    public class Database : IDatabase
    {
      public void SaveToDatabase(IPlayer player)
      {
        Console.WriteLine($" { player.Name } progress successfully saved to database!");
      }
    }
    // IF YOU ADDING NEW DATABASE Also change in FactoryDIP class return type to newely created database 
    // POWER OF NO DIRECT DEPENDENCIES ITS ONLY DEPENDS ON ABSTRACTIONS
    public class RealtimeDatabase : IDatabase
    {
      public void SaveToDatabase(IPlayer player)
      {
        Console.WriteLine($" { player.Name } progress successfully saved to Realtime database!");
      }
    }

    public class MongoDB : IDatabase
    {
      public void SaveToDatabase(IPlayer player)
      {
        Console.WriteLine($" { player.Name } progress successfully saved to MONGO DATABASE database!");
      }
    }




    public class Logger : ILogger
    {
      public void Log(string message)
      {
        Console.WriteLine($"LOG: Activity registered: { message }");
      }
    }

    public class Logger2 : ILogger
    {
      public void Log(string message)
      {
        Console.WriteLine($"LOG: Activity registered: { message }");
      }
    }



    public class Quest : IQuest
    {

      ILogger _logger;
      IDatabase _database;

      public string Name { get; set; } = string.Empty;
      public decimal Reward { get; private set; }
      public IPlayer Owner { get; set; } = null!; // And it will give a warning if user tries to set the Property as null
      public DateOnly ObtainedDate { get; private set; }

      public Quest(ILogger logger, IDatabase database)
      {
        _logger = logger;
        _database = database;
      }

      public bool IsComplete { get; private set; }

      public void StartQuest(DateOnly date)
      {
        ObtainedDate = date;
        _logger.Log($"Quest: { Name } added to your list!");
      }
      public void CompleteQuest(DateOnly dateOnly)
      {
        IsComplete = true;
        ObtainedDate = dateOnly;
        Reward += 1000;
        _logger.Log($"Quest { Name } completed! at {dateOnly}.");
        _database.SaveToDatabase(Owner);
      }
    }

  }

}
