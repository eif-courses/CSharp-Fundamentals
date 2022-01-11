namespace Classes
{
  abstract class Building
  {
    public abstract double Area();
  }
  class City
  {
    void CreateBuilding()
    {
      Building building = new Building(); // Class cannot be instantiated

      // Allowed in derived class because also abstract method Area was implemented
      Building kolegija = new VilniausKolegija();
      Console.WriteLine($"Area of Kolegija: {kolegija.Area()}");
    }
  }
  class VilniausKolegija : Building
  {
    public override double Area()
    {
      return 2.4 * 39;
    }
  }
  class Language
  {
    public string Name { get; set; }
  }
  /// Specifies that another class cannot be derived from this type.
  sealed class Math
  {

  }
  /// DIVIDE CLASS IN SEPARATE PIECES BUT USE AS NORMAL CLASS
  partial class Algorithm
  {
    public void BubbleSort() { }
  }
  partial class Algorithm
  {
    public void SearchDFS() { }
  }

  public class Program
  {
    static void Main(string[] args)
    {
      Algorithm algorithm = new Algorithm();
      
      algorithm.SearchDFS();
      algorithm.BubbleSort();



    }
  }
}


