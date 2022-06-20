using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace lab14.Controllers
{
    public class CategoriesController : Controller
    {
        private Northwind _entities;
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
    }
}