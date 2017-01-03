using FavoriteColorProcessor.Models;
using FavoriteColorProcessor.Stores;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Stores
{
    public class PersonDataStoreTests
    {
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

        private PersonDataStore _store;

        [SetUp]
        public void SetUp()
        {
            _store = new PersonDataStore();
        }

        [Test]
        public void TestAdd()
        {
            _store.AddPeople(new List<Person>
            {
                _malePersonYoungestA,
                _femalePersonYoungerB,
                _femalePersonYoungC
            });
            var result = _store.RetrieveDateSorted(); //not crazy on this. Not as atomic as I would like to rely on another method in the class to testAdding. Normally test datastores by querying database, obviously not an option here 
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(1, result.Count(x => x.LastName == _malePersonYoungestA.LastName));
            Assert.AreEqual(1, result.Count(x => x.LastName == _femalePersonYoungerB.LastName));
            Assert.AreEqual(1, result.Count(x => x.LastName == _femalePersonYoungC.LastName));
        }

        [Test]
        public void TestBirthDateSorted()
        {
            _store.AddPeople(new List<Person>
            {
                _malePersonYoungestA,
                _femalePersonYoungerB,
                _femalePersonYoungC
            });
            var result = _store.RetrieveDateSorted();
            var firstPerson = result.ElementAt(0);
            Assert.AreEqual(_femalePersonYoungC.LastName, firstPerson.LastName);
            var secondPerson = result.ElementAt(1);
            Assert.AreEqual(_femalePersonYoungerB.LastName, secondPerson.LastName);
            var thirdPerson = result.ElementAt(2);
            Assert.AreEqual(_malePersonYoungestA.LastName, thirdPerson.LastName);

        }

        [Test]
        public void TestGenderSorted()
        {
            _store.AddPeople(new List<Person>
            {
                _malePersonYoungestA,
                _femalePersonYoungerB,
                _femalePersonYoungC
            });
            var result = _store.RetrieveGenderNameSorted();
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
            _store.AddPeople(new List<Person>
            {
                _malePersonYoungestA,
                _femalePersonYoungerB,
                _femalePersonYoungC
            });
            var result = _store.RetrieveLastNameSorted();
            var firstPerson = result.ElementAt(0);
            Assert.AreEqual(_femalePersonYoungC.LastName, firstPerson.LastName);
            var secondPerson = result.ElementAt(1);
            Assert.AreEqual(_femalePersonYoungerB.LastName, secondPerson.LastName);
            var thirdPerson = result.ElementAt(2);
            Assert.AreEqual(_malePersonYoungestA.LastName, thirdPerson.LastName);
        }
    }
}
