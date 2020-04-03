using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using System;
using Entity.AnonymousMsgProject;
using System.Web;

namespace Web.AnonymousMsgProject.Controllers
{
    public class AuthController : Controller
    {
        private DataContext db = new DataContext();
        private int UserId;
        private string UserEmail ;
        private string UserName ;
        private string UserRole;
        // GET: Auth
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UserProfile", "Home");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string loginemail, string loginpass)
        {
            try
            {
                UserModel user = new UserModel();
                if ((loginemail == null && loginpass == null) || (loginemail == null || loginpass == null))
                {
                    ModelState.AddModelError("", "invalid Username or Password");
                    return View();

                }
                else
                {

                    user.User_Email = loginemail.ToLower();
                    user.User_Password = loginpass;
                }

                bool IsValid = db.Users.Any(x => x.User_Email == user.User_Email && x.User_Password == user.User_Password);

                if (IsValid)
                {
                    var result = from UserModel in db.Users
                                 join RoleModel in db.Roles on UserModel.User_Role equals RoleModel.Role_Id
                                 where UserModel.User_Email == loginemail && UserModel.User_Password == loginpass
                                 select new
                                 {
                                     UserId = UserModel.User_Id,
                                     UserEmail = UserModel.User_Email,
                                     UserName = UserModel.User_Name,
                                     UserRole = RoleModel.Role_Name
                                 };
                    //FormsAuthentication.SetAuthCookie(user.User_Email, false);
                    foreach (var r in result)
                    {
                        UserId = r.UserId;
                        UserEmail = r.UserEmail;
                        UserName = r.UserName;
                        UserRole = r.UserRole;

                    }
                    //return RedirectToAction("UserProfile", "Home");
                    //int UserId = user.User_Id;
                    FormsAuthenticationTicket Authticket = new FormsAuthenticationTicket(
                                                               1,
                                                               UserId.ToString() + ",",
                                                               DateTime.Now,
                                                               DateTime.Now.AddMinutes(60),
                                                               false,
                                                               UserId.ToString());
                    string hash = FormsAuthentication.Encrypt(Authticket);
                    HttpCookie Authcookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    if (Authticket.IsPersistent)
                        Authcookie.Expires = Authticket.Expiration;
                    Response.Cookies.Add(Authcookie);
                    Session["UserId"] = UserId;
                    Session["UserEmail"] = UserEmail;
                    Session["UserName"] = UserName;
                    Session["UserRole"] = UserRole;
                    //TempData["SenderEmail"] = UserEmail;
                    return RedirectToAction("UserProfile", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email or Password");
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                ViewBag.err = e;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(string signupname, string signupemail, string signuppass, string signupconpass)
        {
            try
            {
                if (signupemail != null && signupname != null && signuppass != null && signupconpass != null)
                {
                    if (signuppass == signupconpass)
                    {
                        UserModel user = new UserModel();
                        user.User_Name = signupname;
                        user.User_Email = signupemail;
                        user.User_Password = signuppass;
                        user.User_Role = 2;

                        bool EmailIsPresent = db.Users.Any(x => x.User_Email == user.User_Email);
                        if (!EmailIsPresent)
                        {
                            db.Users.Add(user);
                            db.SaveChanges();
                            return View("Index");
                        }
                        else
                        {
                            ViewBag.signuperr = "Email id already exists. Please Login";
                            return RedirectToAction("Login");
                        }

                    }
                    else
                    {
                        ViewBag.signuperr = "Password Mismatched";
                        return View();
                    }
                }
                else
                {
                    ViewBag.signuperr = "Fields can't be left empty";
                    return View("Index");
                }
            }
            catch
            {
                return View("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}