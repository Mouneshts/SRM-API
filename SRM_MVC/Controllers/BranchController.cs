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
    public class BranchController : Controller
    {
        private IBranchService _service = null;
        CoursesService _cservice = new CoursesService();
        public BranchController(IBranchService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult AddBranch()
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
        public IActionResult AddBranch(Branch branch)
        {

            List<SelectListItem> courseslist = _cservice.GetCourses().Select(n => new SelectListItem { Value = n.CourseId.ToString(), Text = n.CourseName }).ToList(); ;

            var courseTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Course ---"
            };
            _service.AddBranch(branch);
            return RedirectToAction("GetBranchs");

        }

        [HttpGet]
        public IActionResult GetBranchs()
        {

            return View(_service.GetBranchs());
        }

        [HttpGet]

        public IActionResult Get(int id)
        {
            try
            {
                var courses = _service.GetBranch(id);
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
            Branch course = _service.GetBranch(id);
            return View(course);
        }
        [HttpPost]

        public IActionResult Edit(Branch branch)
        {
            _service.UpdateBranch(branch);

            return RedirectToAction("GetBranchs");
        }
        [HttpGet]

        public IActionResult Delete(int id)
        {
            Branch branch = _service.GetBranch(id);

            return View(branch);
        }

        [HttpPost]
        public IActionResult Delete(Branch branch)
        {
            _service.DeleteBranch(branch.BId);

            return RedirectToAction("GetBranchs");
        }
    }
}
