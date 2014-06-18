using appfragen.contracts;
using NUnit.Framework;

namespace appfragen.dialoge.tests
{
    [TestFixture]
    public class AuswertungDialogTests
    {
        [Test, Explicit, RequiresSTA]
        public void Anzeigen() {
            var sut = new AuswertungDialog();
            sut.Auswertung_Anzeigen(new Auswertung());
        } 

        [Test, Explicit, RequiresSTA]
        public void Anzeigen_ist_mehrfach_möglich() {
            var sut = new AuswertungDialog();
            sut.Auswertung_Anzeigen(new Auswertung());
            sut.Auswertung_Anzeigen(new Auswertung());
            sut.Auswertung_Anzeigen(new Auswertung());
        } 
    }
}