using System.Web.Mvc;

namespace CargoApp
{
    /// <summary>
    /// An authentication filter that checks if the user is logged in before executing an action.
    /// </summary>
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isLoggedIn = (filterContext.HttpContext.Session["IsLoggedIn"] != null && (bool)filterContext.HttpContext.Session["IsLoggedIn"]);

            // Redirect to the login page if the user is not logged in
            if (!isLoggedIn)
            {
                filterContext.Result = new RedirectResult("~/User/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
