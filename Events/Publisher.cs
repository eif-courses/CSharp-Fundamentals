using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
  internal class Publisher
  {

    public event EventHandler<CustomEventArgs> RaiseCustomEvent;

    public void DoSomething()
    {
      OnRaiseCustomEvent(new CustomEventArgs("Level up!!!"));
    }
    protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
    {
      e.Message += $"at {DateTime.Now}";
      RaiseCustomEvent?.Invoke(this, e);
     
    }
  }
}
