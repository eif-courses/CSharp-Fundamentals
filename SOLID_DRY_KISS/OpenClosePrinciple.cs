﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_DRY_KISS
{
  // The Open/closed Principle says
  // "A software module/class is open for extension and closed for modification".

  /*  Here "Open for extension" means, we need to design our module/class 
   *  in such a way that the new functionality can be added 
   *  only when new requirements are generated. 
   *  "Closed for modification" means we have already developed a class and it has gone through unit testing.
  */


  // SRP and OCP is implemented

  namespace OpenClosePrinciple
  {
    public abstract class Tool
    {
      public abstract void Action();
    }

    public class Pencil : Tool
    {
      public override void Action()
      {
        Draw();
      }

      public void Draw()
      {
        Console.WriteLine("Pencil is Drawing...");
      }
    }
    public class Eraser : Tool
    {
      public override void Action()
      {
        Erase();
      }

      public void Erase()
      {
        Console.WriteLine("Eraser is Erasing...");
      }
    }
    public class ToolSimulator
    {
      public static void Run(Tool[] toolArray)
      {
        foreach (var tool in toolArray)
        {
          tool.Action();
        }
      }
    }
  }
}