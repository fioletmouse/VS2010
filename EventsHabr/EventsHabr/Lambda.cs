using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsHabr
{
    class Lambda
    {
        public delegate void MyDelegate(int n);
        public event MyDelegate SomeEvent;

        public void OnSomeEvent(int n)
        {
            if (SomeEvent != null)
            {
                SomeEvent(n);
            }
        }

    }
}
