using System;
using System.Configuration;
/// <summary>
///  There is two types of constants
///  RUNTIME AND COMPILE TIME
/// </summary>


namespace Constants
{
  public class Program
  {
    public const int MAX_VOLUME = 100; // Compile time constant "Absolute constant"

    // Runtime constant, you can modify and initialize from settings file or other place"
    public static readonly int MIN_VOLUME;

    // Static constructors use for initialization readonly constants
    // during runtime from App.config file for example reading MIN_VOLUME value
    static Program()
    {
      var configurationValue = ConfigurationManager.AppSettings["MIN_VOLUME"];
      MIN_VOLUME = Convert.ToInt16(configurationValue);
      
    }

    static void Main()
    {
      Console.WriteLine(MIN_VOLUME);
    }
  }
}