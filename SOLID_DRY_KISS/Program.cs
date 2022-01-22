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
      // EASY WAY :)
      BlizzardAppService blizzardAppService = new BlizzardAppService();
      blizzardAppService.AddFriend("marius#444");


      // Single Responsibility Principle (SRP)
      RequestFriendClient requestFriendClient = new RequestFriendClient(); 
      BlizzardAppServiceSRP blizzard = new BlizzardAppServiceSRP(new BlizzardAppServiceSRP.FriendRequestService(requestFriendClient));
      blizzard.AddFriend("Marius#2222");

    }
  }
}