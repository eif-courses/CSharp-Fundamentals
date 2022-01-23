using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * The Liskov Substitution Principle (LSP)
 * states that "you should be able to use any derived class
 * instead of a parent class and have it behave in the same manner without modification". 
 * It ensures that a derived class does not affect the behavior of the parent class, in other words,
 * that a derived class must be substitutable for its base class.
 * This principle is just an extension of the Open Closed Principle 
 * and it means that we must ensure that new derived classes extend the base classes without changing their behavior.
*/


namespace SOLID_DRY_KISS
{

  /*  In simple words, derived classes should be substitutable for their parent classes.
   *  For example, if a Farmer’s son is Farmer then he can work in place of his father
   *  but if a Farmer’s son is a Teacher then he can’t work in place of his father.
  */

  // !!!! CANNOT RETURN THROW NEW EXCEPTIONS IF YOU FOLLOW LSP !!!!
  // UNEXPECTED BEHAVIOR
  namespace Liskov
  {

    public abstract class BaseEmployee : IEmployee
    {
      public string Name { get; set; } = string.Empty;
      public decimal Salary { get; set; }
      public virtual void CalculateSalary(int experience)
      {
        decimal perHourRate = 20.25M;
        Salary = perHourRate + (experience * 2);
      }
    }

    public interface IManager: IEmployee
    {
      public void GeneratePerfomanceReview();
    }
    public interface IManaged : IEmployee
    {
      IEmployee Manager { get; set; }
      void AssignManager(IEmployee manager);
    }
    public interface IEmployee
    {
      string Name { get; set; }
      decimal Salary { get; set; }
      void CalculateSalary(int experience);
    }

    public class Employee : BaseEmployee, IManaged
    {
      public IEmployee Manager { get; set; } = null!;
      public void AssignManager(IEmployee manager)
      {
        Manager = manager;
      }
    }
    public class Manager : Employee, IManager
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
    public class CEO : BaseEmployee, IManager
    {
      public override void CalculateSalary(int experience)
      {
        decimal perHourRate = 120M;
        Salary = perHourRate * experience;
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
}

