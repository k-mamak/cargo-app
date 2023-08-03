using System.Linq;
using System.Web.Mvc;
using CargoApp.DAL;
using CargoApp.Models;

namespace CargoApp.Controllers
{
    public class UserController : Controller
    {
        private CargoContext db = new CargoContext();

        [HttpGet]
        public ActionResult Login()
        {
            bool isLoggedIn = (Session["IsLoggedIn"] != null && (bool)Session["IsLoggedIn"]);
            if (isLoggedIn)
            {
                return RedirectToAction("Index", "Cargo");  
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            // Check the credentials in the database
            bool isValidCredentials = db.Users.Any(u => u.UserName == model.UserName && u.Password == model.Password);

            if (isValidCredentials)
            {
                // If the credentials are valid, set the session variable and redirect to the cargo index page
                Session["IsLoggedIn"] = true;
                return RedirectToAction("Index", "Cargo");
            }

            // Invalid credentials, show an error message
            ModelState.AddModelError("", "Invalid username or password.");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            // Clear the session variable to indicate the user is logged out
            Session["IsLoggedIn"] = null;
            return RedirectToAction("Login");
        }
    }
}