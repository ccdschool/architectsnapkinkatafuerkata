using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csv.parsen;

namespace csv.tabellieren
{
    public class CsvTabellierer
    {
        public IEnumerable<string> Tabellieren(IEnumerable<string> csvText)
        {
            var parser = new CsvParser();

            var records = parser.Parsen(csvText);
            var tabellenteile = parser.Header_von_Body_trennen(records);
            return Tabelle_bauen(tabellenteile);
        }


        private IEnumerable<string> Tabelle_bauen(Tuple<string[], IEnumerable<string[]>> tabellenteile)
        {
            throw new NotImplementedException();
        }
    }
}
