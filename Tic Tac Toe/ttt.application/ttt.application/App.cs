using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ttt.application.backend;
using ttt.application.data;

namespace ttt.application
{
    class App
    {
        public App(Frontend frontend)
        {
            var spielbrett = new Spielbrett();
            var integration = new Integrationen(spielbrett);

            frontend.Spielfeld_ausgewählt += integration.Spielstein_setzen;
            frontend.Neues_Spiel_angefordert += integration.Neues_Spiel_erzeugen;

            integration.Spielstand += frontend.Spielstand_anzeigen;

            _run = integration.Starten;
        }


        private readonly Action _run;
        public void Run()
        {
            _run();
        }
    }
}
