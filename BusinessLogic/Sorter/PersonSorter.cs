using System;
using System.Collections.Generic;
using BusinessLogic.Models;

namespace BusinessLogic.Sorter
{
    public abstract class PersonSorter
    {
        protected abstract Comparison<Person> Comparison { get; }

        /// <summary>
        /// Sorts a list of people and returns it.
        /// </summary>
        /// <param name="people">Inserting list of peopole</param>
        /// <returns>A list of inserted people</returns>
        public virtual List<Person> Sort(List<Person> people)
        {
            people.Sort(Comparison);
            return people;
        }
    }
}
