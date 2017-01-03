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

        private void InitializeSortedCache(ref List<Person> cache, Comparison<Person> comparison)
        {
            cache = _store.ToList(); //create copy of references so it can be sorted in different ways
            cache.Sort(comparison);
        }

        public List<Person> RetrieveDateSorted()
        {
            if (_dateOfBirthSorted == null)
            {
                InitializeSortedCache(ref _dateOfBirthSorted,
                    (x, y) => (-1 * DateTime.Compare(x.DateOfBirth, y.DateOfBirth)));
            }
            return _dateOfBirthSorted;
        }

        public List<Person> RetrieveGenderNameSorted()
        {
            if (_genderLastNameSorted == null)
            {
                InitializeSortedCache(ref _genderLastNameSorted, (x, y) => (
                    x.Gender == y.Gender ? 
                        string.CompareOrdinal(x.LastName, y.LastName)
                        : string.CompareOrdinal(x.Gender, y.Gender)
                    ));
            }
            return _genderLastNameSorted;
        }

        public List<Person> RetrieveLastNameSorted()
        {
            if(_lastNameSorted == null)
            {
                InitializeSortedCache(ref _lastNameSorted, (x, y) => (
                    -1 * string.CompareOrdinal(x.LastName, y.LastName)));
            }
            return _lastNameSorted;
        }
    }
}
