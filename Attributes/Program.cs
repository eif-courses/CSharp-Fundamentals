using System.Reflection;

namespace Attributes // Note: actual namespace depends on the project name.
{
  [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
  public class Evaluate : Attribute
  {
    private string taskName;

    public Evaluate(string taskName)
    {
      this.taskName = taskName;
    }
    public string TaskName
    {
      get { return taskName; }
    }
  }
  public class Grader
  {
    private static int finalGrade = 0;
    public static void Test(Type type)
    {
      var props = type.GetMethods();

      foreach (var prop in props)
      {
        if (Attribute.IsDefined(prop, typeof(Evaluate)))
        {
          var task = prop.GetCustomAttribute<Evaluate>()?.TaskName;

          var first = 2;
          var second = 2;

          object[] parametersArray = new object[] { first, second };

          switch (task)
          {
            case "addition":
              CountFinalGrade(Addition(first, second) == Invoke(type, prop, parametersArray));
              break;
            case "division":
              CountFinalGrade(Division(first, second) == Invoke(type, prop, parametersArray));
              break;
            default:
              break;
          }

        }
      }
      DisplayFinalGrade();
    }
    private static int Invoke(Type type, MethodInfo method, object[] parameters)
    {
      object? classInstance = Activator.CreateInstance(type, null);
      var result = method.Invoke(classInstance, parameters);
      return (int)result;
    }
    private static int Addition(int a, int b)
    {
      return a + b;
    }
    private static int Division(int a, int b)
    {
      return a / b;
    }
    private static void CountFinalGrade(bool count)
    {
      if (count)
      {
        finalGrade += 5;
      }
    }
    private static void DisplayFinalGrade()
    {
      Console.WriteLine($"Your final evaluation: {finalGrade} !!!");
    }

  }
  public class StudentTask
  {

    [Evaluate("addition")]
    public int AddTwoNumbers(int a, int b)
    {
      return a + b;
    }
    [Evaluate("division")]
    public int DivideTwoNumbers(int a, int b)
    {
      return a / b;
    }
  }

  class MyClass
  {
    static public void Main(String[] args)
    {
      Grader.Test(typeof(StudentTask));
    }

  }
}