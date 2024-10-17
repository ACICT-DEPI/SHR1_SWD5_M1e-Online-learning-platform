using System.ComponentModel.DataAnnotations;

namespace Elearn.DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }


    }
}
