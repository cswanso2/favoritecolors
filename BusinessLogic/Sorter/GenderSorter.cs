using System;
using BusinessLogic.Models;

namespace BusinessLogic.Sorter
{
    /// <summary>
    /// Sorts people based on gender
    /// </summary>
    public class GenderSorter : PersonSorter
    {
        protected override Comparison<Person> Comparison
        {
            get
            {
                return (x, y) => (
                    x.Gender == y.Gender
                        ? string.CompareOrdinal(x.LastName, y.LastName)
                        : string.CompareOrdinal(x.Gender, y.Gender));
            }
        }

    }
}
