using FavoriteColorProcessor.Models;
using FavoriteColorProcessor.Parser;
using FavoriteColorProcessor.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Factories;
using FavoriteColorProcessor.Sorter;

namespace FavoriteColorProcessor
{
    public class Program
    {
        private const string GenderSort = "gender";
        private const string DateOfBirthSort = "birthdate";
        private const string LastNameSort = "lastname";

        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    var path = GetPath();
                    var parser = new FavoriteColorParser();
                    var results = parser.ProcessFile(path);
                    OutputData(results);
                }
                catch (Exception)
                {
                    Console.WriteLine("Unkown Error please try again");
                }
                
            }
        }

        //Could definitely have more error handling around this
        private static string GetPath()
        {
            Console.WriteLine("Input path of file to process names:");
            return Console.ReadLine();
        }


        private static void OutputData(IEnumerable<Person> results)
        {
            PersonSorter sorter;
            var personFactory = new PersonFactory();
            Console.WriteLine($"\nInput sort either {GenderSort}, {DateOfBirthSort}, or {LastNameSort}. gender is females before males, birthDate is ascending, and lastName is descending:");
            var sort = Console.ReadLine().ToLower();
            if (sort == GenderSort)
                sorter = new GenderSorter();           
            else if (sort == DateOfBirthSort)
                sorter = new AgeSorter();
            else if (sort == LastNameSort)
                sorter = new LastNameSorter();
            else
                throw new FormatException("Invalid Sort");
            var sorted = sorter.Sort(results.ToList());
            foreach(var person in sorted)
            {
                Console.WriteLine(personFactory.CreateString(person));
            }
        }
    }
}
