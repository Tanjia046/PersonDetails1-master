using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonDetails.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonManager _person;

       public HomeController (IPersonManager person){

            _person = person;


        }
        public ActionResult Index()
        {

            var data = _person.GetAll();
            return View(data);
        }
    }
}