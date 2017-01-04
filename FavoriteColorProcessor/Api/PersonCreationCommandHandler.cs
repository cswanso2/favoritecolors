using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Models;
using FavoriteColorProcessor.Parser;
using FavoriteColorProcessor.Stores;

namespace FavoriteColorProcessor.Api
{
    public class PersonCreationCommandHandler
    {
        private static IPersonDataStore _store = new PersonDataStore();
        private readonly FavoriteColorParser _processor;
        public void Post(string commandLine)
        {
            var people = _processor.ProcessString(commandLine);
            _store.AddPeople(people);
        }

        public List<Person> GetGenderSorted()
        {
            return _store.RetrieveGenderNameSorted();
        }

        public List<Person> GetAgeSorted()
        {
            return _store.RetrieveDateSorted();
        }

        public List<Person> GetLastNameSorted()
        {
            return _store.RetrieveLastNameSorted();
        } 
    }
}
