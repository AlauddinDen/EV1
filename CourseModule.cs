using System;
using System.Collections.Generic;

namespace EV3.Models;

public partial class CourseModule
{
    public int CourseModuleId { get; set; }

    public string ModuleN { get; set; } = null!;

    public int Duration { get; set; }

    public int StudentId { get; set; }

    public virtual Student Student { get; set; } = null!;
}
