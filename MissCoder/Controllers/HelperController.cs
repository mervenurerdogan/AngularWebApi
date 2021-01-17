using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissCoder.Models;

namespace MissCoder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {

        [HttpPost]

        public IActionResult SendContactEmail(Contact contact)

        {

            //  System.Threading.Thread.Sleep(5000);

            try

            {

                MailMessage mailMessage = new MailMessage();



                SmtpClient smtpClient = new SmtpClient();



                mailMessage.From = new MailAddress("misscoder3@gmail.com");

                mailMessage.To.Add("merveeenur2@gmail.com"); // kime gidicek email burada belirtiyoruz



                mailMessage.Subject = contact.Subject;

                mailMessage.Body = contact.Message;

                mailMessage.IsBodyHtml = true;

                smtpClient.Host = "smtp.gmail.com";

                smtpClient.Port = 587;

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.UseDefaultCredentials = false;

                smtpClient.Credentials = new System.Net.NetworkCredential("misscoder3@gmail.com", "Misscoder.24710");

                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

                return Ok();

            }

            catch (Exception ex)

            {

                return BadRequest(ex.Message);

            }

        }
    }
}
