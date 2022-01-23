using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




/*In the given example FighterPlane and PaperPlane classes both extending the Plane class which contain startEngine() method.
 * So it's clear that FighterPlane can start engine but PaperPlane can’t so it’s breaking LSP.
 * PaperPlane class although extending Plane class and should be substitutable in place of it
 * but is not an eligible entity that Plane’s instance could be replaced by, 
 * because a paper plane can’t start the engine as it doesn’t have one. So the good example would be,
*/
// Another example you will find here
// https://www.codeproject.com/Articles/648987/Violating-Liskov-Substitution-Principle-LSP
// ---------------------------------------------------------
//      Violating Liskov Substitution Principle in OOP
// --------------------------------------------------------- 

namespace SOLID_DRY_KISS
{
  public class Employee
  {
    public string Name { get; set; } = string.Empty;
    public Employee Manager { get; set; } = null!;
    public decimal Salary { get; set; }
    public virtual void AssignManager(Employee manager)
    {
      Manager = manager;
    }
    public virtual void CalculateSalary(int experience)
    {
      decimal perHourRate = 20.25M;
      Salary = perHourRate + (experience * 2);
    }
  }
  public class Manager : Employee
  {
    public override void CalculateSalary(int experience)
    {
      decimal perHourRate = 20.25M;
      Salary = perHourRate + (experience * 4);
    }
    public void GeneratePerfomanceReview()
    {
      Console.WriteLine("Reviewing direct perfomance....");
    }
  }
  public class CEO : Employee
  {
    public override void CalculateSalary(int experience)
    {
      decimal perHourRate = 120M;
      Salary = perHourRate * experience;
    }

    public override void AssignManager(Employee manager)
    {
      throw new InvalidOperationException("CEO has no manager");
    }

    public void GeneratePerfomanceReview()
    {
      Console.WriteLine("Reviewing direct perfomance....");
    }

    public void FireEmployee()
    {
      Console.WriteLine("You're Fired!!!");
    }
  }


}
