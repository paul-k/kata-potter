using NUnit.Framework;

namespace Kata.Potter.Tests
{
    public class PriceCalculatorTests
    {
        [Test]
        public void WhenOneBookIsAdded_ThenReturnsATotalOf8()
        {
            var priceCalculator = new PriceCalculator();

            priceCalculator.AddBook("A");

            Assert.That(priceCalculator.Total, Is.EqualTo(8));
        }

        [Test]
        public void WhenTwoOfTheSameBooksAreAdded_ThenReturnsATotalOf16()
        {
            var priceCalculator = new PriceCalculator();

            priceCalculator.AddBook("A");
            priceCalculator.AddBook("A");

            Assert.That(priceCalculator.Total, Is.EqualTo(16));
        }

        [Test]
        public void WhenTwoDifferentBooksAreAdded_ThenReturnsATotalOf16Minus5Percent()
        {
            var priceCalculator = new PriceCalculator();
            decimal expectedTotal = ((2m * 8m) * 0.95m);

            priceCalculator.AddBook("A");
            priceCalculator.AddBook("B");

            Assert.That(priceCalculator.Total, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void WhenThreeDifferentBooksAreAdded_ThenReturnsATotalOf24Minus10Percent()
        {
            var priceCalculator = new PriceCalculator();
            decimal expectedTotal = ((3m * 8m) * 0.90m);

            priceCalculator.AddBook("A");
            priceCalculator.AddBook("B");
            priceCalculator.AddBook("C");

            Assert.That(priceCalculator.Total, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void WhenFourDifferentBooksAreAdded_ThenReturnsATotalOf32Minus20Percent()
        {
            var priceCalculator = new PriceCalculator();
            decimal expectedTotal = ((4m * 8m) * 0.80m);

            priceCalculator.AddBook("A");
            priceCalculator.AddBook("B");
            priceCalculator.AddBook("C");
            priceCalculator.AddBook("D");

            Assert.That(priceCalculator.Total, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void WhenFiveDifferentBooksAreAdded_ThenReturnsATotalOf40Minus25Percent()
        {
            var priceCalculator = new PriceCalculator();
            decimal expectedTotal = ((5m * 8m) * 0.75m);

            priceCalculator.AddBook("A");
            priceCalculator.AddBook("B");
            priceCalculator.AddBook("C");
            priceCalculator.AddBook("D");
            priceCalculator.AddBook("E");

            Assert.That(priceCalculator.Total, Is.EqualTo(expectedTotal));
        }

        //[Test]
        //public void WhenThreeBooksAreAddedButOnlyTwoAreDifferent_ThenReturnsATotalOf24Minus5Percent()
        //{
        //    var priceCalculator = new PriceCalculator();
        //    decimal expectedTotal = ((3m * 8m) * 0.95m);

        //    priceCalculator.AddBook("A");
        //    priceCalculator.AddBook("B");
        //    priceCalculator.AddBook("B");

        //    Assert.That(priceCalculator.Total, Is.EqualTo(expectedTotal));
        //}
    }
}
