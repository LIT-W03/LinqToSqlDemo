using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqToSqlDemo.Data;
using LinqToSqlDemo.Web.Models;

namespace LinqToSqlDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexPageViewModel vm = new IndexPageViewModel();
            PeopleRepository repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            vm.People = repo.GetPeople();
            return View(vm);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            PeopleRepository repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Add(person);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int personId)
        {
            PeopleRepository repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            EditViewModel vm = new EditViewModel();
            vm.Person = repo.GetById(personId);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Update(Person person)
        {
            PeopleRepository repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Update(person);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void Delete(int personId)
        {
            PeopleRepository repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Delete(personId);
        }


    }
}