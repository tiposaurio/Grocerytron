using Grocerytron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocerytron.Controllers
{
    public class HomeController : Controller
    {
        private IGrocerytronRepository _repo;
        public HomeController(IGrocerytronRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var lists = _repo.GetLists().ToList();

            return View(lists);
        }
    }
}
