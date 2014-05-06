using NUnit.Framework;

namespace todictionary.tests
{
    [TestFixture]
    public class ToDictionary_Integrationstests
    {
        [Test]
        public void Akzeptanztest() {
            var result = StringUtils.ToDictionary("a=1;b=2;c=3");

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result["a"], Is.EqualTo("1"));
            Assert.That(result["b"], Is.EqualTo("2"));
            Assert.That(result["c"], Is.EqualTo("3"));
        } 
    }
}