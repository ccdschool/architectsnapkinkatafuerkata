using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using equalidator;

namespace csv.parsen.tests
{
    [TestFixture]
    public class akzeptanz
    {
        [Test]
        public void Datei_parsen()
        {
            var sut = new CsvParser();

            var result = sut.Parsen(File.ReadLines("personen.csv"));

            var expected = new[]
                {
                    new[]{"Name", "Alter", "Stadt"},
                    new[]{"Paul", "13", "Köln"},
                    new[]{"Peter", "42", "München"},
                    new[]{"Maria", "34", "Hamburg"}
                };
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void Header_von_Body_trennen()
        {
            var sut = new CsvParser();

            var records = sut.Parsen(File.ReadLines("personen.csv"));
            var result = sut.Header_von_Body_trennen(records);

            var expectedHeader = new[] {"Name", "Alter", "Stadt"};
            var expectedRecords = new[]
                {
                    new[]{"Paul", "13", "Köln"},
                    new[]{"Peter", "42", "München"},
                    new[]{"Maria", "34", "Hamburg"}
                };
            Equalidator.AreEqual(new Tuple<string[],string[][]>(expectedHeader, expectedRecords), result,true);
        }
    }
}
