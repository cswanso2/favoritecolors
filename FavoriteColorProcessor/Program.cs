using FavoriteColorProcessor.Models;
using FavoriteColorProcessor.Parser;
using FavoriteColorProcessor.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavoriteColorProcessor
{
    public class Program
    {
        private const string GenderSort = "gender";
        private const string DateOfBirthSort = "birthDate";
        private const string LastNameSort = "lastName";

        static void Main(string[] args)
        {
            while(true)
            {
                var path = GetPath();
                var parser = new FavoriteColorFileParser();
                var results = parser.ProcessFile(path);
                

            }
        }

        //Could definitely have more error handling around this
        private static string GetPath()
        {
            Console.WriteLine("Input path of file to process names");
            return Console.ReadLine();
        }


        private static void OutputData(List<Person> results)
        {
            var store = new PersonDataStore();
            var personFactory = new PersonFactory();
            store.AddPeople(results);
            Console.WriteLine($"Input sort either {GenderSort}, {DateOfBirthSort}, or {LastNameSort}. gender is females before males, birthDate is ascending, and lastName is descending");
            var sort = Console.ReadLine().ToLower();
            List<Person> sorted;
            if (sort == GenderSort)
                sorted = store.RetrieveGenderNameSorted();
            else if (sort == DateOfBirthSort)
                sorted = store.RetrieveDateSorted();
            else if (sort == LastNameSort)
                sorted = store.RetrieveLastNameSorted();
            else
                throw new FormatException("Invalid Sort");
            foreach(var person in sorted)
            {

                Console.WriteLine($"{person.LastName},{}")
            }
        }
    }
}
