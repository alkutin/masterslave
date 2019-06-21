using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterSlaveSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Slave()
        {   
            ViewBag.Title = "Slave";
            var slaveCode = Request.Cookies["SlaveCode"]?.Value;
            if (slaveCode == null)
            {
                slaveCode = Guid.NewGuid().ToString("N");
                Response.Cookies.Add(new HttpCookie("SlaveCode", slaveCode));
            }

            ViewBag.SlaveCode = slaveCode;

            return View();
        }

        public ActionResult Master(string url, string slave)
        {
            ViewBag.Title = "Master";

            ViewBag.Url = url;
            ViewBag.Slave = slave;

            return View();
        }
    }
}
