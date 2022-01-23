using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DRY_KISS
{
 // The Interface Segregation Principle states "that clients should not be forced to implement interfaces they don't use.
 // Instead of one fat interface, many small interfaces are preferred based on groups of methods, each one serving one submodule.".
 
  namespace ISP
  {
    // Nested interface only helps group roles in signle place 
    // But also works and separated interfaces 
    interface IRoleWrite
    {
      void Write();
    }
    interface IRoleRead
    {
        void Read();
    }
    class Admin : IRoleRead, IRoleWrite
    {
      public void Read()
      {
        Console.WriteLine("Admin reading document");
      }
      public void Write()
      {
        Console.WriteLine("Admin editing / writing to document");
      }
    }
    class User : IRoleRead
    {
      public void Read()
      {
        Console.WriteLine("User reading document");
      }
    }
  }
}
