using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsHabr
{
    class MyEventArg: EventArgs
    {
        public char ch;
    }

    class MyEventWithParam
    {
        public event EventHandler<MyEventArg> CallEvent;

        public void onKeyPress(char key)
        {
            MyEventArg mea = new MyEventArg();
            if (CallEvent != null)
            {
                mea.ch = key;
                CallEvent(this, mea);
            }
        }
    }
}
