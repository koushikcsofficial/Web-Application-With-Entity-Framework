using Entity.Trial;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Trial.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Home
        [Authorize]
        [HttpGet]
        public ActionResult UserProfile()
        {
            string user = TempData["SenderEmail"].ToString();
            var ReceivedMessages = from MessageModel in db.Messages where MessageModel.To_User == user select MessageModel;
            var SentMessages = from MessageModel in db.Messages where MessageModel.From_User == user select MessageModel;
            dynamic messages = new ExpandoObject();
            messages.ReceivedMessages = ReceivedMessages;
            messages.SentMessages = SentMessages;
            return View(messages);
        }
        // GET: Home
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Login","Auth");
            }
            UserModel userModel = db.Users.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            else
            {
                TempData["ReceiverId"] = id;
            }
            return View(userModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string msg)
        {
            MessageModel message = new MessageModel();
            int ReceiverId = Convert.ToInt32(TempData["ReceiverId"]);
            var ReceiverDetails = db.Users.Find(ReceiverId);
            string ReceiverEmail = ReceiverDetails.User_Email;
            DateTime dt = DateTime.Now;

            message.To_User = ReceiverEmail;
            message.Message_Body = msg;
            message.Message_Time = dt;
            if (User.Identity.IsAuthenticated)
            {
                string SenderEmail = TempData["SenderEmail"].ToString();
                message.From_User = SenderEmail;
            }
            else
            {
                message.From_User = "Annonymous";
            }
            db.Messages.Add(message);
            db.SaveChanges();
            return RedirectToAction("login","Auth");
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