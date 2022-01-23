using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DRY_KISS
{
  interface IRole
  {
    void Read();
    void Write();
  }
  public class Admin : IRole
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
  public class User : IRole
  {
    public void Read()
    {
      Console.WriteLine("User reading document");
    }
    // Breaks Interface Segregation Principle (ISP) you forced to implement Write() method
    public void Write()
    {
      Console.WriteLine("User Can't edit document!");
    }
  }
}
