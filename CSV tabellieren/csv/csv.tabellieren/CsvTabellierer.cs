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
            var parser = new CsvParser();
            var tabellierer = new Tabellierer();

            var records = parser.Parsen(csvText);
            var tabellenteile = parser.Header_von_Body_trennen(records);
            return tabellierer.Tabelle_bauen(tabellenteile);
        }
    }
}
