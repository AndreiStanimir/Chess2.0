using System.Web.Mvc;

namespace Chess20.Controllers
{
    public class PlayChessController : Controller
    {
        // GET: PlayChess
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}