using System;
using System.Text;
using System.Threading.Tasks;
using ttt.application.data;

namespace ttt.application.backend
{
    class Integrationen
    {
        private readonly Spielbrett _spielbrett;
        private readonly Projektionen _projektionen;

        public Integrationen(Spielbrett spielbrett)
        {
            _spielbrett = spielbrett;
            _projektionen = new Projektionen();
        }

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
            _spielbrett.Leeren();
            var hinweis = "X am Zug";
            var spielstand = _projektionen.Spielstand_erzeugen(_spielbrett.Züge, hinweis);
            this.Spielstand(spielstand);
        }

        public event Action<Spielstand> Spielstand;
    }
}
