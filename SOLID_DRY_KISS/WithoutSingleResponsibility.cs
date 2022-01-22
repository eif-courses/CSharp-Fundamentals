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

  public class WithoutSingleResponsibility
  {

  }
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
  // S: Single Responsibility Principle (SRP)
  // Same app different approach
  public class BlizzardAppServiceSRP
  {
    FriendRequestService _friendRequestService;
    // You can add any Database context class or other props 
    public BlizzardAppServiceSRP(FriendRequestService friendRequestService)
    {
      _friendRequestService = friendRequestService;
    }
    public void AddFriend(string battleTag)
    {
      if (!_friendRequestService.ValidateBattleTag(battleTag))
      {
        throw new Exception("Wrong email or battleTag");
      }
      else
      {
        _friendRequestService.SendFriendRequest(battleTag);
      }
    }
    public class FriendRequestService
    {
      RequestFriendClient _requestFriendClient;

      public FriendRequestService(RequestFriendClient requestFriendClient)
      {
        _requestFriendClient = requestFriendClient;
      }

      public virtual bool ValidateBattleTag(string battleTag)
      {
        // Validation is for demo only you can implement regex or other validate algorithm
        return battleTag.Contains("#");
      }
      public void SendFriendRequest(string battleTag)
      {
        // Also you can call other class, server api call and so on
        _requestFriendClient.Send(battleTag);
      }
    }
  }
}