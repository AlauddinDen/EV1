using System;
using System.Collections.Generic;

namespace EV3.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseN { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
