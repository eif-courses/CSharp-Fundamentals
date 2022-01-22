using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DRY_KISS
{
  public class BlizzardAppService
  {
    public void AddFriend(string battleTag) {
      if (!ValidateBattleTag(battleTag))
      {
        throw new Exception("Wrong email or battleTag");
      }
      else
      {
        SendFriendRequest(battleTag);
      }

    }
    public virtual bool ValidateBattleTag(string battleTag) {
      // Validation is for demo only you can implement regex or other validate algorithm
      return battleTag.Contains("#");
    }
    public void SendFriendRequest(string battleTag)
    {
      // Also you can call other class, server api call and so on
      Console.WriteLine($"Friend request {battleTag} was successfully sended!");
    }
  }
  
}