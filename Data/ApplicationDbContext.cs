using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : DbContext
    {
      
        public virtual DbSet<Signup> Signup{ get; set; }
         public virtual DbSet<Post> Post{ get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        

        


    }

    

}