using JobCards.Security;
using System.Web.Mvc;
using JobCards.Models.EntityManager;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace JobCards.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Welcome()
        {
            var manager = new JobCardManager();
            var userID = User.Identity.GetUserId<int>();
            var view = manager.GetLastJobCards(5, manager.GetUserID(User.Identity.Name), true);
            return View(view);
        }

        public ActionResult UnAuthorized()
        {
            return View();
        }
    }
}