using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace TestProject2.CSV_Tools
{
    public class CSVWriter
    {
        public void CsvWriter(string email, string subj, string message, int num)
        {
            var notes = new List<Foo>
            {
            new Foo{toWhom = email, Subject = subj, Message = message, Number = num }
            };
            using (var writer = new StreamWriter(@"C:\Users\pc\Desktop\TestProject2\TestProject2\Resources\CheckIncoming.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(notes);
            }
        }
    }
}
