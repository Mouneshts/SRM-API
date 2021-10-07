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
    public class ResultController : Controller
    {
        private readonly IResultService _service = null;
        private readonly ISemesterService _semservice = null;
       // private readonly IBranchService _branchService = null;
        private readonly IStudentService _studentService = null;
        private readonly ISubjectService _subjectService = null;
         
        
        public ResultController(IResultService service,ISemesterService ssemester, IStudentService sservice,ISubjectService subservice)
        {
            _service = service;
            _semservice = ssemester;
           // _branchService = bservice;
            _studentService = sservice;
            _subjectService = subservice;
        }
        [HttpGet]
        public IActionResult AddResult()
        {


            List<SelectListItem> semlist = _semservice.GetSemesters().Select(n => new SelectListItem { Value = n.SemesterId.ToString(), Text = n.semester }).ToList(); ;

            var semTip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Semester ---"
            };
            semlist.Insert(0, semTip);
            ViewBag.semlist = new SelectList(semlist, "Value", "Text");

            List<SelectListItem> studentlist = _studentService.GetStudents().Select(n => new SelectListItem { Value = n.StudentId.ToString(), Text = n.StudentId.ToString() }).ToList(); ;

            var stTip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Student ---"
            };
            studentlist.Insert(0, stTip);
            ViewBag.studentlist = new SelectList(studentlist, "Value", "Text");

            List<SelectListItem> subjectlist = _subjectService.GetSubjects().Select(n => new SelectListItem { Value = n.SubjectId.ToString(), Text = n.SubjectName}).ToList(); ;

            var subTip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Subject ---"
            };
            subjectlist.Insert(0, subTip);
            ViewBag.subjectlist = new SelectList(subjectlist, "Value", "Text");

            return View();

        }

        [HttpPost]
        public IActionResult AddResult(Result result)
        {
           
            _service.AddResult(result);

            return RedirectToAction("GetResults");

        }
        [HttpGet]
        public IActionResult GetResults()
        {

            return View(_service.GetResults());
        }

        [HttpGet]

        public IActionResult Get(int id)
        {
            try
            {
                var result = _service.GetResult(id);
                if (result != null)
                    return Ok(result);
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
            Result result = _service.GetResult(id);
            return View(result);
        }
        [HttpPost]

        public IActionResult Edit(Result reslut)
        {
            _service.UpdateResult(reslut);

            return RedirectToAction("GetResults");
        }
        [HttpGet]

        public IActionResult Delete(int id)
        {
            Result reult = _service.GetResult(id);

            return View(reult);
        }

        [HttpPost]
        public IActionResult Delete(Result result)
        {
            _service.DeleteResult(result.ResultId);

            return RedirectToAction("GetResults");
        }
    }
}
