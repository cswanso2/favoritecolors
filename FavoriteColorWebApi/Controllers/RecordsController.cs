using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FavoriteColorWebApi.Controllers
{
    public class RecordsController : Controller
    {
        // GET: Records
        public ActionResult Index(string recordstring)
        {
            return null;
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            return null;
        }
    }
}