using System;
using System.Collections.Generic;

namespace EV3.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentN { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string MobileNo { get; set; } = null!;

    public bool IsEnrolled { get; set; }

    public string? Imgurl { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<CourseModule> CourseModules { get; set; } = new List<CourseModule>();
}
