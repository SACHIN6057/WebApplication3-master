using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
         
          public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

              [ActivatorUtilitiesConstructor]
    public HomeController(IHttpContextAccessor httpContextAccessor, ILogger<HomeController> logger)
        : this(httpContextAccessor)
    {
        _logger = logger;
    }

        public IActionResult Index()
        {
         
        if(_httpContextAccessor?.HttpContext?.Request.Cookies["UserName"]!= null)
         {
         return   RedirectToAction(actionName:"Index",controllerName:"Post");
          }
        

            return View();
        }

        public IActionResult Contacts()
        {
            if(_httpContextAccessor?.HttpContext?.Request.Cookies["UserName"]== null)
            {
                return   RedirectToAction(actionName:"Index",controllerName:"Home");
            }
            return View();
        }

        public IActionResult About() 
        {
            if(_httpContextAccessor?.HttpContext?.Request.Cookies["UserName"]== null)
            {
                return   RedirectToAction(actionName:"Index",controllerName:"Home");
            }
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}