using Microsoft.AspNetCore.Identity;

namespace Elearn.DAL.Models
{
    public class Student : IdentityUser
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
