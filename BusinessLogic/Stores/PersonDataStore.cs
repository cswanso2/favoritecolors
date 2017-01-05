using System.Collections.Generic;
using System.IO;
using System.Linq;
using BusinessLogic.Models;
using BusinessLogic.Sorter;

namespace BusinessLogic.Stores
{
    /// <summary>
    /// Assumes low amount of writes, and high amount of retrievals.
    /// If access pattern was high writes low retrievals would do insertion sort
    /// </summary>
    public class PersonDataStore : IPersonDataStore
    {
        private readonly List<Person> _store; //authoritative list of people. Unsorted

        private readonly GenderSorter _genderSorter;
        private readonly AgeSorter _ageSorter;
        private readonly LastNameSorter _nameSorter;

        //caches to be flushed on adds
        private List<Person> _lastNameSorted; 
        private List<Person> _genderLastNameSorted;
        private List<Person> _dateOfBirthSorted;




        public PersonDataStore()
        {
            _genderSorter = new GenderSorter();
            _ageSorter = new AgeSorter();
            _nameSorter = new LastNameSorter();
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


        public List<Person> RetrieveDateSorted()
        {
            if (_dateOfBirthSorted == null)
            {
                _dateOfBirthSorted = _store.ToList();
                _dateOfBirthSorted = _ageSorter.Sort(_dateOfBirthSorted);
            }
            return _dateOfBirthSorted;
        }

        public List<Person> RetrieveGenderNameSorted()
        {
            if (_genderLastNameSorted == null)
            {
                _genderLastNameSorted = _store.ToList();
                _genderLastNameSorted = _genderSorter.Sort(_genderLastNameSorted);
            }
            return _genderLastNameSorted;
        }

        public List<Person> RetrieveLastNameSorted()
        {
            if(_lastNameSorted == null)
            {
                _lastNameSorted = _store.ToList();
                _lastNameSorted = _nameSorter.Sort(_lastNameSorted);
            }
            return _lastNameSorted;
        }
    }
}
