using BusinessLogic.Models;
using BusinessLogic.Parser;
using BusinessLogic.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft;
using System.Web.Mvc;
using BusinessLogic.Factories;

namespace FavoriteColorWebApi.Controllers
{
    //Could definitely have more error handling in here
    public class RecordsController : Controller
    {
        private readonly FavoriteColorParser _parser;
        private readonly DateFactory _dateFactory;
        private static IPersonDataStore _store = new PersonDataStore();

        static RecordsController()
        {
            _store = new PersonDataStore();
        }

        public RecordsController()
        {
            _parser = new FavoriteColorParser();
            _dateFactory = new DateFactory(); 
        }

        private object PersonToJson(Person person)
        {
            return new
            {
                LastName = person.LastName,
                FirstName = person.FirstName,
                Gender = person.Gender,
                BirthDay = _dateFactory.GetString(person.DateOfBirth),
                FavoriteColor = person.FavoriteColor
            };
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult RecordsPost(string personRecord)
        {
            var person = _parser.ProcessString(personRecord);
            _store.AddPeople(person);
            return new HttpStatusCodeResult(201);
        }

        public ActionResult Gender()
        {
            var result = _store.RetrieveGenderNameSorted();
            return Json(result.Select(PersonToJson), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Name()
        {
            var result = _store.RetrieveLastNameSorted();
            return Json(result.Select(PersonToJson), JsonRequestBehavior.AllowGet);
        }

        public ActionResult BirthDate()
        {
            var result = _store.RetrieveDateSorted();
            return Json(result.Select(PersonToJson), JsonRequestBehavior.AllowGet);
        }
    }
}