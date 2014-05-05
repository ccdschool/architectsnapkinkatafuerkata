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


        private IEnumerable<string> Tabelle_bauen(Tuple<string[], string[][]> tabellenteile)
        {
            var spaltenbreiten = Spaltenbreiten_ermitteln(tabellenteile);
            var tabellierter_header = Header_formatieren(tabellenteile.Item1, spaltenbreiten);
            var tabellierter_body = Body_formatieren(tabellenteile.Item2, spaltenbreiten);
            return Tabelle_zusammenbauen(tabellierter_header, tabellierter_body);
        }


        private int[] Spaltenbreiten_ermitteln(Tuple<string[], string[][]> tabellenteile)
        {
            return tabellenteile.Item1.Select(v => v.Length).ToArray();
        }


        private IEnumerable<string> Header_formatieren(string[] headerRecord, int[] spaltenbreiten)
        {
            yield return Body_formatieren(new[] {headerRecord}, spaltenbreiten).First();

            var unterstreichungen = spaltenbreiten.Select(breite => "".PadRight(breite, '-'));
            yield return string.Join("+", unterstreichungen);
        }


        private IEnumerable<string> Body_formatieren(string[][] bodyRecords, int[] spaltenbreiten)
        {
            return bodyRecords.Select(br => string.Join("|", br));
        }


        private IEnumerable<string> Tabelle_zusammenbauen(IEnumerable<string> tabellierterHeader, IEnumerable<string> tabellierterBody)
        {
            return tabellierterHeader.Concat(tabellierterBody);
        }
    }
}
