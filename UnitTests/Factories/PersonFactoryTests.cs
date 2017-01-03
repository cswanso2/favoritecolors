using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Factories;
using Moq;
using NUnit.Framework;

namespace UnitTests.Factories
{
    public class PersonFactoryTests
    {
        private const int Day = 5;
        private const int Month = 12;
        private const int Year = 1995;

        private Mock<IDateFactory> _mockDateFactory;
        private PersonFactory _personFactory;


        [SetUp]
        public void SetUp()
        {
            _mockDateFactory = new Mock<IDateFactory>();
            _mockDateFactory.Setup(x => x.GetDate(It.IsAny<string>())).Returns(new DateTime(Year, Month, Day));
            _personFactory = new PersonFactory(_mockDateFactory.Object);
        }

        [Test]
        [TestCase("Mark", "Markson", "Male", "Blue", "12/5/1995")]
        [TestCase("Shelly", "Jenson", "Femal", "Red", "12/5/1995")]
        public void CreatePerson(string lastName, string firstName, string gender, string favoriteColor, string dateOfBirthString)
        {
            var stringArrayPerson = new string[] {lastName, firstName, gender, favoriteColor, dateOfBirthString};
            var person = _personFactory.CreatePerson(stringArrayPerson);
            Assert.AreEqual(lastName, person.LastName);
            Assert.AreEqual(firstName, person.FirstName);
            Assert.AreEqual(gender, person.Gender);
            Assert.AreEqual(favoriteColor, person.FavoriteColor);
            Assert.AreEqual(person.DateOfBirth.Year, Year);
            Assert.AreEqual(person.DateOfBirth.Month, Month);
            Assert.AreEqual(person.DateOfBirth.Day, Day);

        }
    }
}
