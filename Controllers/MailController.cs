using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.CodeAnalysis.CSharp.Syntax;




using System.Net;  
using System.Net.Mail; 


namespace WebApplication3.Controllers
{
    
    public class MailController : Controller
    {
        // private readonly IMailService _mail;

        // public MailController(IMailService mail)
        // {
        //     _mail = mail;
        // }


         public IActionResult Index()
         {
          string param1 = TempData["EmailId"] as string;    
        string smtpAddress = "smtp.gmail.com";  
         int portNumber = 587;  
         bool enableSSL = true;  
         string emailFromAddress = "ubuntusachin89@gmail.com"; //Sender Email Address  
         string password = "ivccmwueugqzcbfu"; //Sender Password  
         string emailToAddress = param1; //Receiver Email Address  
         string subject = "Hello";  
         string body = "Hello, This is Email sending test using gmail.";  
          
            SendEmail();  
         
                  void SendEmail() {  
            using(MailMessage mail = new MailMessage()) {  
                mail.From = new MailAddress(emailFromAddress);  
                mail.To.Add(emailToAddress);  
                mail.Subject = subject;  
                mail.Body = body;  
                mail.IsBodyHtml = true;  
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using(SmtpClient smtp = new SmtpClient(smtpAddress, portNumber)) {  
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);  
                    smtp.EnableSsl = enableSSL;  
                    smtp.Send(mail);  
                }  
            }  
        } 
            
          return RedirectToAction(actionName:"Index",controllerName:"Home");      
       }
              
        
    }  
} 

        // [HttpGet]
        // public async Task<IActionResult> mail(MailData mailData)
        // {

         

        //    bool result = await _mail.SendAsync(mailData, new CancellationToken());
        //     return RedirectToAction(actionName:"Index",controllerName:"Home");

        //     if (result)
        //     {
        //         return StatusCode(StatusCodes.Status200OK, "Mail has successfully been sent.");
        //          //return RedirectToAction(actionName:"Index",controllerName:"Mail");
        //     } 
        //     else
        //     {
        //          return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. The Mail could not be sent.");
        //        //   return RedirectToAction(actionName:"Index",controllerName:"Home");
        //     }
        
    
       
    
