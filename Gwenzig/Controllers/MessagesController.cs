
using Gwenzig.Data.DataModels;
using Gwenzig.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace Gwenzig.Controllers
{
    public class MessagesController : Controller
    {
        private Data.ApplicationDbContext _dbcontext { get; set; }
        public MessagesController(Gwenzig.Data.ApplicationDbContext _dbcontext)
        {

        }
        //// GET: Mail
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Send(Mail model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
        //        var message = new MailMessage();
        //        message.To.Add(new MailAddress("combinesoldat@gmail.com"));  // replace with valid value 
        //        message.From = new MailAddress(model.FromEmail);  // replace with valid value
        //        message.Subject = "Your email subject";
        //        message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
        //        message.IsBodyHtml = true;

        //        using (var smtp = new SmtpClient())
        //        {

        //            var credential = new NetworkCredential
        //            {
        //                UserName = "combinesoldat",  // replace with valid value
        //                Password = "sandlyckan1994"  // replace with valid value
        //            };
        //            smtp.Credentials = credential;
        //            smtp.Host = "smtp.gmail.com";
        //            smtp.Port = 465;
        //            smtp.EnableSsl = true;

        //            smtp.Send(message);
        //            smtp.Dispose();
        //            return PartialView("~/Views/Partial/Mail_Follow_Modal.cshtml");
        //        }
        //    }
        //    return PartialView("~/Views/Partial/Messages_Modal.cshtml", model);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(Messages model)
        {
            if (model.Topic != null && model.Name != null && model.Mail != null && model.Message != null && model.Topic != "" && model.Name != "" && model.Mail != "" && model.Message != "")
            {

                model.Date = System.DateTime.Now.ToString();

                if (ModelState.IsValid)
                {
                    _dbcontext.Messages.Add(model);
                    if (_dbcontext.SaveChanges() > 0)
                    {
                        return PartialView("~/Views/Messages/ThankYou_Modal.cshtml", model);
                    }
                }
            }
            return PartialView("~/Views/Messages/Messages_Modal.cshtml", model);
        }


        // GET: FeaturedItems/FeaturedItem_Modal
        public ActionResult Messages_Modal()
        {

            return PartialView("/Views/Messages/Messages_Modal.cshtml");

        }
    }
}