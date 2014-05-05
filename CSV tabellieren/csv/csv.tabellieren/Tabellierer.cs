using System;
using System.Collections.Generic;
using System.Linq;

namespace csv.tabellieren
{
    public class Tabellierer
    {
        public IEnumerable<string> Tabelle_bauen(Tuple<string[], string[][]> tabellenteile)
        {
            var spaltenbreiten = Spaltenbreiten_ermitteln(tabellenteile);
            var tabellierter_header = Header_formatieren(tabellenteile.Item1, spaltenbreiten);
            var tabellierter_body = Body_formatieren(tabellenteile.Item2, spaltenbreiten);
            return Tabelle_zusammenbauen(tabellierter_header, tabellierter_body);
        }

        private int[] Spaltenbreiten_ermitteln(Tuple<string[], string[][]> tabellenteile)
        {
            var spaltenbreiten = tabellenteile.Item1.Select(v => v.Length).ToArray();
            for (var i = 0; i < spaltenbreiten.Length; i++)
                spaltenbreiten[i] = Math.Max(spaltenbreiten[i], 
                                             tabellenteile.Item2.Select(r => r[i]).Max(v => v.Length));
            return spaltenbreiten;
        }

        private IEnumerable<string> Header_formatieren(string[] headerRecord, int[] spaltenbreiten)
        {
            yield return Enumerable.First<string>(Body_formatieren(new[] {headerRecord}, spaltenbreiten));

            var unterstreichungen = spaltenbreiten.Select(breite => "".PadRight(breite, '-'));
            yield return string.Join("+", unterstreichungen);
        }

        private IEnumerable<string> Body_formatieren(IEnumerable<string[]> bodyRecords, int[] spaltenbreiten)
        {
            return bodyRecords.Select<string[], string>(br => string.Join("|", Werte_auf_Spaltenbreiten_bringen(br, spaltenbreiten)));
        }

        private string[] Werte_auf_Spaltenbreiten_bringen(IEnumerable<string> werte, int[] spaltenbreiten)
        {
            return werte.Select((w, i) => w.PadRight(spaltenbreiten[i], ' ')).ToArray();
        }

        private IEnumerable<string> Tabelle_zusammenbauen(IEnumerable<string> tabellierterHeader, IEnumerable<string> tabellierterBody)
        {
            return tabellierterHeader.Concat(tabellierterBody);
        }
    }
}