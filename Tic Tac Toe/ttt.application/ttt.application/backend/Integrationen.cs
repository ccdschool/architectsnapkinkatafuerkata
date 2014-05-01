using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ttt.application.data;

namespace ttt.application.backend
{
    class Integrationen
    {
        public void Starten()
        {
            Neues_Spiel_erzeugen();   
        }

        public void Spielstein_setzen(int spielfeldIndex)
        {
            Console.WriteLine("Spielfeldindex: {0}", spielfeldIndex);
            this.Spielstand(new Spielstand());
        }

        public void Neues_Spiel_erzeugen()
        {
            var spielstand = new Spielstand();
            this.Spielstand(spielstand);
        }

        public event Action<Spielstand> Spielstand;
    }
}
