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
        public Frontend()
        {
            InitializeComponent();
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
            MessageBox.Show("Neuer Spielstand!");
        }


        public event Action<int> Spielfeld_ausgewählt;
        public event Action Neues_Spiel_angefordert;
    }
}
