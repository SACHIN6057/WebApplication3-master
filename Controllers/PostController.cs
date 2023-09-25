using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;



namespace WebApplication3.Controllers
{
    public class PostController: Controller
    {
        
      private readonly ApplicationDbContext _context;
      private readonly IHttpContextAccessor _httpContextAccessor;

    public PostController(IHttpContextAccessor httpContextAccessor)
     {
         _httpContextAccessor = httpContextAccessor;
     }
     
      public PostController(ApplicationDbContext context)
      {
            _context=context;
      }

          
        [ActivatorUtilitiesConstructor]
    public PostController(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        : this(httpContextAccessor)
    {
        _context = context;
    }


         
        public async Task<IActionResult> Index()
    {

       
  if(_httpContextAccessor?.HttpContext?.Request.Cookies["UserName"]== null)
    {
         return   RedirectToAction(actionName:"Index",controllerName:"Home");
   }

        var post = await _context.Post.ToListAsync();   
        return View(post);
    }
            
      
    
      [HttpGet]
      public IActionResult create()
        {
          if(_httpContextAccessor?.HttpContext?.Request.Cookies["UserName"]== null)
         {
         return   RedirectToAction(actionName:"Index",controllerName:"Home");
          }
         return View();
       }
     

     
     [HttpPost]
     public async Task<IActionResult>create(Post post)
     { 

      if(ModelState.IsValid)
      {
      
        try{
             
                

                    _context.Add(post);
                   await _context.SaveChangesAsync();
                  return RedirectToAction(actionName:"Index",controllerName:"Post");
        } 
          catch(Exception ex){
              ModelState.AddModelError(string.Empty,$"something went wrong{ex.Message}");
          }

      }
     ModelState.AddModelError(string.Empty,$"something went wrong");
      return View();

     }

    
    public IActionResult Delete(int id)
    {
         var post = _context.Post.Find(id);

    if (post == null)
    {
        return RedirectToAction("Index"); // Handle the case where the post doesn't exist
    }

    // Delete the post
    _context.Post.Remove(post);
    _context.SaveChanges();
        
      return RedirectToAction("Index");
    }



    }
}