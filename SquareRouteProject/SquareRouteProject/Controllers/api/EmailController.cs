using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SquareRouteProject.Domain.Entities;
using System.Net.Mail;
using System.Configuration;

namespace SquareRouteProject.Presentation.Controllers.api
{
    [RoutePrefix("api/Email")]
    public class EmailController : ApiController
    {
        [Route("SendEmail")]
        public IHttpActionResult SendEmail(Email email)
        {
            if(ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email.To);
                mail.From = new MailAddress("SquareRouteAlert@gmail.com");
                mail.Subject = email.Subject;
                string Body = email.Body;
                email.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["mailAccount"],
                    ConfigurationManager.AppSettings["mailPassword"]
                );
                //smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            return Ok();
        }
    }
}
