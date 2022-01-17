namespace Indexers
{
  class Wheel
  {
    public string? BrandName { get; set; }
    public string? Material { get; set; }
  }

  class Color
  {
    public string? Name { get; set; }
    public int HexValue { get; set; }
  }

  class CarNoIndexer
  {
    private readonly List<Color> colors = new List<Color>(); // aggregated collection

    public CarNoIndexer()
    {
      colors.Add(new Color { Name = "CUSTOM RED", HexValue = 0xAA00FF });
      colors.Add(new Color { Name = "CUSTOM GREEN", HexValue = 0xAAFFFF });
      colors.Add(new Color { Name = "CUSTOM GRAY", HexValue = 0xAAAAFF });
    }

    // Simple approach readColor list and by Name

    public Color? GetColor(string Name)
    {
      foreach (var color in colors)
      {
        if (color.Name == Name)
        {
          return color;
        }
      }
      return null;
    }
    public Color? GetColor(int HexValue)
    {
      foreach (var color in colors)
      {
        if (color.HexValue == HexValue)
        {
          return color;
        }
      }
      return null;
    }
  }
  class CarWithIndexer
  {
    private readonly List<Color> colors = new List<Color>(); // aggregated collection
    public CarWithIndexer()
    {
      colors.Add(new Color { Name = "CUSTOM RED", HexValue = 0xAA00FF });
      colors.Add(new Color { Name = "CUSTOM GREEN", HexValue = 0xAAFFFF });
      colors.Add(new Color { Name = "CUSTOM GRAY", HexValue = 0xAAAAFF });

    }


    // Using an integer is a common means of accessing arrays in many languages, but the C# Indexer goes beyond this.
    // Indexers can be declared with multiple parameters and each parameter may be a different type.
    // Additional parameters are separated by commas, the same as a method parameter list.
    // Valid parameter types for Indexers include integers, enums, and strings. Additionally, Indexers can be overloaded.

    public Color this[int HexValue]
    {
      get
      {
        foreach (var color in colors)
        {
          if (color.HexValue == HexValue)
          {
            return color;
          }
        }
        return null;
      }
    }

    // Overloaded Indexer
    public Color this[string Name]
    {
      get {
        foreach (var color in colors)
        {
          if (color.Name == Name)
          {
            return color;
          }
        }
        return null;
      }
    }
    

  }

  public class Program
  {
    private const int HEX_VALUE = 0xAAAAFF;
    private const string COLOR_NAME = "CUSTOM RED";

    public static void Main()
    {
      // Simple usage without indexer
      CarNoIndexer noIndexer = new CarNoIndexer();
      Console.WriteLine($"color hex by name: {noIndexer.GetColor(COLOR_NAME).HexValue}");
      Console.WriteLine($"color name by hex: {noIndexer.GetColor(HEX_VALUE).Name}");

      // Same but with indexer
      CarWithIndexer withIndexer = new CarWithIndexer();
      Console.WriteLine($"color hex by name: {withIndexer[COLOR_NAME].HexValue}");
      Console.WriteLine($"color name by hex: {withIndexer[HEX_VALUE].Name}");


      // Multiple parameters indexer from IndexerWithMultipleParameter.cs file
      Board board = new Board();

      board["A", 4] = new Player { Name = "White Queen" };
      board["H", 4] = new Player { Name = "Black King" };

      Console.WriteLine("A4 = {0}", board["A", 4]);
      Console.WriteLine("H4 = {0}", board["H4"]);



    }
  }
}