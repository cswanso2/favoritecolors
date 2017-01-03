using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FavoriteColorProcessor.Factories
{
    public class DateFactory : IDateFactory
    {

        private const string DateFormat = "M/d/yyyy";
        /// <summary>
        /// Returns a DateTime object for a datestring. Throws an exception for improperly formated string. Assumption made as no details were provided about string format
        /// </summary>
        /// <param name="dateString">input string. Expected to be formatted as mm/dd/yyyy</param>
        /// <returns>DateTimeObject</returns>
        public DateTime GetDate(string dateString)
        {
            try
            {
                var date = DateTime.ParseExact(dateString, DateFormat, CultureInfo.InvariantCulture);
                return date;
            }
            catch (Exception)
            {
                //may not be a totally valid error message
                throw new InvalidDataException($"Date is improperly formatted. Expected format is mm/dd/yyy. Provided format is {dateString}");
            }
        }

        public string GetString(DateTime date)
        {
            return date.ToString(DateFormat);
        }
    }
}
