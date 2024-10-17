using Elearn.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Elearn.DAL.Context
{
    public class ElearnContext : IdentityDbContext<Student>
    {
        public ElearnContext(DbContextOptions<ElearnContext> options)
             : base(options)
        {

        }
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }



    }
}
