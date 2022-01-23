using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SOLID_DRY_KISS
{

  public class Player
  {
    public string Name { get; set; }
    public decimal Experience { get; set; }
  }
  public class Database
  {
    public void SaveToDatabase(Player player)
    {
      Console.WriteLine($" { player.Name } progress successfully saved to database!");
    }
  }
  public class Logger
  {
    public void Log(string message)
    {
      Console.WriteLine($"LOG: Activity registered: { message }");
    }
  }
  public class Quest
  {
    public string Name { get; set; }
    public decimal Reward { get; private set; }
    public Player Owner { get; set; }
    public DateOnly ObtainedDate { get; private set; }

    public bool IsComplete { get; private set; }

    public void StartQuest(DateOnly date)
    {
      ObtainedDate = date;
      Logger log = new Logger();
      log.Log($"Quest: { Name } added to your list!");
    }
    public void CompleteQuest(DateOnly dateOnly)
    {
      IsComplete = true;
      ObtainedDate = dateOnly;
      Reward += 1000;
      Logger log = new Logger();
      log.Log($"Quest { Name } completed! at {dateOnly}.");

      Database database = new Database();
      database.SaveToDatabase(Owner);
    }
  }
}
