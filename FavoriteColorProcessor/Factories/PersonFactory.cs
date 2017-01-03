using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Models;

namespace FavoriteColorProcessor.Factories
{
    public class PersonFactory : IPersonFactory
    {
        private readonly IDateFactory _dateFactory;

        public PersonFactory(IDateFactory dateFactory)
        {
            _dateFactory = dateFactory;
        }

        public PersonFactory()
        {
            _dateFactory = new DateFactory();
        }

        private const int LastNameIndex = 0;
        private const int FirstNameIndex = 1;
        private const int GenderIndex = 2;
        private const int FavoriteColorIndex = 3;
        private const int DateOfBirthIndex = 4;

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
