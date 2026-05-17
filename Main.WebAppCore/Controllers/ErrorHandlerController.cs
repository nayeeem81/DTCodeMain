using Microsoft.AspNetCore.Mvc;

namespace FineArtsWebApp
{
    public class ErrorHandlerController : BaseController
    {
        public ErrorHandlerController()
        { }

        public ActionResult Index()
        {
            return View();
        }
    }
}
