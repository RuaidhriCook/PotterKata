using NUnit.Framework;
using PotterKata;

namespace PotterKataTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FiveDifferent()
        {
            //Arrange
            int[] booksSelected = { 1, 2, 3, 4, 5 };

            //Act
            var result = PricingService.CalcPrice(booksSelected);

            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void FiveDifferentAndTwoDifferent()
        {
            //Arrange
            int[] booksSelected = { 1, 1, 2, 2, 3, 4, 5 };

            //Act
            var result = PricingService.CalcPrice(booksSelected);

            //Assert
            Assert.AreEqual(45.2, result);
        }

        [Test]
        public void FourDifferentAndThreeSame()
        {
            //Arrange
            int[] booksSelected = { 1, 2, 2, 2, 2, 4, 5 };

            //Act
            var result = PricingService.CalcPrice(booksSelected);

            //Assert
            Assert.AreEqual(49.6, result);
        }

        [Test]
        public void NoBooks()
        {
            //Arrange
            int[] booksSelected = {};

            //Act
            var result = PricingService.CalcPrice(booksSelected);

            //Assert
            Assert.AreEqual(0, result);
        }
    }
}