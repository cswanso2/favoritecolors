using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Models;

namespace FavoriteColorProcessor.Stores
{
    public interface IPersonDataStore
    {
        /// <summary>
        /// Adds a group of people to the store
        /// </summary>
        /// <param name="people">Enumerable set of people being added to the datastore</param>
        void AddPeople(IEnumerable<Person> people);

        //debated making these one function with a sort parameter. Decided against it based on limited number of sorts

        /// <summary>
        /// Retrieves people sorted by gender, Female before Male. Than sorted by last Name Asscending
        /// </summary>
        /// <returns>Sorted list of all people in the data store</returns>
        List<Person> RetrieveGenderNameSorted();
        /// <summary>
        /// Retrieves people sorted by date of birth ascending
        /// </summary>
        /// <returns>Sorted list of all people in the data store</returns>
        List<Person> RetrieveDateSorted();
        /// <summary>
        /// Retrieves people sorted by last name descending
        /// </summary>
        /// <returns>Sorted list of all people in the data store</returns>
        List<Person> RetrieveLastNameSorted();


    }
}
