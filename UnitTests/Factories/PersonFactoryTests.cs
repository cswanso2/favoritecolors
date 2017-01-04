using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Factories;
using FavoriteColorProcessor.Models;
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
        [TestCase("Shelly", "Jenson", "Female", "Red", "12/5/1995")]
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

        [Test]
        [TestCase("Mark", "Markson", "Male", "Blue", "12/5/1995")]
        [TestCase("Shelly", "Jenson", "Female", "Red", "12/5/1995")]
        public void CreateString(string lastName, string firstName, string gender, string favoriteColor, string dateOfBirthString)
        {
            _mockDateFactory.Setup(x => x.GetString(It.IsAny<DateTime>())).Returns(dateOfBirthString);
            var exepectedPersonString = $"{lastName},{firstName},{dateOfBirthString},{gender},{favoriteColor}";
            var person = new Person { LastName = lastName,
                FirstName = firstName,
                Gender = gender,
                FavoriteColor = favoriteColor,
                DateOfBirth = DateTime.ParseExact(dateOfBirthString, "M/d/yyyy", CultureInfo.InvariantCulture) };
            var resultPersonString = _personFactory.CreateString(person);
            Assert.AreEqual(exepectedPersonString, resultPersonString);
        }
    }
}
