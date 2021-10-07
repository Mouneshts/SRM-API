using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRM_MVC.Models;
using SRM_MVC.Services;
using Microsoft.AspNetCore.Http;

namespace SRM_MVC.Controllers
{
    public class CourseController : Controller
    {
        private ICoursesService _service = null;
        public CourseController(ICoursesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult AddCourse(Courses course)
        {
            try
            {

            }
            catch (Exception e)
            {
                return View();
            }
            _service.AddCourse(course);
            return RedirectToAction("GetCourses");

        }

        [HttpGet]
        public IActionResult GetCourses()
        {
            
            return View(_service.GetCourses());
        }

        [HttpGet]
       
        public IActionResult Get(int id)
        {
            try
            {
                var courses = _service.GetCourse(id);
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
            Courses course= _service.GetCourse(id);
            return View(course);
        }
        [HttpPost]

        public IActionResult Edit(Courses course)
        {
            _service.UpdateCourse(course);

            return RedirectToAction("GetCourses");
        }
        [HttpGet]
        
        public IActionResult Delete(int id)
        {
            Courses course= _service.GetCourse(id);

             return View(course);
        }

        [HttpPost]        
        public IActionResult Delete(Courses course)
        {
            _service.DeleteCourse(course.CourseId);

            return RedirectToAction("GetCourses");
        }

    }
}
