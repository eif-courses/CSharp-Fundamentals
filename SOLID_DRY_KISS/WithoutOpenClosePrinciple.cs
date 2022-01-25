using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DRY_KISS
{
  public class Pencil
  {
    public void Draw()
    {
      Console.WriteLine("Pencil is Drawing...");
    }
  }
  public class Eraser
  {
    public void Erase()
    {
      Console.WriteLine("Eraser is Erasing...");
    }
  }
  // Main problem each new tool added we should 
  // append ToolSimulator with extra if statement
  // So its breaks rule because WE OPEN FOR Extension
  // ToolSimulator is not close for modification
  public class ToolSimulator
  {
    public static void Run(object [] toolArray)
    {
      Eraser eraser;
      Pencil pencil;

      foreach (var tool in toolArray)
      {
        if(tool is Pencil)
        {
          pencil = (Pencil)tool;
          pencil.Draw();
        }
        else
        {
          eraser = (Eraser)tool;
          eraser.Erase();
        }
      }
    }
  } 
}