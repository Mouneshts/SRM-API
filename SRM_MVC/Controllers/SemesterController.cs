using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRM_MVC.Services;
using SRM_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SRM_MVC.Controllers
{
    public class SemesterController : Controller
    {
        private readonly ISemesterService _service;
        private readonly ICoursesService _cservice;
        public SemesterController(ISemesterService service,ICoursesService cservice)
        {

            _service = service;
            _cservice = cservice;
        }
        [HttpGet]
        public IActionResult AddSemester()
        {

            List<SelectListItem> courseslist = _cservice.GetCourses().Select(n => new SelectListItem { Value = n.CourseId.ToString(), Text = n.CourseName }).ToList(); ;

            var courseTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Course ---"
            };
            courseslist.Insert(0, courseTip);
            ViewBag.courseslist = new SelectList(courseslist, "Value", "Text");
            return View();
        }
        [HttpPost]
        public IActionResult AddSemester(Semester semesters)
        {

            List<SelectListItem> courseslist = _cservice.GetCourses().Select(n => new SelectListItem { Value = n.CourseId.ToString(), Text = n.CourseName }).ToList(); ;

            var courseTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Course ---"
            };
            _service.AddSemester(semesters);
            return RedirectToAction("GetSemesters");

        }
        [HttpGet]
        public IActionResult GetSemesters()
        {

            return View(_service.GetSemesters());
        }
        [HttpGet]

        public IActionResult Get(int id)
        {
            try
            {
                var courses = _service.GetSemester(id);
                if (courses != null)
                    return Ok(courses);
                else
                    return Content("Invalid Id");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Semester sem = _service.GetSemester(id);
            return View(sem);
        }
        [HttpPost]

        public IActionResult Edit(Semester semesters)
        {
            _service.UpdateSemester(semesters);

            return RedirectToAction("GetSemesters");
        }
        [HttpGet]

        public IActionResult Delete(int id)
        {
            Semester sem = _service.GetSemester(id);

            return View(sem);
        }

        [HttpPost]
        public IActionResult Delete(Semester semesters)
        {
            _service.DeleteSemester(semesters.SemesterId);

            return RedirectToAction("GetSemesters");
        }


    }
}
