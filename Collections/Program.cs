// See https://aka.ms/new-console-template for more information

// DIFFERENCE BETWEEN IEnumerable and IEnumerator
// IEnumerable not remeber STATE
// IEnumerator rember STATE (cursor pos)
namespace Collections
{
  class PlayerAvatar
  {
    public PlayerAvatar(string name, string url)
    {
      Name = name;
      Url = url;
    }
    public string Name { get; }
    public string Url { get; }
 
    public static void ChooseYourAvatar(IEnumerable<PlayerAvatar> avatars)
    {
      Console.WriteLine("---------------------ChooseYourAvatar---------------------------------");
      Console.WriteLine("Pick your Avatar from list first 2 is Unlocked/free other you need to Purchase!");
      Console.WriteLine("---------------------------------------------------------------------");
      int index = 1;
      foreach (PlayerAvatar avatar in avatars)
      {
        Console.Write($"{index}. {avatar.Name} ");
        index++;
      }
      Console.WriteLine("\n---------------------------------------------------------------------");
      
      Console.WriteLine("Enter your avatar index: ");

      var option = int.Parse(Console.ReadLine());
     
      if(option <= 2)
      {
        var result = avatars.ElementAt(option - 1).Name;
        Console.Write($"You have chosen avatar: {result} ");
      }
      else
      {
        Console.Write($"Are you sure to unlock Avatar by given range for e.g. 4 by default is 4-last y/n: ");
        var answer = Console.Read();
        if (answer.Equals('y')) 
        {
          UnlockAvatars(avatars.GetEnumerator(), option);
        }
        else
        {
          Console.WriteLine("Ty Goodbye see ya next time!");
        }
      }


    }
    public static void UnlockAvatars(IEnumerator<PlayerAvatar> avatars, int option)
    {
      int index = 0;
      while (avatars.MoveNext())
      {
        if((option - 2) == index)
        {
          AvatarsAddedToCollection(avatars);
        }
        index++;
      }
    }
    public static void AvatarsAddedToCollection(IEnumerator<PlayerAvatar> avatars)
    {
      Console.WriteLine("Thank you for purchasing extra Avatars!");
      Console.WriteLine("-------------------------------------------------------------");
      while (avatars.MoveNext())
      {
        Console.WriteLine($"Sucessfully added: {avatars.Current.Name}, paid version avatar!");
      }
      Console.WriteLine("-------------------------------------------------------------");
    }
    

  }

  class Program
  {
    static public void Main()
    {
      List<PlayerAvatar> avatars = new List<PlayerAvatar>();

      avatars.Add(new PlayerAvatar("Bullet (unlocked)", "https://someimage.com"));
      avatars.Add(new PlayerAvatar("Bee (unlocked)", "https://beeimage.com"));
      avatars.Add(new PlayerAvatar("Warrior", "https://warriorimage.com"));
      avatars.Add(new PlayerAvatar("Human", "https://humanimage.com"));
      avatars.Add(new PlayerAvatar("Elephant", "https://elephant.com"));
      avatars.Add(new PlayerAvatar("Lion", "https://lion.com"));

      PlayerAvatar.ChooseYourAvatar(avatars);

    }
 



  }
 
}