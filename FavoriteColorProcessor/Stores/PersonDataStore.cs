using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Models;

namespace FavoriteColorProcessor.Stores
{
    /// <summary>
    /// Assumes low amount of writes, and high amount of retrievals.
    /// If access pattern was high writes low retrievals would do insertion sort
    /// </summary>
    public class PersonDataStore : IPersonDataStore
    {
        private readonly List<Person> _store; //authoritative list of people. Unsorted

        //caches to be flushed on adds
        private List<Person> _lastNameSorted; 

        private List<Person> _genderLastNameSorted;
        private List<Person> _dateOfBirthSorted;




        public PersonDataStore()
        {
            _store = new List<Person>();
        }

        //Not too proud of setting these to null.
        private void FlushCaches()
        {
            _lastNameSorted = null;
            _genderLastNameSorted = null;
            _dateOfBirthSorted = null;
        }


        public void AddPeople(IEnumerable<Person> people)
        {
            //only accept valid data. Throw out entire set if wrong to prevent readding a valid person later
            //debated duplicate exception as well. But would argue nothing in a person object counts as a unique identifier
            foreach (var person in people)
            {
                if (string.IsNullOrEmpty(person.LastName)) 
                    throw new InvalidDataException();
                if (string.IsNullOrEmpty(person.FirstName))
                    throw new InvalidDataException();
                if (string.IsNullOrEmpty(person.Gender))
                    throw new InvalidDataException();
                if (string.IsNullOrEmpty(person.FavoriteColor))
                    throw new InvalidDataException();
            }
            _store.AddRange(people);
            FlushCaches();
        }

        private void InitializeSortedCache(List<Person> cache, Comparison<Person> comparision)
        {
            cache = _store.ToList(); //create copy of references so it can be sorted in different ways
            cache.Sort(comparision);
        }

        public List<Person> RetrieveDateSorted()
        {
            if (_dateOfBirthSorted == null)
            {
                InitializeSortedCache(_dateOfBirthSorted,
                    new Comparison<Person>((x, y) => (DateTime.Compare(x.DateOfBirth, y.DateOfBirth))));
            }
            return _dateOfBirthSorted;
        }

        public List<Person> RetrieveGenderNameSorted()
        {
            if (_genderLastNameSorted == null)
            {
                InitializeSortedCache(_genderLastNameSorted, new Comparison<Person>((x, y) => (
                x.Gender == y.Gender ? 
                -1 * String.CompareOrdinal(x.LastName, y.LastName)
                : String.CompareOrdinal(x.Gender, y.Gender)
                )));
            }
            return _genderLastNameSorted;
        }

        public List<Person> RetrieveLastNameSorted()
        {
            if(_lastNameSorted == null)
            {
                InitializeSortedCache(_lastNameSorted, new Comparison<Person>((x, y) => (
                -1 * String.CompareOrdinal(x.LastName, y.LastName))));
            }
            return _lastNameSorted;
        }
    }
}
