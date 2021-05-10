using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ass_3.Models;

namespace Ass_3.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditSchedule(int id)
        {
            return View(dc.RailwayDatas.First(x => x.Id == id));
        }

        public ActionResult EditS(int id)
        {
            var rts = dc.RailwayDatas.First(s => s.Id == id);

            rts.Name = Request["tname"];
            rts.Arrival = Request["atime"];
            rts.Departure = Request["dtime"];
            rts.Price = Convert.ToInt32(Request["tprice"]);
            rts.Classes = Request["tclass"];
            rts.Seats = Convert.ToInt32(Request["tseat"]);


            dc.SubmitChanges();
            return RedirectToAction("ViewSchedule");
        }

        public ActionResult ViewSchedule(string tclass)
        {
            return PartialView(dc.RailwayDatas.ToList());
        }
      
    }
}