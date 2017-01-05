using System;
using BusinessLogic.Models;

namespace BusinessLogic.Sorter
{
    public class AgeSorter : PersonSorter
    {
        protected override Comparison<Person> Comparison
        {
            get
            {
                return (x, y) => (DateTime.Compare(x.DateOfBirth, y.DateOfBirth));
            }
        }
    }
}
