using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrizeGiving.Models;

namespace PrizeGiving.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly GroupEventsQuery _groupEventsQuery;

        public HomeController() : this(new MeetupGroupEventsQuery())
        {
        }

        public HomeController(GroupEventsQuery groupEventsQuery)
        {
            _groupEventsQuery = groupEventsQuery;
        }

        public ActionResult Index()
        {
            var events = _groupEventsQuery.GetEventsForGroup("DeveloperUG");
            var indexModel = new IndexModel(events);

            return View(indexModel);
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

    public class IndexModel
    {
        public SelectList Events { get; set; }
        public MeetupEvent MeetupEvent { get; set; }

        public IndexModel(IEnumerable<MeetupEvent> events)
        {
            Events = new SelectList(events);
        }
    }
}