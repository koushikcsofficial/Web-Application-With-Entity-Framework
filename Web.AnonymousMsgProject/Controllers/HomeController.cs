﻿using Entity.AnonymousMsgProject;
using System;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;

namespace Web.AnonymousMsgProject.Controllers
{
    public class HomeController : Controller
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        private DataContext db = new DataContext();

        [Authorize]
        [HttpGet]
        public ActionResult UserProfile()
        {
            try
            {
                string user = Session["UserEmail"].ToString();
                var ReceivedMessages = from MessageModel in db.Messages where MessageModel.To_User == user orderby MessageModel.Message_Time descending select MessageModel;
                var SentMessages = from MessageModel in db.Messages where MessageModel.From_User == user orderby MessageModel.Message_Time descending select MessageModel;
                dynamic messages = new ExpandoObject();
                messages.ReceivedMessages = ReceivedMessages;
                messages.SentMessages = SentMessages;
                return View(messages);
            }
            catch (NullReferenceException )
            {
                return RedirectToAction("Logout", "Auth");
            }
            catch (ArgumentException )
            {
                return RedirectToAction("Logout", "Auth");
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            try
            {
                UserModel userModel = db.Users.Find(id);
                if (userModel == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    TempData["ReceiverId"] = id;
                    return View(userModel);
                }
            }catch(Exception )
            {
                return HttpNotFound();
            }
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
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            message.To_User = ReceiverEmail;
            message.Message_Body = msg;
            message.Message_Time = indianTime;
            if (User.Identity.IsAuthenticated)
            {
                string SenderEmail = TempData["SenderEmail"].ToString();
                message.From_User = SenderEmail;
            }
            else
            {
                message.From_User = "Anonymous";
            }
            db.Messages.Add(message);
            db.SaveChanges();
            return RedirectToAction("login", "Auth");
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