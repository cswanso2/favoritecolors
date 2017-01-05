using System;
using System.Globalization;
using System.IO;

namespace BusinessLogic.Factories
{
    public class DateFactory : IDateFactory
    {

        private const string DateFormat = "M/d/yyyy";
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
