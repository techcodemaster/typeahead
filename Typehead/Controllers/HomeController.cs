using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Typehead.Models;
using System.Xml.Linq;
using System.Xml;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;

namespace Typehead.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
       
    }
}
