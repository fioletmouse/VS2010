using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsHabr
{
    class Counter
    {
        // we can delete this string and change next one on "Action" cause action doen't return param and does't have inputs
        public delegate void MessageContainer();

        // and change MessageContainer here on Action
        public event MessageContainer onMessage = delegate {};

        public void Count()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i == 51)
                {
                    onMessage();
                }
            }
        }
    }

    class Handler1
    {
        public void Message()
        {
            Console.WriteLine("Danger!Danger! 51 now");
        }
    }

    class Handler2
    {
        public void Warning()
        {
            Console.WriteLine("Warning! It's 99 now!");
        }
    }


}
