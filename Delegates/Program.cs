namespace Delegates;
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
public delegate int MulticastDelegate(); // delegate declaration for multicast usage
public delegate T AddDelegate<T>(T param1, T param2); // generic delegate example



public delegate int Calculator(int a, int b);
class Program
{

  static int Print(int a, int b) { return a / b; }

  static void Addition(Calculator c){
    Console.WriteLine(c(121, 21));
  }


  static void Main(string[] args)
  {
    Calculator calculator = (a, b) => a + b;
    Calculator calculator2 = (a, b) => Print(a, b);
    
    Addition(calculator2);

    ///Console.WriteLine(calculator(22,2));


    Console.WriteLine("------------------CUSTOM DELEGATE EXAMPLES RESULTS-------------------------");
    // You able to use PurchaseDelegate combaining with any method matches delegate signature
    // signature = same method return type and parameter count

    PurchaseDelegate purchaseDelegate = Student.BuyFood;
    purchaseDelegate(32.25);

    // You also able to use purchaseDelage.Invoke(32.25);

    purchaseDelegate = Manager.BuyNewCar;
    purchaseDelegate.Invoke(25000);


    // Lambda is Fun to use it also combined with Delegates

    purchaseDelegate = x => Console.WriteLine($"You have used secret method and spended: {x} eur.");

    purchaseDelegate(1200);

    // Longer version of lambda or multiple parameters
    // purchaseDelegate = (double amount) => Console.WriteLine($"You have used secret method and spended: {amount} eur.");

    PassDelegateByParameter.InvokeDelegate(purchaseDelegate);

    // Multicast Delegate
    // The delegate can point to multiple methods.
    // A delegate that points multiple methods is called a multicast delegate.
    // The "+" or "+=" operator adds a function to the invocation list, and the "-" and "-=" operator removes it.

    MulticastDelegate bathroom = BathroomMulticastExample.Area;
    MulticastDelegate kitchen = KitchenMulticastExample.Area;


 

    // Basically it calls delegates: first bathroom, second kitchen and so on

    MulticastDelegate result = bathroom + kitchen;
    result += bathroom;
    
    Console.WriteLine("------------------MULTICAST DELEGATE EXAMPLE RESULT-------------------------");
    Console.WriteLine("BATHROOM CODE = 711, KITCHEN CODE = 30");
    Console.WriteLine("----------------------------------------------------------------------------");
    Console.WriteLine($"CURRENT VALUE: Result of delegates call: {result.Invoke()}"); // returns kitchen area last delegate in list
 
   
   
    // Removing operator in delegates
    result = result - kitchen; // removes kitchen 

    Console.WriteLine($"AFTER REMOVING KITCHEN: Result of delegates call: {result.Invoke()}");

   // result -= kitchen; // removes another kitchen

    // Shorter version result() same as result.Invoke()
   // Console.WriteLine($"AFTER REMOVING KITCHEN: Result of delegates call: {result()}");

    // A generic delegate can be defined the same way as a delegate but using generic type parameters or return type.
    // The generic type must be specified when you set a target method.
    // For example, consider the following generic delegate that is used for int and string parameters.

    Console.WriteLine("------------------GENERIC DELEGATE EXAMPLE RESULT-------------------------");

    AddDelegate<int> add = DummyClassGenericDelegate.SumOfTwoNumbers;
    AddDelegate<string> concat = DummyClassGenericDelegate.Concatenate;

    Console.WriteLine($"Result of sum: {add(19, 21)}");
    Console.WriteLine($"Result of string concat:{concat("Delegates is ", "Easy to learn")}");
    Console.WriteLine("----------------------------------------------------------------------------");

    Console.WriteLine("------------------DEFAULT DELEGATE FUNC EXAMPLE RESULT-------------------------");
    // Delegates similar to Java functional interface Combained With Lambda
    DefaultDelegateUsage.TestDefaultDelegate();
    // Passing custom functionallity or anonymous functions
    DefaultDelegateUsage.TestSInlineMethodsVersion();
  }
}

// GENERIC DELEGATE EXAMPLE CLASSES

class DummyClassGenericDelegate
{
  public static int SumOfTwoNumbers(int a, int b)
  {
    return a + b;
  }
  public static string Concatenate(string str1, string str2)
  {
    return str1 + str2;
  }
}

// MULTICAST DELEGATE EXAMPLE CLASSES
class BathroomMulticastExample
{
  public static int Area() { return 711; }
}
class KitchenMulticastExample
{
  public static int Area() { return 30; }
}

// PASS BY PARAMETER DELEGATE EXAMPLE CLASSES
class PassDelegateByParameter
{
  public static void InvokeDelegate(PurchaseDelegate purchaseDelegate) // PurchaseDelegate type parameter
  {
    purchaseDelegate(new Random().Next(1000));  
  }
}

// CUSTOM USER DEFINED DELEGATE EXAMPLE CLASSES
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

