using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DRY_KISS
{
  // CORE CLASSES FOR BOTH SOLUTIONS
  public class RequestFriendClient
  {
    public void Send(string battleTag)
    {
      // DUMMY METHOD
      // IN REAL WORLD CALLING API REQUEST OR QUERY FROM DB 
      Console.WriteLine($"Friend request {battleTag} was successfully sended!");
    }
  }

  // END OF CORE CLASSES 

}
