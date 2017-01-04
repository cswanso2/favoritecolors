using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Models;
using FavoriteColorProcessor.Sorter;
using NUnit.Framework;

namespace UnitTests.Sorters
{
    public class SorterTests
    {
        PersonSorter _sorter;
        private readonly Person _malePersonYoungestA = new Person()
        {
            LastName = "a",
            FirstName = "a",
            DateOfBirth = new DateTime(1995, 12, 21),
            FavoriteColor = "a",
            Gender = "Male"
        };
        private readonly Person _femalePersonYoungerB = new Person()
        {
            LastName = "b",
            FirstName = "b",
            DateOfBirth = new DateTime(1995, 12, 20),
            FavoriteColor = "b",
            Gender = "Female"
        };

        private readonly Person _femalePersonYoungC = new Person()
        {
            LastName = "c",
            FirstName = "c",
            DateOfBirth = new DateTime(1995, 12, 19),
            FavoriteColor = "c",
            Gender = "Female"
        };

        [Test]
        public void AgeSorterTests()
        {
            _sorter = new AgeSorter();
            var result = _sorter.Sort(new List<Person>
            {
                _malePersonYoungestA,
                _femalePersonYoungerB,
                _femalePersonYoungC
            });
            var firstPerson = result.ElementAt(0);
            Assert.AreEqual(_femalePersonYoungC.LastName, firstPerson.LastName);
            var secondPerson = result.ElementAt(1);
            Assert.AreEqual(_femalePersonYoungerB.LastName, secondPerson.LastName);
            var thirdPerson = result.ElementAt(2);
            Assert.AreEqual(_malePersonYoungestA.LastName, thirdPerson.LastName);
        }

        [Test]
        public void GenderSorterTests()
        {
            _sorter = new GenderSorter();
            var result = _sorter.Sort(new List<Person>
            {
                _malePersonYoungestA,
                _femalePersonYoungerB,
                _femalePersonYoungC
            });
            var firstPerson = result.ElementAt(0);
            Assert.AreEqual(_femalePersonYoungerB.LastName, firstPerson.LastName);
            var secondPerson = result.ElementAt(1);
            Assert.AreEqual(_femalePersonYoungC.LastName, secondPerson.LastName);
            var thirdPerson = result.ElementAt(2);
            Assert.AreEqual(_malePersonYoungestA.LastName, thirdPerson.LastName);
        }

        [Test]
        public void TestLastNameSorted()
        {
            _sorter = new LastNameSorter();
            var result = _sorter.Sort(new List<Person>
            {
                _malePersonYoungestA,
                _femalePersonYoungerB,
                _femalePersonYoungC
            });
            var firstPerson = result.ElementAt(0);
            Assert.AreEqual(_femalePersonYoungC.LastName, firstPerson.LastName);
            var secondPerson = result.ElementAt(1);
            Assert.AreEqual(_femalePersonYoungerB.LastName, secondPerson.LastName);
            var thirdPerson = result.ElementAt(2);
            Assert.AreEqual(_malePersonYoungestA.LastName, thirdPerson.LastName);
        }
    }
}
