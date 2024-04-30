using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class AdminMailController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new();


            MailboxAddress mailboxAddressFrom = new("HotelierAdmin","arda.1235850@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);


            MailboxAddress mailboxAdressTo = new("User",model.ReceiverMail);
            mimeMessage.To.Add(mailboxAdressTo);


            var bodybuilder =new BodyBuilder();
            bodybuilder.TextBody = model.Body;
            mimeMessage.Body =bodybuilder.ToMessageBody();


            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();//Mailkit.Net.Smtp
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("arda.1235850@gmail.com", "ypdygamnuzkqozbx");
            client.Send(mimeMessage);
            client.Disconnect(true);



            return View();
        }
    }
}
