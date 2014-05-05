using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv.parsen
{
    public class CsvParser
    {
        public IEnumerable<string[]> Parsen(IEnumerable<string> csvText)
        {
            return csvText.Select(csvLine => csvLine.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries));
        } 


        public Tuple<string[], IEnumerable<string[]>> Header_von_Body_trennen(IEnumerable<string[]> records)
        {
            throw new NotImplementedException();
        } 
    }
}
