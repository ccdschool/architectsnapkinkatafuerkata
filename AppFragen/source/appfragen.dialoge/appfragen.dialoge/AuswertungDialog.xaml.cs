using System.Windows;
using appfragen.contracts;

namespace appfragen.dialoge
{
    public partial class AuswertungDialog : Window
    {
        public AuswertungDialog() {
            InitializeComponent();
        }

        public void Auswertung_Anzeigen(Auswertung auswertung) {
            ShowDialog();
        }
    }
}