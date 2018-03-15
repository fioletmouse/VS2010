using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamic_test
{
    class Program
    {
        // Разбитие лямбдe на параметры
        static void Main(string[] args)
        {
            Util<ClientContactType> x = new Util<ClientContactType>();

            int g = x.CallInterface<int>(cl => cl.RetValue("1234"));
        }
    }
}
