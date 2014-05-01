using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ttt.application.data
{
    class Spielbrett
    {
        private List<int> _züge; 
        public void Leeren() { _züge = new List<int>();}

        public IEnumerable<int> Züge
        {
            get { return _züge; }
        }

        public void Zug_registrieren(int spielfeldIndex)
        {
            if (Wurde_Zug_schon_ausgeführt(spielfeldIndex)) throw new InvalidOperationException("Zug wurde schon einmal ausgeführt. Spielfeldindex: " + spielfeldIndex);
            _züge.Add(spielfeldIndex);
        }

        public bool Wurde_Zug_schon_ausgeführt(int spielfeldIndex)
        {
            return _züge.Contains(spielfeldIndex);
        }
    }
}
