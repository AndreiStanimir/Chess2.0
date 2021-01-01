using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chess20.Controllers
{
    public class PuzzlesController : Controller
    {
        // GET: Puzzles
        public ActionResult Index()
        {
            return View();
        }
    }
}