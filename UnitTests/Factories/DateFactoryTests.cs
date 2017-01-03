using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Factories;
using NUnit.Framework;

namespace UnitTests.Factories
{
    public class DateFactoryTests
    {
        private DateFactory _dateFactory;

        [SetUp]
        public void SetUp()
        {
            _dateFactory = new DateFactory();
        }

        [Test]
        [TestCase(12, 21, 1992)]
        [TestCase(5, 10, 2017)]
        [TestCase(10, 1, 2013)]

        public void CreatesDate(int month, int day, int year)
        {
            var dateString = $"{month}/{day}/{year}";
            var result = _dateFactory.GetDate(dateString);
            Assert.AreEqual(result.Day, day);
            Assert.AreEqual(result.Month, month);
            Assert.AreEqual(result.Year, year);
        }

        [Test]
        [TestCase(12, -1, 1992)]
        [TestCase(-5, 10, 2017)]
        [TestCase(10, 1, -2013)]

        public void InvalidNegativeNumbers(int month, int day, int year)
        {
            var dateString = $"{month}/{day}/{year}";
            Assert.Throws<InvalidDataException>(() => _dateFactory.GetDate(dateString));
        }

        [Test]
        [TestCase(12, 33, 1992)]
        [TestCase(13, 10, 2017)]
        [TestCase(10, 1, 10000)]

        public void InvalidLargeNumbers(int month, int day, int year)
        {
            var dateString = $"{month}/{day}/{year}";
            Assert.Throws<InvalidDataException>(() => _dateFactory.GetDate(dateString));
        }

    }
}
