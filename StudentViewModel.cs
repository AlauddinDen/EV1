using EV3.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EV3.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Student name is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Name can't be more than 20 characters")]
        [Display(Name = "Student Name")]
        public string StudentN { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Dob { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Mobile No is required")]
        [StringLength(11, ErrorMessage = "Mobile No can't be more than 11 characters")]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Enrollement Status is required")]
        [Display(Name = "Enrolled?")]
        public bool IsEnrolled { get; set; }
        public string Imgurl { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int CourseModuleId { get; set; }
        public string ModuleN { get; set; }
        public int Duration { get; set; }
        [Display(Name = "Course")]

        public string CourseN { get; set; }
        
        public IFormFile ProfileFile { get; set; }

        public virtual List<Course> Courses { get; set; }

        public virtual IList<CourseModule> CourseModules { get; set; } = new List<CourseModule>();

        public virtual IList<Student> Students { get; set; }
    }
}
