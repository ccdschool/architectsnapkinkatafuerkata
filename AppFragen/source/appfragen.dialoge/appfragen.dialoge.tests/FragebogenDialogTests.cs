using System.Windows;
using appfragen.contracts;
using NUnit.Framework;

namespace appfragen.dialoge.tests
{
    [TestFixture]
    public class FragebogenDialogTests
    {
        [Test, Explicit, RequiresSTA]
        public void Anzeigen() {
            var sut = new FragebogenDialog();

            sut.Befragung_starten += () => MessageBox.Show("Befragung starten");
            sut.Auswerten += () => MessageBox.Show("Auswerten");
            sut.Antwort_gegeben += i => MessageBox.Show(string.Format("Antwort {0} gegeben", i));

            sut.ShowDialog();
        }

        [Test, Explicit, RequiresSTA]
        public void Antwortbogen_anzeigen() {
            var sut = new FragebogenDialog();
            sut.Antwort_gegeben += i => MessageBox.Show(string.Format("Antwort {0} gegeben", i));

            sut.Antwortbogen_anzeigen(new Antwortbogen {
                IstAuswertbar = false,
                Fragestellungen = new [] {
                    new Fragestellung{ Frage = "Frage 1", Antwortmöglichkeiten = new[]{"Antwort 1", "Antwort 2", "Antwort 3"}},
                    new Fragestellung{ Frage = "Frage 2", Antwortmöglichkeiten = new[]{"Antwort 4", "Antwort 5", "Antwort 6"}}
                }
            });

            sut.ShowDialog();
        }
    }
}