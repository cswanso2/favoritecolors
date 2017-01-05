using System;

namespace BusinessLogic.Factories
{
    public interface IDateFactory
    {
        /// <summary>
        /// Get's a date from a string
        /// </summary>
        /// <param name="dateString">The string </param>
        /// <returns>A datetime object</returns>
        DateTime GetDate(string dateString);

        /// <summary>
        /// Gets a string from a datetime object
        /// </summary>
        /// <param name="date">The date being turned into a string</param>
        /// <returns>A string representation of a date</returns>
        string GetString(DateTime date);
    }
}
