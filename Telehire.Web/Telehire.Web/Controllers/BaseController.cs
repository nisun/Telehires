using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Configuration;
using Telehire.Web.Infrastructure;

namespace Telehire.Web.Controllers
{
    public class BaseController : Controller
    {
        public string DateFormat
        {
            get
            {
                return "dd/MM/yyyy";
            }
        }

        public int GridSize
        {
            get
            {
                return 10;
            }
        }


        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            var typeofException = filterContext.Exception.GetType();
            if (typeofException == typeof(ArgumentNullException))
            {
                FormsAuthentication.SignOut();
            }
            else
                RedirectToAction("Error", "Error");

        }


        protected ActionResult AccessDeniedView()
        {
            return RedirectToAction("Denied", "Access", new { pageUrl = this.Request.RawUrl });
        }

        public static bool IsValidEmail(string email)
        {
            bool result = false;
            if (String.IsNullOrEmpty(email))
                return result;
            email = email.Trim();
            result = Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return result;
        }

        protected virtual void ErrorNotification(Exception exception, bool persistForTheNextRequest = true, bool logException = true)
        {
            AddNotification(Status.Fail, exception.Message, persistForTheNextRequest);
        }

        protected virtual void AddNotification(Status type, string message, bool persistForTheNextRequest)
        {
            string dataKey = string.Format("Telehire.Status.{0}", type);
            if (persistForTheNextRequest)
            {
                if (TempData[dataKey] == null)
                    TempData[dataKey] = new List<string>();
                ((List<string>)TempData[dataKey]).Add(message);
            }
            else
            {
                if (ViewData[dataKey] == null)
                    ViewData[dataKey] = new List<string>();
                ((List<string>)ViewData[dataKey]).Add(message);
            }
        }

        protected virtual void SuccessNotification(string message, bool persistForTheNextRequest = true)
        {
            ShowJavascriptMessage(message);
            AddNotification(Status.Success, message, persistForTheNextRequest);

        }

        public DateTime GoLiveDate
        {

            get
            {
                var _goLiveDate = ConfigurationManager.AppSettings["GoLiveDate"];
                _goLiveDate = string.IsNullOrEmpty(_goLiveDate) ? "01/01/2010" : ConfigurationManager.AppSettings["GoLiveDate"];
                return DateTime.ParseExact(_goLiveDate, DateFormat, null);
            }
        }


        protected virtual void ShowJavascriptMessage(string message)
        {
            var _text = "<script type='text/javascript'>" + "alert('" + message + "');" + "</script>";
            string _Key = "Telehire.JavaScript";
            TempData[_Key] = _text;
            ViewData[_Key] = _text;
        }

        protected virtual void ConfirmJavascriptMessage(string message)
        {
            var _text = "<script type='text/javascript'>" + "return window.confirm('" + message + "');" + "</script>";
            string _Key = "Telehire.JavaScript";
            TempData[_Key] = _text;
            ViewData[_Key] = _text;
        }

    }
}
