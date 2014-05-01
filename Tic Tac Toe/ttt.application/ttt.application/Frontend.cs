using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ttt.application.backend;
using ttt.application.data;

namespace ttt.application
{
    public partial class Frontend : Form
    {
        private List<Button> _spielfelder; 

        public Frontend()
        {
            InitializeComponent();

            _spielfelder = new List<Button>();
            _spielfelder.AddRange(new[]{button1, button2, button3,
                                        button4, button5, button6,
                                        button7, button8, button9});
        }


        private void neuesSpielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Neues_Spiel_angefordert();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Spielfeld_geklickt(object sender, EventArgs e)
        {
            var spielfeldIndex = int.Parse(((Button) sender).Tag.ToString());
            this.Spielfeld_ausgewählt(spielfeldIndex);
        }
        

        public void Spielstand_anzeigen(Spielstand spielstand)
        {
            lblHinweis.Text = spielstand.Hinweis;
            for (var i = 0; i < spielstand.Spielbrett.Length; i++)
                _spielfelder[i].Text = spielstand.Spielbrett[i] == Spielstein.X
                                       ? "X"
                                       : (spielstand.Spielbrett[i] == Spielstein.O ? "O" : " ");

        }


        public event Action<int> Spielfeld_ausgewählt;
        public event Action Neues_Spiel_angefordert;
    }
}
