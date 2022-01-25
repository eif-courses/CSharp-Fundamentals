namespace SOLID_DRY_KISS { 
/*
===========Intro to SOLID principles===========
SOLID principles are the design principles that enable us to manage most of the software design problems. Robert C. Martin compiled these principles in the 1990s. These principles provide us with ways to move from tightly coupled code and little encapsulation to the desired results of loosely coupled and encapsulated real needs of a business properly. SOLID is an acronym of the following.

S: Single Responsibility Principle (SRP)
O: Open closed Principle (OCP)
L: Liskov substitution Principle (LSP)
I: Interface Segregation Principle (ISP)
D: Dependency Inversion Principle (DIP)

*/

/*
 =========DRY==========:
 * In software engineering:
 * Don 't Repeat Yourself (DRY) 
 * Duplication is Evil (DIE) is a principle of software development.

 =========KISS=========:
 * KISS is an acronym for the design principle "Keep it simple, Stupid!".

 */


// See https://aka.ms/new-console-template for more information

public class Program {
    static void Main()
    {
        
      // Single Responsibility Principle (SRP)
     
      RequestFriendClient requestFriendClient = new RequestFriendClient(); 
      BlizzardAppServiceSRP blizzard = new BlizzardAppServiceSRP(new BlizzardAppServiceSRP.FriendRequestService(requestFriendClient));
      blizzard.AddFriend("Marius#2222");

      // Open closed Principle (OCP)

      OpenClosePrinciple.Pencil pencil = new OpenClosePrinciple.Pencil();
      OpenClosePrinciple.Eraser eraser = new OpenClosePrinciple.Eraser();
      OpenClosePrinciple.Tool [] toolArray = {pencil, eraser};
      OpenClosePrinciple.ToolSimulator.Run(toolArray);

      // Interface Segregation Principle (ISP) 

      var admin = new ISP.Admin();
      var user = new ISP.User();
      
      admin.Write();
      admin.Read();
      
      user.Read();
      // user can't write

      // WITHOUT Dependency Inversion Principle (DIP)
      // DEPENDS ON LOW LEVEL MODULES

      Player player = new Player() { Name = "FireMan", Experience = 0 };
      Quest quest = new Quest()
      {
        Name = "The Games We Play",
        Owner = player
      };
      var currentDate = DateOnly.FromDateTime(DateTime.Now);
      quest.StartQuest(currentDate);
      quest.CompleteQuest(currentDate);

      // Dependency Inversion Principle (DIP)
      // IT depending on Abstractions and easier for testing, updating and so on
      // For example you switching logger System or Database
      // so you have better time to make small changes instead whole solution

      DIP.IPlayer dipPlayer = FactoryDIP.CreatePlayer();
      dipPlayer.Name = "DIP FireMan";
      dipPlayer.Experience = 0;

      DIP.IQuest dipQuest = FactoryDIP.CreateQuest();
      dipQuest.Name = "DIP The Games We Play";
      dipQuest.Owner = dipPlayer;

      dipQuest.StartQuest(currentDate);
      dipQuest.CompleteQuest(currentDate);

      // WITHOUT The Liskov Substitution Principle (LSP)
      // UNCOMMENT LINES AND SEE WHATS WRONG
      Manager manager = new Manager();
      manager.Name = "Tom";
      manager.CalculateSalary(4);

      Employee employee = new CEO();
      employee.Name = "John";
      //employee.AssignManager(manager); // !!!!!!BREAKS LSP principle runtime errord!!!!!!
      employee.CalculateSalary(2);
      Console.WriteLine($"{ employee.Name } salary is { employee.Salary }/per hour.");
     
      
      // END OF BLOCK
      // IMPORTANT WORDS
      // COVARIANCE CHANGING RETURN TYPE
      // CONTRAVARIANCE CHANGE PARAMETER INPUT TYPE
      
      // PRECONDITIONS YOU CAN'T UPDATE METHOD "WITH IF STATEMENT" BECAUSE IT NOT WORK
      // IN OTHER PLACES WHICH IS INHERETS EMPLOYEE
      
      // POSTCONDITIONS


      // A lot of flexible way without breaking app
      Liskov.IManager liskovManager = new Liskov.CEO();

    

      liskovManager.Name = "Liskov";
      liskovManager.CalculateSalary(4);


      //Liskov.BaseEmployee ceo = new Liskov.CEO();
      Liskov.IManaged managed = new Liskov.Employee();
      managed.Name = "Managed employee";
      managed.CalculateSalary(2);
      managed.AssignManager(liskovManager);

      Console.WriteLine($"{ managed.Name } salary is { managed.Salary }/per hour.");

    }
  }
}