using NUnit.Framework;

namespace Kata.Potter.Tests
{
    class PriceCalculatorTests
    {
        [Test]
        public void WhenOneBookIsAdded_ThenReturnsATotalOf8()
        {
            var priceCalculator = new PriceCalculator();

            priceCalculator.AddBook("A");

            Assert.That(priceCalculator.Total, Is.EqualTo(8));
        }

        [Test]
        public void WhenTwoDifferentBooksAreAdded_ThenReturnsATotalOf16()
        {
            var priceCalculator = new PriceCalculator();

            priceCalculator.AddBook("A");
            priceCalculator.AddBook("B");

            Assert.That(priceCalculator.Total, Is.EqualTo(16));
        }
    }
}
