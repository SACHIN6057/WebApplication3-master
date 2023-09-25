
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace WebApplication3.Models
{
    public class Signup
    {

         [Required]
        public string First_Name{ get; set; }

        
        public string Last_Name{ get; set; }

        [Key]       
        public string UserName{ get; set; }

         [Required]       
        public string EmailId{ get; set; }

         [Required]
        public string Password{ get; set; }

        [Required]
        public string Confirm_Password{ get; set; }


      
       // public DateTime CreatedDateTime { get; set; }

        

    }
}