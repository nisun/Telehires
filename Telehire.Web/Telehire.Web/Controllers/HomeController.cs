using System.Web.Mvc;
using Telehire.Web.Models;

namespace Telehire.Web.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            var model = new UserModel();

            return View(model);
        }

        public ActionResult ChooseRole()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult ChooseRole()
        //{
        //    if(
        //}
    }
}
