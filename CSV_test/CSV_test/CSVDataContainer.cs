using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace CSV_test
{
    class CSVDataContainer
    {
        private class CSVRow : DynamicObject
        {
            private List<Tuple<string, string>> values = new List<Tuple<string, string>>();
            
            public CSVRow(IEnumerable<string> headers,
                          IEnumerable<string> items)
            {
                values.AddRange(headers.Zip(items, (header, item) => Tuple.Create(header, item)));
            }

            public override bool TryGetMember(GetMemberBinder binder,
                                              out object result)
            {
                var answer = values.FirstOrDefault(n => n.Item1 == binder.Name);

                result = answer.Item2;

                return result != null;
            }
        }
        
        private List<string> columnNames = new List<string>();

        private List<CSVRow> data = new List<CSVRow>();

        public CSVDataContainer(System.IO.TextReader stream)
        {
            // read headers:
            var headers = stream.ReadLine();

            columnNames = (from header in headers.Split(';')
                         select header.Trim()).ToList();

            var line = stream.ReadLine();

            while (line != null)
            {
                //var items = line.Split(';');
                var items = from item in line.Split(';') select item;
                data.Add(new CSVRow(columnNames, items));
                line = stream.ReadLine();
            }
        }

        public dynamic this[int index]
        {
            get { return data[index]; }
        }
        public IEnumerable<dynamic> Rows
        {
            get { return data; }
        }
    }
}
