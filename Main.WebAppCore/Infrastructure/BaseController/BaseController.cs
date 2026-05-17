using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace FineArtsWebApp
{
    public partial class BaseController : Controller
    {
        public IEmailNotificationService _EmailService;
        public readonly KeyValuePair<int, EnumPublicPage> CurrentPage;
        private readonly ICompositeViewEngine _viewEngine;
        public BaseController()
        {
            if (StaticAppSettings.TIME_SLOT_SELECT_STYLE == 1)
            {
                StaticAppSettings.CURRENT_TIME_SLOT = GetCurrentTimeBasedTimeSlot();
            }
            else if (StaticAppSettings.TIME_SLOT_SELECT_STYLE == 2)
            {
                StaticAppSettings.CURRENT_TIME_SLOT = GetRandomNumberBasedTimeSlot();
            }
        }

        public DateTime GetBangladeshCurrentDateTime()
        {
            var BnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
            DateTime BaTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, BnTimeZone);
            return BaTime;
        }

        public int GetRandomNumberBasedTimeSlot()
        {
            Random random = new Random();
            return random.Next(1, 4);
        }

        public int GetCurrentTimeBasedTimeSlot()
        {
            var currentTime = GetBangladeshCurrentDateTime();
            DateTime now = GetBangladeshCurrentDateTime();
            DateTime baseDate = GetBangladeshCurrentDateTime();

            TimeSpan ts = new TimeSpan(00, 00, 0);
            var slot4 = baseDate.Date + ts;
            ts = new TimeSpan(00, 59, 0);
            var slot5 = baseDate.Date + ts;
            if (now >= slot4 && now <= slot5)
                return 1;

            ts = new TimeSpan(01, 00, 0);
            var slot6 = baseDate.Date + ts;
            ts = new TimeSpan(01, 59, 0);
            var slot7 = baseDate.Date + ts;
            if (now >= slot6 && now <= slot7)
                return 2;

            ts = new TimeSpan(02, 00, 0);
            var slot8 = baseDate.Date + ts;
            ts = new TimeSpan(02, 59, 0);
            var slot9 = baseDate.Date + ts;
            if (now >= slot8 && now <= slot9)
                return 3;

            ts = new TimeSpan(03, 00, 0);
            var slot10 = baseDate.Date + ts;
            ts = new TimeSpan(03, 59, 0);
            var slot11 = baseDate.Date + ts;
            if (now >= slot10 && now <= slot11)
                return 4;

            ts = new TimeSpan(04, 00, 0);
            var slot12 = baseDate.Date + ts;
            ts = new TimeSpan(04, 59, 0);
            var slot13 = baseDate.Date + ts;
            if (now >= slot12 && now <= slot13)
                return 5;

            ts = new TimeSpan(05, 00, 0);
            var slot14 = baseDate.Date + ts;
            ts = new TimeSpan(05, 59, 0);
            var slot15 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 6;

            ts = new TimeSpan(06, 00, 0);
            var slot16 = baseDate.Date + ts;
            ts = new TimeSpan(06, 59, 0);
            var slot17 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 1;

            ts = new TimeSpan(07, 00, 0);
            var slot18 = baseDate.Date + ts;
            ts = new TimeSpan(07, 59, 0);
            var slot19 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 2;

            ts = new TimeSpan(08, 00, 0);
            var slot20 = baseDate.Date + ts;
            ts = new TimeSpan(08, 59, 0);
            var slot21 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 3;

            ts = new TimeSpan(09, 00, 0);
            var slot22 = baseDate.Date + ts;
            ts = new TimeSpan(09, 59, 0);
            var slot23 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 4;

            ts = new TimeSpan(10, 00, 0);
            var slot24 = baseDate.Date + ts;
            ts = new TimeSpan(10, 59, 0);
            var slot25 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 5;

            ts = new TimeSpan(11, 00, 0);
            var slot26 = baseDate.Date + ts;
            ts = new TimeSpan(11, 59, 0);
            var slot27 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 6;

            ts = new TimeSpan(12, 00, 0);
            var slot28 = baseDate.Date + ts;
            ts = new TimeSpan(12, 59, 0);
            var slot29 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 1;

            ts = new TimeSpan(13, 00, 0);
            var slot30 = baseDate.Date + ts;
            ts = new TimeSpan(13, 59, 0);
            var slot31 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 2;

            ts = new TimeSpan(14, 00, 0);
            var slot32 = baseDate.Date + ts;
            ts = new TimeSpan(14, 59, 0);
            var slot33 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 3;

            ts = new TimeSpan(15, 00, 0);
            var slot34 = baseDate.Date + ts;
            ts = new TimeSpan(15, 59, 0);
            var slot35 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 4;

            ts = new TimeSpan(16, 00, 0);
            var slot36 = baseDate.Date + ts;
            ts = new TimeSpan(16, 59, 0);
            var slot37 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 5;

            ts = new TimeSpan(17, 00, 0);
            var slot38 = baseDate.Date + ts;
            ts = new TimeSpan(17, 59, 0);
            var slot39 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 6;

            ts = new TimeSpan(18, 00, 0);
            var slot40 = baseDate.Date + ts;
            ts = new TimeSpan(18, 59, 0);
            var slot41 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 1;

            ts = new TimeSpan(19, 00, 0);
            var slot42 = baseDate.Date + ts;
            ts = new TimeSpan(19, 59, 0);
            var slot43 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 2;

            ts = new TimeSpan(20, 00, 0);
            var slot44 = baseDate.Date + ts;
            ts = new TimeSpan(20, 59, 0);
            var slot45 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 3;

            ts = new TimeSpan(21, 00, 0);
            var slot46 = baseDate.Date + ts;
            ts = new TimeSpan(21, 59, 0);
            var slot47 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 4;

            ts = new TimeSpan(22, 00, 0);
            var slot48 = baseDate.Date + ts;
            ts = new TimeSpan(22, 59, 0);
            var slot49 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 5;

            ts = new TimeSpan(23, 00, 0);
            var slot50 = baseDate.Date + ts;
            ts = new TimeSpan(23, 59, 0);
            var slot51 = baseDate.Date + ts;
            if (now >= slot14 && now <= slot15)
                return 6;

            return 1;
        }

        public ActionResult UnwantedAccessError()
        {
            //ClearSessionUser(); 
            return View("UnwantedAccessError");
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    filterContext.ExceptionHandled = true;

        //    ILogServerErrorRepository _Logger = new LogServerErrorRepository();
        //    _Logger.AddServerErrorLog(filterContext.Exception);

        //    filterContext.Result = RedirectToAction("Index", "ErrorHandler");
        //    filterContext.Result = new ViewResult
        //    {
        //        ViewName = "~/Views/ErrorHandler/Index.cshtml"
        //    };
        //}

        public ActionResult CheckLogoutRequirements()
        {
            return RedirectToAction("Index", "Home");
        }

        //public void LogoutAndClear()
        //{
        //    FormsAuthentication.SignOut();
        //    ClearAdminSessionUser();
        //    ClearSessionUser();
        //    ClearTempSessionUserId();

        //    HttpCookie currentUserCookie = HttpContext.Request.Cookies["ClientName"];
        //    HttpContext.Response.Cookies.Remove("ClientName");
        //    currentUserCookie.Expires = DateTime.Now.AddDays(-10);
        //    currentUserCookie.Value = null;
        //    HttpContext.Response.SetCookie(currentUserCookie);

        //    HttpCookie loginUserIDCookie = HttpContext.Request.Cookies["LoginUserID"];
        //    HttpContext.Response.Cookies.Remove("LoginUserID");
        //    loginUserIDCookie.Expires = DateTime.Now.AddDays(-10);
        //    loginUserIDCookie.Value = null;
        //    HttpContext.Response.SetCookie(loginUserIDCookie);
        //}

        public async Task<string> FindMyView(Controller controller, string partialViewName, EmailViewModel model)
        {
            var resultString = await ControllerExtensions.RenderViewToStringAsync(controller, @"../../Views/Shared/EmailTemplates/" + partialViewName, model);
            return resultString;
        }
    }
}