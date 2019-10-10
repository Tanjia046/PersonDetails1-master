using PersonDetails.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PersonDetails.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonManager _person;

        public HomeController(IPersonManager person)
        {

            _person = person;
        }
        public ActionResult Index()
        {
            var data = _person.GetAll();
            return View(data);
        }


        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Persons Person)
        {
            if (ModelState.IsValid)
            {
                _person.Add(Person);
                
                return RedirectToAction("Index");
            }

            return View(Person);

        }


        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persons person = _person.Find(Id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,Address,Occupation, Area, Email, ContactNo, Code, Description, IsActive ")]  Persons person)
        {
            if (ModelState.IsValid)
            {
                _person.Entry(person).State = EntityState.Modified;
                
                return RedirectToAction("Index");
            }
            return View(person);
        }













    }
}