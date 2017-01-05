using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Factories
{
    public interface IPersonFactory
    {
        /// <summary>
        /// Create a person object from an array of strings
        /// </summary>
        /// <param name="strArray">String array</param>
        /// <returns>A person object</returns>
        Person CreatePerson(string[] strArray);
        /// <summary>
        /// Creates a string representation of a person in csv format
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        string CreateString(Person person);
    }
}
