using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPeoplePoejct.Client;
using MvcPeoplePoejct.Models;

namespace MvcPeoplePoejct.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var url = "http://agl-developer-test.azurewebsites.net/people.json";
            BaseClient client = new BaseClient();
            var result = client.GetJson<List<Person>>(url);
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}