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
        private readonly Person MalePersonYoungestA = new Person()
        {
            LastName = "a",
            FirstName = "a",
            DateOfBirth = new DateTime(1995, 12, 21),
            FavoriteColor = "a",
            Gender = "Male"
        };
        private readonly Person FemalePersonYoungerB = new Person()
        {
            LastName = "b",
            FirstName = "b",
            DateOfBirth = new DateTime(1995, 12, 20),
            FavoriteColor = "b",
            Gender = "Female"
        };

        private readonly Person FemalePersonYoungC = new Person()
        {
            LastName = "c",
            FirstName = "c",
            DateOfBirth = new DateTime(1995, 12, 19),
            FavoriteColor = "c",
            Gender = "Female"
        };

        private readonly PersonDataStore _store = new PersonDataStore();

        [Test]
        private void TestAdd()
        {
            _store.AddPeople(new List<Person>
            {
                MalePersonYoungestA,
                FemalePersonYoungerB,
                FemalePersonYoungC
            });
            var result = _store.RetrieveDateSorted(); //not crazy on this. Not as atomic as I would like to rely on another method in the class to testAdding. Normally test datastores by querying database, obviously not an option here 
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(1, result.Count(x => x.LastName == MalePersonYoungestA.LastName));
            Assert.AreEqual(1, result.Count(x => x.LastName == FemalePersonYoungerB.LastName));
            Assert.AreEqual(1, result.Count(x => x.LastName == FemalePersonYoungC.LastName));
        }

        [Test]
        private void TestBirthDateSorted()
        {
            _store.AddPeople(new List<Person>
            {
                MalePersonYoungestA,
                FemalePersonYoungerB,
                FemalePersonYoungC
            });
            var result = _store.RetrieveDateSorted();
            var firstPerson = result.ElementAt(0);
            Assert.AreEqual(MalePersonYoungestA.LastName, firstPerson.LastName);
            var secondPerson = result.ElementAt(1);
            Assert.AreEqual(FemalePersonYoungerB.LastName, secondPerson.LastName);
            var thirdPerson = result.ElementAt(2);
            Assert.AreEqual(FemalePersonYoungC.LastName, thirdPerson.LastName);
        }

        [Test]
        private void TestGenderSorted()
        {
            _store.AddPeople(new List<Person>
            {
                MalePersonYoungestA,
                FemalePersonYoungerB,
                FemalePersonYoungC
            });
            var result = _store.RetrieveGenderNameSorted();
            var firstPerson = result.ElementAt(0);
            Assert.AreEqual(FemalePersonYoungerB.LastName, firstPerson.LastName);
            var secondPerson = result.ElementAt(1);
            Assert.AreEqual(FemalePersonYoungC.LastName, secondPerson.LastName);
            var thirdPerson = result.ElementAt(2);
            Assert.AreEqual(MalePersonYoungestA.LastName, thirdPerson.LastName);
        }

        [Test]
        private void TestLastNameSorted()
        {
            _store.AddPeople(new List<Person>
            {
                MalePersonYoungestA,
                FemalePersonYoungerB,
                FemalePersonYoungC
            });
            var result = _store.RetrieveLastNameSorted();
            var firstPerson = result.ElementAt(0);
            Assert.AreEqual(FemalePersonYoungC.LastName, firstPerson.LastName);
            var secondPerson = result.ElementAt(1);
            Assert.AreEqual(FemalePersonYoungerB.LastName, secondPerson.LastName);
            var thirdPerson = result.ElementAt(2);
            Assert.AreEqual(MalePersonYoungestA.LastName, thirdPerson.LastName);
        }
    }
}
