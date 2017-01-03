using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Models;

namespace FavoriteColorProcessor.Factories
{
    public class PersonFactory
    {
        private readonly DateFactory _dateFactory;

        public PersonFactory(DateFactory dateFactory)
        {
            _dateFactory = dateFactory;
        }

        private const int LastNameIndex = 0;
        private const int FirstNameIndex = 1;
        private const int GenderIndex = 2;
        private const int FavoriteColorIndex = 3;
        private const int DateOfBirthIndex = 4;

        /// <summary>
        /// Used to create a person object. Takes in a string array. Assumed to be in the order of the constant ints laid out above.
        /// </summary>
        /// <param name="csvRow">Raw csv row of personal information</param>
        /// <returns>Person object</returns>
        public Person CreatePerson(string[] csvRow)
        {
            var dateString = csvRow[DateOfBirthIndex];
            var date = _dateFactory.GetDate(dateString);
            return new Person()
            {
                DateOfBirth = date,
                FavoriteColor = csvRow[FavoriteColorIndex],
                FirstName = csvRow[FirstNameIndex],
                LastName = csvRow[LastNameIndex],
                Gender = csvRow[GenderIndex]
            };
        }

        public string CreateString(Person person)
        {
            return $"{person.LastName},{person.FirstName},{_dateFactory.GetString(person.DateOfBirth)},{person.Gender},{person.FavoriteColor}";
        }
    }
}
