using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrizeGiving.Models;
using PrizeGiving.Domain.SelectWinner;
using PrizeGiving.Domain.Commands;

namespace PrizeGiving.Mvc.Models
{
    public class HomeController : Controller
    {
        private readonly GroupEventsQuery _groupEventsQuery;
        private SelectWinnerCommand _selectWinnerCommand;

        //We are doing poor man's injection for the mvp but will replace this with an IOC like ninject
        public HomeController() : this(new MeetupGroupEventsQuery(), new SelectWinnerCommand(new MeetupGroupEventRsvpQuery(), new CSharpRandomizer()))
        {
        }

        public HomeController(GroupEventsQuery groupEventsQuery, SelectWinnerCommand selectWinnerCommand)
        {
            _groupEventsQuery = groupEventsQuery;
            _selectWinnerCommand = selectWinnerCommand;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var events = _groupEventsQuery.GetEventsForGroup("DeveloperUG");
            var indexModel = new IndexPresentation() { Events = events };

            return View(indexModel);
        }

        [HttpPost]
        public ActionResult SelectWinner(string meetupEventId)
        {
            var winner = _selectWinnerCommand.SelectWinnerForEvent(meetupEventId);

            return View("Winner", new SelectWinnerPresentation(winner));
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