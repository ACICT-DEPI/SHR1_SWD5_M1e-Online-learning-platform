using System.ComponentModel.DataAnnotations.Schema;

namespace Elearn.DAL.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime Enrollmentdate { get; set; } = DateTime.Now;
    }
}
