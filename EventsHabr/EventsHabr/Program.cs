using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsHabr
{
    class Program
    {
        static void Main(string[] args)
        {
            // For Habr file code            
            /*Counter c = new Counter();
            Handler1 h1 = new Handler1();
            Handler2 h2 = new Handler2();

            c.onMessage += h1.Message;
            c.onMessage += h2.Warning;

            c.Count();*/


            // For lambda expression testing
            /*Lambda l = new Lambda();
            l.SomeEvent += (n) => Console.WriteLine("n value = " + n.ToString());
            l.OnSomeEvent(5);*/


            // For EventHandler without argument
            /*MyEvent m = new MyEvent();
            Handler3 h3 = new Handler3();

            m.SomeEvent += h3.Message;
            m.OnSomeEvent();*/

            MyEventWithParam me = new MyEventWithParam();
            ConsoleKeyInfo key;
            int count = 0;

            me.CallEvent += (sender, e) => Console.WriteLine(" - we've pressed " + e.ch + " on keyboard");
            me.CallEvent += (sender, e) => count++;

            do
            {
                key = Console.ReadKey();
                me.onKeyPress(key.KeyChar);
            }
            while (key.KeyChar != '.');

            Console.WriteLine("summary: " + count.ToString());
        }
    }
}
