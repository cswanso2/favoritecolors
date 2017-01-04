﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Models;

namespace FavoriteColorProcessor.Sorter
{
    public class LastNameSorter : PersonSorter
    {
        protected override Comparison<Person> Comparison
        {
            get
            {
                return (x, y) => (
                    -1 * string.CompareOrdinal(x.LastName, y.LastName));
            }
        }
    }
}
