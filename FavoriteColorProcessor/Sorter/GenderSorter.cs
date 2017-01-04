using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Models;

namespace FavoriteColorProcessor.Sorter
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
