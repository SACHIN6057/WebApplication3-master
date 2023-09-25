using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using WebApplication3.Data;
using System.Linq;

namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {


         private ApplicationDbContext _context;

         private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginController(IHttpContextAccessor httpContextAccessor)
     {
         _httpContextAccessor = httpContextAccessor;
     }


          public LoginController(ApplicationDbContext context)
          {
            _context=context;
          }

             [ActivatorUtilitiesConstructor]
                 public LoginController(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context): this(httpContextAccessor)
                { 
                  _context = context;
                }


        public IActionResult Index()
        {
          if(_httpContextAccessor?.HttpContext?.Request.Cookies["UserName"]!= null)
            {
                return   RedirectToAction(actionName:"Index",controllerName:"Post");
            }
            return View();
        }

        const string CookieUserId = "UserId";
        const string CookieUserName = "UserName";
        
        [HttpPost]
        public IActionResult create()
        {


        if (HttpContext.Request.Method == "POST")
        {
            string Password = HttpContext.Request.Form["Password"];
            string username = HttpContext.Request.Form["UserName"];
            
             
             var user = _context.Signup.FirstOrDefault(u => u.UserName == username && u.Password == Password);

    if (user != null)
    {
         //Let us assume the User is logged in and we need to store the user information in the cookie
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(7);
                     Response.Cookies.Append(CookieUserId,"1", options);
                     Response.Cookies.Append(CookieUserName, username, options);
                    return RedirectToAction(actionName:"Index",controllerName:"Post");
    }
            
                    

           

           // You can now process the form data as needed.
            // For example, you can save it to a database or perform other actions.      
             

           
        }

       return RedirectToAction("Index");

    }


     public IActionResult DeleteCookie()
     {
          
       
            // Delete the cookie from the browser.
            Response.Cookies.Delete(CookieUserId);
            Response.Cookies.Delete(CookieUserName);
             return RedirectToAction(actionName:"Index",controllerName:"Home");
         
     }


    }
}
