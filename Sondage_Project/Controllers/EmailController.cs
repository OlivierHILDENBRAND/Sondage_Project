using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sondage_Project.Data.Models;
using Sondage_Project.Models;
using System.Net.Mail;

namespace Sondage_Project.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        // GET: SendMailer : return the Index View of the Email
        public ActionResult Index()
        {
            return View();
        }

        // We create a smtp client using gmail and the port num 25 to send the MailMessagge named mail
        [HttpPost]
        public ViewResult Index(MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("sondage.projet.cci@gmail.com", "sondage.projet.cci*68"); // Enter seders User name and password       
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index", _objModelMail);
            }
            else
            {
                return View();
            }
        }
    }
}
