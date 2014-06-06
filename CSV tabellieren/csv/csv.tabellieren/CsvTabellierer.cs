using System;
using System.Collections.Generic;
using System.Linq;
using csv.parsen;

namespace csv.tabellieren
{
    public class CsvTabellierer
    {
        public IEnumerable<string> Tabellieren(IEnumerable<string> csvText)
        {
            var tabellierer = new Tabellierer();

            var tabellenteile = Parsen(csvText);
            return tabellierer.Tabelle_bauen(tabellenteile);
        }


        private static Tuple<string[], string[][]> Parsen(IEnumerable<string> csvText)
        {
            var parser = new CsvParser();

            var records = parser.Parsen(csvText);
            return parser.Header_von_Body_trennen(records);
        }
    }
}
