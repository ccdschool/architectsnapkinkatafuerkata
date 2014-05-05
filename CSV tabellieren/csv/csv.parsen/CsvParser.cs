using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv.parsen
{
    public class CsvParser
    {
        public string[][] Parsen(IEnumerable<string> csvText)
        {
            return csvText.Select(csvLine => csvLine.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                          .ToArray();
        } 


        public Tuple<string[], string[][]> Header_von_Body_trennen(IEnumerable<string[]> records)
        {
            var header = records.First();
            var body = records.Skip(1).ToArray();
            return new Tuple<string[], string[][]>(header, body);
        } 
    }
}
