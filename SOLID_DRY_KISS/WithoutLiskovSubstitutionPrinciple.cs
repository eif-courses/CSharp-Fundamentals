using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




/*In the given example FighterPlane and PaperPlane classes both extending the Plane class which contain startEngine() method.
 * So it's clear that FighterPlane can start engine but PaperPlane can’t so it’s breaking LSP.
 * PaperPlane class although extending Plane class and should be substitutable in place of it
 * but is not an eligible entity that Plane’s instance could be replaced by, 
 * because a paper plane can’t start the engine as it doesn’t have one. So the good example would be,
*/

// https://www.codeproject.com/Articles/648987/Violating-Liskov-Substitution-Principle-LSP
// ---------------------------------------------------------
//      Violating Liskov Substitution Principle in OOP
// --------------------------------------------------------- 

namespace SOLID_DRY_KISS
{
  class MyCollection
  {
    public int Count { get; set; }
  }

  class MyArray : MyCollection
  {
  }

}
