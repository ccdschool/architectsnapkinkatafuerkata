using System.Collections.Generic;
using NUnit.Framework;

namespace todictionary.tests
{
    [TestFixture]
    public class Dictionary_erzeugen_Tests
    {
        [Test]
        public void Dictionary_aus_drei_Name_Wert_Paaren_erzeugen() {
            var result = StringUtils.Dictionary_erzeugen(new[] {
                new KeyValuePair<string, string>("a", "1"),
                new KeyValuePair<string, string>("b", "2"),
                new KeyValuePair<string, string>("c", "3")
            });

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result["a"], Is.EqualTo("1"));
            Assert.That(result["b"], Is.EqualTo("2"));
            Assert.That(result["c"], Is.EqualTo("3"));
        }
    }
}