using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CSV_test
{
    class Program
    {
        static void Main(string[] args)
        {

            using(StreamReader sr = new StreamReader("test.csv"))
            {
                string val = sr.ReadToEnd();

                CSVDataContainer data = new CSVDataContainer(new System.IO.StringReader(val));

                foreach (var item in data.Rows)
                {
                    Console.WriteLine("{0}, {1}, {2}", item.name1, item.name2, item.name3);
                }
            }
           
        }
    }
}
