using System.Windows;
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

            sut.ShowDialog();
        } 
    }
}