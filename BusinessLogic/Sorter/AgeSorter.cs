using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
