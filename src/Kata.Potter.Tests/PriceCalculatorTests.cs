using NUnit.Framework;

namespace Kata.Potter.Tests
{
    class PriceCalculatorTests
    {
        private PriceCalculator _priceCalculator;

        [SetUp]
        public void Initialise()
        {
            _priceCalculator = new PriceCalculator();
        }

        [Test]
        public void WhenOneBookIsAdded_ThenReturnsATotalOf8()
        {
            _priceCalculator.AddBook("A");

            Assert.That(_priceCalculator.Total, Is.EqualTo(8));
        }
    }
}
