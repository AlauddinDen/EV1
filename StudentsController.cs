using EV3.Models;
using EV3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EV3.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Core1234Context _db;
        private readonly IWebHostEnvironment _env;

        public StudentsController(Core1234Context db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Index()
        {
            var students = _db.Students.Include(s => s.Course).Include(s => s.CourseModules).ToList();
            return View(students);
        }
        public IActionResult Delete(int? id)
        {
            var student = _db.Students.Find(id);

            _db.Students.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            StudentViewModel student = new StudentViewModel();
            student.Courses = _db.Courses.ToList();
            return View(student);
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            Student obj = new Student();
            string imgFile = null;
            if (student.ProfileFile != null)
            {
                imgFile = Guid.NewGuid().ToString() + Path.GetExtension(student.ProfileFile.FileName);
                var filePath = Path.Combine(_env.WebRootPath, "Images");
                var file = Path.Combine(filePath, imgFile);
                using (var fileStram = new FileStream(file, FileMode.Create))
                {
                    student.ProfileFile.CopyTo(fileStram);
                }
            }

            obj.Imgurl = imgFile;
            obj.StudentN = student.StudentN;
            obj.CourseId = student.CourseId;
            obj.Dob = student.Dob;
            obj.MobileNo = student.MobileNo;
            obj.IsEnrolled = student.IsEnrolled;
            obj.CourseModules = student.CourseModules.ToList();
            _db.Students.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }


        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var obj = _db.Students.Include(s => s.Course).Include(s => s.CourseModules).FirstOrDefault(s => s.StudentId == id);
        //    StudentViewModel student = new StudentViewModel();
        //    student.StudentId = obj.StudentId;
        //    student.StudentN = obj.StudentN;
        //    student.IsEnrolled = obj.IsEnrolled;
        //    student.CourseId = obj.CourseId;
        //    student.Dob = obj.Dob;
        //    student.MobileNo = obj.MobileNo;
        //    student.CourseModules = obj.CourseModules.ToList();
        //    student.Courses = _db.Courses.ToList();
        //    student.CourseN = obj.Course.CourseN;
        //    student.Imgurl = obj.Imgurl;
        //    return View(student);
        //}

        //[HttpPost]
        //public IActionResult Edit(StudentViewModel student, string OldImgurl)
        //{

        //    var obj = _db.Students.Include(c => c.Course).Include(m => m.CourseModules).FirstOrDefault(s => s.StudentId == student.StudentId); ;


        //    string imgFile = null;
        //    if (student.ProfileFile != null)
        //    {
        //        imgFile = Guid.NewGuid().ToString() + Path.GetExtension(student.ProfileFile.FileName);
        //        var filePath = Path.Combine(_env.WebRootPath, "Images");
        //        var file = Path.Combine(filePath, imgFile);
        //        using (var fileStram = new FileStream(file, FileMode.Create))
        //        {
        //            student.ProfileFile.CopyTo(fileStram);
        //        }
        //        student.Imgurl = imgFile;

        //    }
        //    else
        //    {
        //        student.Imgurl = OldImgurl;
        //    }
        //    obj.Imgurl = student.Imgurl;
        //    obj.StudentN = student.StudentN;
        //    obj.CourseId = student.CourseId;
        //    obj.Dob = student.Dob;
        //    obj.MobileNo = student.MobileNo;
        //    obj.IsEnrolled = student.IsEnrolled;

        //    var existingModules = obj.CourseModules.ToList();
        //    foreach (var exModule in existingModules)
        //    {
        //        _db.CourseModules.Remove(exModule);
        //    }
        //    foreach (var item in student.CourseModules)
        //    {
        //        _db.CourseModules.Add(new CourseModule
        //        {
        //            ModuleN = item.ModuleN,
        //            Duration = item.Duration,
        //            StudentId = obj.StudentId

        //        });
        //    }
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
