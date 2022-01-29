using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
  public class DefaultDelegates
  {
    public delegate void MentionDiscount(decimal total);
    public List<Products> Items { get; set; } = new List<Products> { 
      new Products { Name = "Milk", Price = 2.4M },
      new Products { Name = "Sugar", Price = 1.42M },
      new Products { Name = "Carrots", Price = 0.6M },
    };

    // FUNC can't return void
    // Last parameter will be return type first is inputs
    public decimal GenerateTotal(
      MentionDiscount mentionDiscount, 
      Func<List<Products>, decimal, decimal> calculateDiscountedTotal,
      Action<string> sayUserAreLuckyOnDiscounting)
    {
      decimal total = Items.Sum(x => x.Price);
      mentionDiscount(total);
      sayUserAreLuckyOnDiscounting("We are applying your discount!!!");
      return calculateDiscountedTotal(Items, total);
    }
  }
  public class Products
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
  }
  public class DefaultDelegateUsage
  {

    public static void TestSInlineMethodsVersion()
    {
      var magic = new DefaultDelegates();
     
      // You can pass any anonymous functions instead Inlining you can extract elsewhere 
      
      decimal total = magic.GenerateTotal(
        (subTotal) => Console.WriteLine($"The subtotal of Cart 2 is {subTotal:C2}"),
        (products, subTotal) =>
        {
          if (products.Count > 1)
          {
            return subTotal * 0.5M;
          }
          else
          {
            return subTotal;
          }
        },
        (message) => Console.WriteLine($"Cart 2 alert message: {message}"));

      Console.WriteLine($"Cart 2 price After discount: {total}");

    }
    public static void TestDefaultDelegate()
    {
      var magic = new DefaultDelegates();
      Console.WriteLine($"After discount: {magic.GenerateTotal(TotalPriceCalculation, CalculateDiscounted, AlertMessage)} eur");
    }
    public static void AlertMessage(string message)
    {
      Console.WriteLine(message);
    }
    public static void TotalPriceCalculation(decimal total)
    {
      Console.WriteLine($"Total price: {total} eur");
    } 
    public static decimal CalculateDiscounted(List<Products> items, decimal total)
    {
      // ITEMS NOT USED
      // JUST FOR LATER USAGE
      if(total > 20)
      {
        return total * 0.85M;
      }
      else if(total > 4) 
      {
        return total * 0.98M;
      }
      else if(total > 100)
      {
        return total * 0.70M;
      }
      else
      {
        return total;
      }
    }
  }
}