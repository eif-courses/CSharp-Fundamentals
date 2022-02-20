using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
  internal class Suscriber
  {

    public int Experience { get; private set; }
    private int _CurrentLevel = 1;

    private readonly string _id;

    public Suscriber(string id, int exp, Publisher publisher)
    {
      Experience = exp;
      _id = id;
      publisher.RaiseCustomEvent += HandleCustomEvent; // Invoke Publisher updates
    }
    void HandleCustomEvent(object sender, CustomEventArgs e) // CustomEventArgs Updated values
    {
      
      Experience += 100;
      
      if (Experience == 1000)
        {
          _CurrentLevel += 1;

          Console.WriteLine("===============================================================");
          Console.WriteLine($"{e.Message}"); // Any logic to react for publisher 
          Console.WriteLine($"{_id} Current Level: {_CurrentLevel}");
          Console.WriteLine("===============================================================");
        
      }

      Console.WriteLine($"{_id} Current xp: {Experience}");


    }

  }
}
