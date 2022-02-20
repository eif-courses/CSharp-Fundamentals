using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
  internal class CustomEventArgs
  {
    // !!! For events be sure !!! 
    // Dangerous if you would like not to change value directly use private set
    public string Message { get; set; } 
    public CustomEventArgs(string message)
    {
      Message = message;
    }
  }
}
