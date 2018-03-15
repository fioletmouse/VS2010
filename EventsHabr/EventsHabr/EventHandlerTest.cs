using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsHabr
{
    class MyEvent
    {
        public event EventHandler SomeEvent;

        public void OnSomeEvent()
        {
            if (SomeEvent != null)
            {
                SomeEvent(this, EventArgs.Empty);
            }
        }
    }

    class Handler3
    {
        public void Message(object source, EventArgs arg)
        {
            Console.WriteLine("Event happened. Source is " + source.ToString() );
        }
    }
}
