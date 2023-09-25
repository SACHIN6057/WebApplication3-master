using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class SignupController: Controller
    {
        
      private ApplicationDbContext _context;

      private readonly IHttpContextAccessor _httpContextAccessor;

    public SignupController(IHttpContextAccessor httpContextAccessor)
     {
         _httpContextAccessor = httpContextAccessor;
     }


      public SignupController(ApplicationDbContext context)
      {
            _context=context;
      }

              
          [ActivatorUtilitiesConstructor]
        public SignupController(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
            : this(httpContextAccessor)
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

      //  [HttpGet]
      //  public IActionResult create()
      //  {
      //   return View();
      //  }



      [HttpGet]
     public IActionResult checkUserName(string username)
     {

     var user = _context.Signup.FirstOrDefault(u => u.UserName == username );        
     
     if(user!=null)
     {
        return Content("false");
     }
        
        return Content("true");

     }




     [HttpPost]
     public async Task<IActionResult>create(Signup signup)
     { 

      if(ModelState.IsValid)
      {
        try{
            
                                        

                    _context.Add(signup);
                   await _context.SaveChangesAsync();
                 
                  


                     TempData["EmailId"] = signup.EmailId;
    
                   


                  return RedirectToAction(actionName:"Index",controllerName:"Mail");
        } 
          catch(Exception ex){
              ModelState.AddModelError(string.Empty,$"something went wrong{ex.Message}");
          }

      }
        ModelState.AddModelError(string.Empty,$"something went wrong");
      return RedirectToAction("Index");

     }

    }
}