﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavoriteColorProcessor.Factories;
using FavoriteColorProcessor.Models;
using Microsoft.VisualBasic.FileIO;
using NLog;

namespace FavoriteColorProcessor.Parser
{
    public class FavoriteColorFileParser
    {
        private const string CommaDelimiter = ", ";
        private const string SpaceDelimiter = " ";
        private const string PipeDelimiter = " | ";

        private readonly IPersonFactory _personFactory;

        public FavoriteColorFileParser()
        {
            _personFactory = new PersonFactory();    
        }

        /// <summary>
        /// Processes a file, and returns a list 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IEnumerable<Person> ProcessFile(string path)
        {
            List<Person> personList;
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                personList = ProcessParser(parser);
            }
            return personList;
        }

        private List<Person> ProcessParser(TextFieldParser parser)
        {
            var personList = new List<Person>();
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(new string[] {CommaDelimiter, PipeDelimiter, SpaceDelimiter});
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                try
                {
                    var person = _personFactory.CreatePerson(fields);
                    personList.Add(person);
                }
                catch (Exception e)
                {
                    //don't blow up file for bad row, although making heavy assumptions about the general safety of the csv files
                    LogManager.GetCurrentClassLogger().Error(e, $"Unable to process row {fields}");
                }
            }
            return personList;
        }

        public IEnumerable<Person> ProcessString(string personString)
        {
            List<Person> personList;
            using (TextFieldParser parser = new TextFieldParser(new MemoryStream(Encoding.UTF8.GetBytes(personString ?? ""))))
            {
                personList = ProcessParser(parser);
            }
            return personList;
        } 
    }
}
