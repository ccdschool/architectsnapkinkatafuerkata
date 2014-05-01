using System.Collections.Generic;
using System.Linq;

namespace ttt.application.backend
{
    class Spielregeln
    {
        public string Spieler_bestimmen(IEnumerable<int> züge)
        {
            return züge.Count()%2 == 0 ? "X am Zug" : "O am Zug";
        }
    }
}