/// <remarks>
/// 2022, Marius Gzegozevskis, .NET 6
/// </remarks>
/**
 * <summary>
 * C# - Delegates
 * What if we want to pass a function as a parameter? How does C# handles the callback functions or event handler? The answer is - delegate.
 * The delegate is a reference type data type that defines the method signature. You can define variables of delegate, just like other data type, that can refer to any method with the same signature as the delegate.
 * There are three steps involved while working with delegates:
 * 1. Declare a delegate
 * 2. Set a target method
 * 3. Invoke a delegate
 * A delegate can be declared using the <b>delegate</b> keyword followed by a function signature, as shown below.
 * </summary>
 */

///<summary>
/// DELEGATE SYNTAX
/// [access modifier] delegate [return type] [delegate name]([parameters]) 
/// </summary>

/// <summary>EXMAPLE: Declare a Delegate
/// public delegate void MyDelegate(string msg);
/// Above, we have declared a delegate MyDelegate with a void return type and a string parameter. 
/// A delegate can be declared outside of the class or inside the class. Practically, it should be declared out of the class.
/// After declaring a delegate, we need to set the target method or a lambda expression.
/// We can do it by creating an object of the delegate using the new keyword and passing a method whose signature matches the delegate signature.
/// </summary>

public delegate void PurchaseDelegate(double amount); // delegate declaration

class Program
{
  static void Main(string[] args)
  {

    // You able to use PurchaseDelegate combaining with any method matches delegate signature
    // signature = same method return type and parameter count
    
    PurchaseDelegate purchaseDelegate = Student.BuyFood;
    purchaseDelegate(32.25);

    // You also able to use purchaseDelage.Invoke(32.25);

    purchaseDelegate = Manager.BuyNewCar;
    purchaseDelegate.Invoke(25000);

    // Lambda is Fun to use it also combined with Delegates

    purchaseDelegate = amount => Console.WriteLine($"You have used secret method and spended: {amount} eur.");
    purchaseDelegate(1200);
    
    // Longer version of lambda or multiple parameters
    // purchaseDelegate = (double amount) => Console.WriteLine($"You have used secret method and spended: {amount} eur.");

    PassDelegateByParameter.InvokeDelegate(purchaseDelegate);

  }
}

class PassDelegateByParameter
{
  public static void InvokeDelegate(PurchaseDelegate purchaseDelegate) // PurchaseDelegate type parameter
  {
    purchaseDelegate(new Random().Next(1000));  
  }
}

class Student
{
  public static void BuyFood(double amount) {
    Console.WriteLine($"You spended: {amount} eur, Your Check: 3x Cans of Beer, Chips and Steak!");
  }
}
class Manager
{
  public static void BuyNewCar(double amount)
  {
    Console.WriteLine($"You spended: {amount} eur, You are Lucky today get Porsche from Auction House so Cheap!");
  }
}


