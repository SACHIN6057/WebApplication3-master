
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace WebApplication3.Models
{
    public class Post   
    {


        [Key]
        public int Id{ get; set; }        
   
         [Required]
        public string Content{ get; set; }      

        [Required]
        public string UserName{ get; set; }

       // public DateTime CreatedDateTime { get; set; }       
    }
}