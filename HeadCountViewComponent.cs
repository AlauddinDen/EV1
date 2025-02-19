using EV3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EV3.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly Core1234Context _db;

        public HeadCountViewComponent(Core1234Context db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int courseId)
        {
            var courseCounts = await _db.Students
                   .Include(s => s.Course)
                   .GroupBy(s => new { s.Course.CourseId, s.Course.CourseN })
                   .Select(g => new CourseHeadCount
                   {
                       CourseId = g.Key.CourseId,
                       CourseN = g.Key.CourseN,
                       Count = g.Count()
                   })
                   .ToListAsync();

            return View(courseCounts);
        }
    }
}
