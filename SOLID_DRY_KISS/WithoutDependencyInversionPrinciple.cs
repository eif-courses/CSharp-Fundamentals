using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * The Dependency Inversion Principle (DIP) states that high-level modules/classes should not depend on low-level modules/classes.
 * Both should depend upon abstractions. Secondly, abstractions should not depend upon details. 
 * Details should depend upon abstractions.
 * High - level modules/classes implement business rules or logic in a system (application). 
 * Low - level modules / classes deal with more detailed operations; 
in other words they may deal with writing information to databases or passing messages to the operating system or services.
*/
namespace SOLID_DRY_KISS
{
  internal class WithoutDependencyInversionPrinciple
  {
  }
}
