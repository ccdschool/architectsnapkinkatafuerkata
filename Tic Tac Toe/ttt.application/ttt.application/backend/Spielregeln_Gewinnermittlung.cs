using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ttt.application.backend
{
    partial class Spielregeln
    {
        public void Gewinner_ermitteln(Action<string> spielende, Action weiter)
        {
            var spielerzüge = Züge_nach_Spielern_trennen();
            var gewinnreihen = Gewinnreihen_zusammenstellen();
            Spielergewinn_prüfen(gewinnreihen, spielerzüge[0],
                () => spielende("Gratulation! X hat gewonnen."),
                () => Spielergewinn_prüfen(gewinnreihen, spielerzüge[1],
                         () => spielende("Gratulation! O hat gewonnen."),
                         weiter));
        }


        internal int[][] Züge_nach_Spielern_trennen()
        {
            var xZüge = _spielbrett.Züge.Where((z, i) => i%2 == 0).ToArray();
            var oZüge = _spielbrett.Züge.Where((z, i) => i % 2 != 0).ToArray();
            return new[] {xZüge, oZüge};
        }


        private IEnumerable<int[]> Gewinnreihen_zusammenstellen()
        {
            // horizontal
            yield return Gewinnreihe_generieren(0, 1, 3).ToArray();
            yield return Gewinnreihe_generieren(3, 1, 3).ToArray();
            yield return Gewinnreihe_generieren(6, 1, 3).ToArray();
            // vertikal
            yield return Gewinnreihe_generieren(0, 3, 3).ToArray();
            yield return Gewinnreihe_generieren(1, 3, 3).ToArray();
            yield return Gewinnreihe_generieren(2, 3, 3).ToArray();
            // diagonal
            yield return Gewinnreihe_generieren(0, 4, 3).ToArray();
            yield return Gewinnreihe_generieren(2, 2, 3).ToArray();
        }

        internal IEnumerable<int> Gewinnreihe_generieren(int startindex, int delta, int n)
        {
            while (n-- > 0)
                yield return startindex + n*delta;
        } 



        internal void Spielergewinn_prüfen(IEnumerable<int[]> gewinnreihen, int[] spielerzüge,
                                  Action gewinn, Action weiter)
        {
            if (gewinnreihen.Any(gr => spielerzüge.Intersect(gr).Count() == gr.Count())) {
                gewinn();
                return;
            }
            weiter();
        }
    }
}
