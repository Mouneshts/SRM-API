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
    public class SubjectController : Controller
    {
        private readonly ISubjectService _service = null;
        private readonly ICoursesService _csservice = null;
        private readonly IBranchService _bservice = null;
        private readonly ISemesterService _sservice = null;
        public SubjectController(ISubjectService subservice, ICoursesService course, IBranchService branch,ISemesterService semesterService)
        {
            _service = subservice;
            _csservice = course;
            _bservice = branch;
            _sservice = semesterService;
        }
      

        [HttpGet]
        public IActionResult AddSubject()
        {

            List<SelectListItem> courseslist = _csservice.GetCourses().Select(n => new SelectListItem { Value = n.CourseId.ToString(), Text = n.CourseName }).ToList(); ;

            var courseTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Course ---"
            };
           
            List<SelectListItem> brlist = _bservice.GetBranchs().Select(n => new SelectListItem { Value = n.BId.ToString(), Text = n.Name }).ToList(); ;

            var brTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Branch ---"
            };
            List<SelectListItem> semlist = _sservice.GetSemesters().Select(n => new SelectListItem { Value = n.SemesterId.ToString(), Text = n.semester }).ToList(); ;

            var semTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Semester ---"
            };
            courseslist.Insert(0, courseTip);
            brlist.Insert(0, brTip);
            semlist.Insert(0, semTip);
            ViewBag.courseslist = new SelectList(courseslist, "Value", "Text");
            ViewBag.brlist = new SelectList(brlist, "Value", "Text");
            ViewBag.semlist = new SelectList(semlist, "Value", "Text");

            return View();
        }
        [HttpPost]
        public IActionResult AddSubject(Subjects subject)
        {

            List<SelectListItem> courseslist = _csservice.GetCourses().Select(n => new SelectListItem { Value = n.CourseId.ToString(), Text = n.CourseName }).ToList(); ;

            var courseTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Course ---"
            };
            List<SelectListItem> semlist = _sservice.GetSemesters().Select(n => new SelectListItem { Value = n.SemesterId.ToString(), Text = n.semester }).ToList(); ;

            var semTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Semester ---"
            };
            List<SelectListItem> brlist = _bservice.GetBranchs().Select(n => new SelectListItem { Value = n.BId.ToString(), Text = n.Name }).ToList(); ;

            var brTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Branch ---"
            };
            semlist.Insert(0, semTip);
            courseslist.Insert(0, courseTip);
            brlist.Insert(0, brTip);
            ViewBag.semlist = new SelectList(semlist, "Value", "Text");
            ViewBag.courseslist = new SelectList(courseslist, "Value", "Text");
            ViewBag.brlist = new SelectList(brlist, "Value", "Text");
            _service.AddSubject(subject);
            return RedirectToAction("GetSubjects");

        }

        [HttpGet]
        public IActionResult GetSubjects()
        {

            return View(_service.GetSubjects());
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var subject = _service.GetSubject(id);
                if (subject != null)
                    return Ok(subject);
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
            Subjects subjects = _service.GetSubject(id);
            return View(subjects);
        }
        [HttpPost]
        public IActionResult Edit(Subjects subjects)
        {
            _service.UpdateSubject(subjects);

            return RedirectToAction("GetSubjects");
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            Subjects subjects = _service.GetSubject(id);

            return View(subjects);
        }

        [HttpPost]
        public IActionResult Delete(Subjects subjects)
        {
            // _service.DeleteBranch(student.);
            _service.DeleteSubject(subjects.SubjectId);
            return RedirectToAction("GetSubjects");
        }
    }
}
