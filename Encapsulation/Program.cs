namespace Encapsulation
{
  // Step 1: What Customer class need ( ABSTRACTION )

  // Step 2: How Validate and CreateDBObjects

  // Step 3: Made those complicated methods as private ( ENCAPSUPLATION )
  public class Customer
  {
    public string Code = "";
    public string Name = "";
    public void Add()
    {

    }
    public bool Validate()
    {
      return true;
    }
    public bool CreateDBObjects()
    {
      return true;
    }
  }

  public class CustomerWithEncapsulation
  {
    public string? Code { get; set; }
    public string? Name { get; set; }
    public void Add()
    {
      Validate();
      CreateDBObjects();
    }
    private bool Validate()
    {
      return true;
    }
    private bool CreateDBObjects()
    {
      return true;
    }
  }
  public class Program
  {
    static void Main() { 
    }
  }
}